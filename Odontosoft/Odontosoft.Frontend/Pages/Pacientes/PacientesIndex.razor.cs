using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Odontosoft.Frontend.Repositories;
using Odontosoft.Shared.Entities;
using System.Net;

namespace Odontosoft.Frontend.Pages.Pacientes
{
    public partial class PacientesIndex
    {
        private int totalPages;
        private int currentPage = 1;

        [Parameter, SupplyParameterFromQuery] public string? Page { get; set; }
        [Parameter, SupplyParameterFromQuery] public int? SelectedPageSize { get; set; } = 25;
        [Parameter, SupplyParameterFromQuery] public int? RecordsNumber { get; set; }
        [Parameter, SupplyParameterFromQuery] public string Filter { get; set; } = string.Empty;

        [Inject] private IRepository Repository { get; set; } = default!;

        [Inject] private NavigationManager NavigationManager { get; set; } = default!;

        [Inject] private SweetAlertService SweetAlertService { get; set; } = default!;

        public List<Paciente> Pacientes { get; set; } = [];

        protected override async Task OnParametersSetAsync()
        {
            // Validar RecordsNumber
            RecordsNumber = RecordsNumber is null or <= 0 ? 15 : RecordsNumber;

            // Validar Page desde Query
            if (!string.IsNullOrWhiteSpace(Page) && int.TryParse(Page, out var pageFromQuery))
            {
                currentPage = pageFromQuery <= 0 ? 1 : pageFromQuery;
            }
            else
            {
                currentPage = 1;
            }
            await LoadPacientes(currentPage);
        }

        private async Task LoadPacientes(int page)
        {
            var ok = await LoadListAsync(page);

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

                if (SelectedPageSize != null)
                {
                    url += $"&PageSize={SelectedPageSize}";
                }
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

                // El backend ya devuelve el total de páginas
                totalPages = responseHttp.Response;
            }
            catch (Exception ex)
            {
                await SweetAlertService.FireAsync("Error", ex.Message, SweetAlertIcon.Error);
            }
        }

        private async Task ApplyFilterAsync()
        {
            int page = 1;
            await LoadPacientes(page);
        }

        private async Task CleanFilterAsync()
        {
            Filter = string.Empty;
            await LoadPacientes(1);
        }

        private async Task SelectedPage(int page)
        {
            currentPage = page;
            await LoadPacientes(currentPage);
        }

        private async Task<bool> LoadListAsync(int page)
        {
            try
            {
                var url = $"api/Paciente/paginated?PageNumber={page}";
                if (SelectedPageSize != null)
                {
                    url += $"&PageSize={SelectedPageSize}";
                }
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
                        NavigationManager.NavigateTo("/events");
                    }

                    return false;
                }

                Pacientes = responseHttp.Response ?? new();
                return true;
            }
            catch (Exception ex)
            {
                await SweetAlertService.FireAsync("Error", ex.Message, SweetAlertIcon.Error);
                return false;
            }
        }
    }
}