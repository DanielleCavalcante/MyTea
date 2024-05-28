using MyTea.Models;

namespace MyTea.Services
{
    public class LancamentoHorasService
    {
        private HttpClient _httpClient;

        public LancamentoHorasService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("http://localhost:5249");
        }

        /*  IMPLEMENTAÇÃO DOS ACESSOS AOS ENDPOINTS DA API */

        // Read - todos os registros

        public async Task<List<LancamentoHoras>> GetLHoraAsync()
        {
            var apiResposta = await _httpClient.GetFromJsonAsync<List<LancamentoHoras>>($"/api/LancamentoHoras/TodosOsRegistros/GetAll");

            return apiResposta;
        }

        // Read - um registro
        public async Task<LancamentoHoras> GetLHoraByIdAsync(int id)
        {
            var apiResposta = await _httpClient.GetFromJsonAsync<LancamentoHoras>($"/api/LancamentoHoras/RegistroUnico/GetOne/{id}");

            return apiResposta;
        }

        // Create
        public async Task<LancamentoHoras> AddLHoraAsync(LancamentoHoras lhora)
        {
            var apiResposta = await _httpClient.PostAsJsonAsync<LancamentoHoras>($"/api/LancamentoHoras/InserirRegistro/criarRegistro", lhora);

            apiResposta.EnsureSuccessStatusCode();

            return await apiResposta.Content.ReadFromJsonAsync<LancamentoHoras>();

        }

        // Update
        public async Task<LancamentoHoras> UpdateLHoraAsync(int id, LancamentoHoras lhora)
        {
            var apiResposta = await _httpClient.PutAsJsonAsync<LancamentoHoras>($"/api/LancamentoHoras/AlterarRegistro/atualizarRegistro/{id}", lhora);

            apiResposta.EnsureSuccessStatusCode();

            return await apiResposta.Content.ReadFromJsonAsync<LancamentoHoras>();
        }

        // Delete
        public async Task DeleteLHoraAsync(int id)
        {
            var apiResposta = await _httpClient.DeleteAsync($"/api/LancamentoHoras/ExcluirRegistro/excluirRegistro/{id}");

            apiResposta.EnsureSuccessStatusCode();
        }
    }
}
