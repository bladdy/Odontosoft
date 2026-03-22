using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Odontosoft.Frontend.Repositories;
using Odontosoft.Shared.DTOs.Paciente;

namespace Odontosoft.Frontend.Pages.Pacientes.Components;

public partial class EditPacienteModal
{
    [Inject] private IRepository Repository { get; set; } = default!;
    [Inject] private SweetAlertService SweetAlertService { get; set; } = default!;

    [Parameter] public bool IsOpen { get; set; }

    [Parameter] public EventCallback OnClose { get; set; }

    [Parameter] public EventCallback<PacienteCreateDTO> OnPacienteUpdated { get; set; }

    [Parameter] public PacienteCreateDTO Paciente { get; set; } = new();

    protected override void OnParametersSet()
    {
        if (Paciente == null)
        {
            Paciente = new PacienteCreateDTO();
        }
    }

    private async Task HandleSubmit()
    {
        var response = await Repository.PutAsync($"api/Paciente/full", Paciente);

        if (response.Error)
        {
            await SweetAlertService.FireAsync("Error", "No se pudo actualizar el paciente.", SweetAlertIcon.Error);
            return;
        }

        await SweetAlertService.FireAsync("Éxito", "Paciente actualizado correctamente.", SweetAlertIcon.Success);

        await OnPacienteUpdated.InvokeAsync(Paciente);
        await Close();
    }

    private async Task Close()
    {
        await OnClose.InvokeAsync();
    }
}