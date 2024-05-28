using MyTea.Models;

namespace MyTea.Services
{
    public class WBSService
    {
        private HttpClient _httpClient;
       
        public WBSService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("http://localhost:5249");
        }

        /*  IMPLEMENTAÇÃO DOS ACESSOS AOS ENDPOINTS DA API */

        // Read - todos os registros

        public async Task<List<WBS>> GetWBSAsync()
        {
            var apiResposta = await _httpClient.GetFromJsonAsync<List<WBS>>($"/api/WBS/TodosOsRegistros/GetAll");

            return apiResposta;
        }

        // Read - um registro
        public async Task<WBS> GetWBSByIdAsync(int id)
        {
            var apiResposta = await _httpClient.GetFromJsonAsync<WBS>($"/api/WBS/RegistroUnico/GetOne/{id}");

            return apiResposta;
        }

        // Create
        public async Task<WBS> AddWBSAsync(WBS wbs)
        {
            var apiResposta = await _httpClient.PostAsJsonAsync<WBS>($"/api/WBS/InserirRegistro/criarRegistro", wbs);

            apiResposta.EnsureSuccessStatusCode();

            return await apiResposta.Content.ReadFromJsonAsync<WBS>();

        }

        // Update
        public async Task<WBS> UpdateWBSAsync(int id, WBS wbs)
        {
            var apiResposta = await _httpClient.PutAsJsonAsync<WBS>($"/api/WBS/AlterarRegistro/atualizarRegistro/{id}", wbs);

            apiResposta.EnsureSuccessStatusCode();

            return await apiResposta.Content.ReadFromJsonAsync<WBS>();
        }

        // Delete
        public async Task DeleteWBSAsync(int id)
        {
            var apiResposta = await _httpClient.DeleteAsync($"/api/WBS/ExcluirRegistro/excluirRegistro/{id}");

            apiResposta.EnsureSuccessStatusCode();
        }
    }
}
