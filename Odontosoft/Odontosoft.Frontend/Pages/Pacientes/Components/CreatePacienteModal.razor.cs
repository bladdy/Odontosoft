using Microsoft.AspNetCore.Components;
using Odontosoft.Shared.DTOs.Paciente;

namespace Odontosoft.Frontend.Pages.Pacientes.Components;

public partial class CreatePacienteModal
{
    [Parameter] public bool IsOpen { get; set; }

    [Parameter] public EventCallback OnClose { get; set; }

    [Parameter] public EventCallback<PacienteCreateDTO> OnPacienteCreated { get; set; }

    private PacienteCreateDTO Paciente { get; set; } = new();

    private async Task HandleSubmit()
    {
        // Aqu� puedes llamar tu API
        // await _pacienteService.Create(Paciente);

        await OnPacienteCreated.InvokeAsync(Paciente);
        await Close();
    }

    private async Task Close()
    {
        await OnClose.InvokeAsync();
    }
}