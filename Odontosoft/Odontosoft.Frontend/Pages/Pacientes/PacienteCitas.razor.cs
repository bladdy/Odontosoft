using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Odontosoft.Frontend.Repositories;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Frontend.Pages.Pacientes;

public partial class PacienteCitas
{
    [Inject] private IRepository Repository { get; set; } = default!;
    [Inject] private NavigationManager NavigationManager { get; set; } = default!;
    [Inject] private SweetAlertService SweetAlertService { get; set; } = default!;

    private List<Cita> Citas = new();
    private List<Medico> Medicos = new();

    private Guid? medicoSeleccionado;
    private DateTime fechaSeleccionada = DateTime.Today;

    private List<int> Horas => Enumerable.Range(7, 16).ToList();

    protected override async Task OnParametersSetAsync()
    {
        //await LoadCitasPacientes();
    }

    protected override async Task OnInitializedAsync()
    {
        await LoadCitas();
        await LoadMedicos();
    }

    private async Task LoadCitas()
    {
        var response = await Repository.GetAsync<List<Cita>>("api/Citas");

        if (!response.Error)
        {
            Citas = response.Response!;
        }
    }

    private async Task LoadMedicos()
    {
        var response = await Repository.GetAsync<List<Medico>>("api/Medicos");

        if (!response.Error)
        {
            Medicos = response.Response!;
        }
    }

    private IEnumerable<Cita> GetCitasPorDia(int hora)
    {
        return Citas
            .Where(c =>
                c.FechaHora.Date == fechaSeleccionada.Date &&
                c.FechaHora.Hour == hora &&
                (!medicoSeleccionado.HasValue || c.MedicoId == medicoSeleccionado))
            .OrderBy(c => c.FechaHora);
    }

    private string GetColor(Cita cita)
    {
        return cita.EstadoCita switch
        {
            "Completada" => "#16a34a",
            "Pendiente" => "#f59e0b",
            "Cancelada" => "#dc2626",
            _ => "#3b82f6"
        };
    }

    private void OnMedicoChange(ChangeEventArgs e)
    {
        if (Guid.TryParse(e.Value?.ToString(), out var id))
            medicoSeleccionado = id;
        else
            medicoSeleccionado = null;
    }
}