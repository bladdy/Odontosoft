using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Odontosoft.Frontend.Repositories;
using Odontosoft.Shared.DTOs.Paciente;
using Odontosoft.Shared.Entities;
using System.Net;

namespace Odontosoft.Frontend.Pages.Pacientes;

public partial class PacienteConsultas
{
    private int totalPages;
    private int currentPage = 1;
    private Guid? openMenuId;

    private bool showEditModal = false;
    private PacienteCreateDTO pacienteSeleccionado = new();

    private bool showModal = false;
    [Parameter, SupplyParameterFromQuery] public int? Page { get; set; } = 1;

    [Parameter, SupplyParameterFromQuery]
    public int? SelectedPageSize { get; set; }

    [Parameter, SupplyParameterFromQuery] public string Filter { get; set; } = string.Empty;

    [Inject] private IRepository Repository { get; set; } = default!;
    [Inject] private NavigationManager NavigationManager { get; set; } = default!;
    [Inject] private SweetAlertService SweetAlertService { get; set; } = default!;
    [Parameter, SupplyParameterFromQuery] public int? RecordsNumber { get; set; } = 10;
    public List<Paciente> Pacientes { get; set; } = [];

    protected override async Task OnParametersSetAsync()
    {
        SelectedPageSize ??= 10;
        RecordsNumber ??= SelectedPageSize;

        currentPage = Page ?? 1;

        await LoadPacientes(currentPage);
    }

    private async Task LoadPacientes(int page = 1)
    {
        if (Page != null)
        {
            page = Page.Value;
        }
        var ok = await LoadListAsync(currentPage);
        if (ok)
        {
            await LoadPagesAsync();
        }
    }

    private async Task LoadPagesAsync()
    {
        try
        {
            var url = $"api/Paciente/totalRecords?RecordsNumber={RecordsNumber}";

            if (!string.IsNullOrWhiteSpace(Filter))
            {
                url += $"&Filter={Filter}";
            }

            var responseHttp = await Repository.GetAsync<int>(url);

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            totalPages = responseHttp.Response;
        }
        catch (Exception ex)
        {
            await SweetAlertService.FireAsync("Error", ex.Message, SweetAlertIcon.Error);
        }
    }

    private async Task PageSizeChanged()
    {
        currentPage = 1;
        await LoadPacientes(currentPage);
    }

    private async Task ApplyFilterAsync()
    {
        currentPage = 1;
        await LoadPacientes(currentPage);
    }

    private async Task CleanFilterAsync()
    {
        Filter = string.Empty;
        currentPage = 1;
        await LoadPacientes(currentPage);
    }

    private async Task SelectedPage(int page)
    {
        currentPage = page;
        await LoadPacientes(currentPage);
    }

    private void OpenModal() => showModal = true;

    private void CloseModal() => showModal = false;

    private async void OnPacienteCreated(PacienteCreateDTO paciente)
    {
        // refrescar lista, toast, etc

        showModal = false;
        await LoadPacientes(currentPage);
    }

    private async Task OnPacienteUpdated(PacienteCreateDTO paciente)
    {
        showEditModal = false;
        await LoadPacientes(currentPage);
    }

    private async Task<bool> LoadListAsync(int page)
    {
        try
        {
            RecordsNumber = SelectedPageSize ?? 10;
            var url = $"api/Paciente/paginated?Page={page}&RecordsNumber={RecordsNumber}";

            if (!string.IsNullOrWhiteSpace(Filter))
            {
                url += $"&Filter={Filter}";
            }
            var responseHttp = await Repository.GetAsync<List<Paciente>>(url);

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);

                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("/pacientes");
                }

                return false;
            }

            Pacientes = responseHttp.Response ?? [];
            return true;
        }
        catch (Exception ex)
        {
            await SweetAlertService.FireAsync("Error", ex.Message, SweetAlertIcon.Error);
            return false;
        }
    }

    private void ToggleMenu(Guid id)
    {
        if (openMenuId == id)
            openMenuId = null;
        else
            openMenuId = id;
    }

    private void VerPaciente(Guid id)
    {
        openMenuId = null;
        NavigationManager.NavigateTo($"/pacientes/{id}");
    }

    private void CrearCita(Guid id)
    {
        openMenuId = null;
        NavigationManager.NavigateTo($"/citas/nueva/{id}");
    }

    private void OpenEditModal(Paciente paciente)
    {
        pacienteSeleccionado = new PacienteCreateDTO
        {
            Id = paciente.Id,
            SucursalId = paciente.SucursalId,
            NumeroExpediente = paciente.NumeroExpediente,
            Nombre = paciente.Nombre,
            Apellidos = paciente.Apellidos,
            FechaNacimiento = paciente.FechaNacimiento,
            Estado = paciente.Estado,
            EstadoCivil = paciente.EstadoCivil,
            Ocupacion = paciente.Ocupacion,
            CodigoPostal = paciente.CodigoPostal,
            Sexo = paciente.Sexo,
            CURP = paciente.CURP,
            RFC = paciente.RFC,
            Email = paciente.Email,
            Telefono = paciente.Telefono,
            GrupoSanguineo = paciente.GrupoSanguineo,
            Foto = paciente.Foto,
            TelefonoEmergencia = paciente.TelefonoEmergencia,
            ContactoEmergencia = paciente.ContactoEmergencia,
            Direccion = paciente.Direccion,
            Ciudad = paciente.Ciudad
        };
        openMenuId = null;
        showEditModal = true;
    }

    private void CloseEditModal()
    {
        showEditModal = false;
    }
}