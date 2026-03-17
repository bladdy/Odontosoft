using Microsoft.AspNetCore.Components;
using Odontosoft.Frontend.Repositories;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Frontend.Pages.Pacientes
{
    public partial class PacienteDetalle
    {
        [Parameter] public Guid Id { get; set; }
        private string activeTab = "citas";
        [Inject] public IRepository Repository { get; set; } = default!;

        public Paciente? Paciente { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await Repository.GetAsync<Paciente>($"api/Paciente/{Id}");

            if (!response.Error)
            {
                Paciente = response.Response;
            }
        }
    }
}