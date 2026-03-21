using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Odontosoft.Frontend.Repositories;
using Odontosoft.Shared.DTOs.Paciente;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Frontend.Pages.Pacientes.Components;

public partial class CreatePacienteModal
{
    [Inject] private IRepository Repository { get; set; } = default!;
    [Inject] private SweetAlertService SweetAlertService { get; set; } = default!;
    [Parameter] public bool IsOpen { get; set; }

    [Parameter] public EventCallback OnClose { get; set; }

    [Parameter] public EventCallback<PacienteCreateDTO> OnPacienteCreated { get; set; }

    private PacienteCreateDTO Paciente { get; set; } = new();

    private async Task HandleSubmit()
    {
        Paciente.SucursalId = Guid.Parse("175daa29-3bce-4651-384a-08de7958f404");
        Paciente.NumeroExpediente = $"EXP-{DateTime.Now:yyyyMMddHHmmss}";
        Paciente.RFC = "Un RFC";
        Paciente.Foto = "nofoto.jpg"; // Aquí puedes asignar la foto si es necesario
        Paciente.Activo = true; // Asumiendo que el nuevo paciente estará activo por defecto
        var response = await Repository.PostAsync("api/Paciente/full", Paciente);
        if (response.Error)
        {
            await SweetAlertService.FireAsync("Error", "No se pudo guardar el Paciente.", SweetAlertIcon.Error);
            return;
        }
        else
        {
            await SweetAlertService.FireAsync("Éxito", "Paciente creado correctamente.", SweetAlertIcon.Success);
        }

        await OnPacienteCreated.InvokeAsync(Paciente);
        Paciente = new();
        await Close();
    }

    private async Task Close()
    {
        await OnClose.InvokeAsync();
    }
}