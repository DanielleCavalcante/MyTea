using MyTea.Models;

namespace MyTea.Services
{
    public class NivelAcessoService
    {
        private HttpClient _httpClient;

        public NivelAcessoService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            /* Lembre de colocar a porta da sua máquina para testar */
            _httpClient.BaseAddress = new Uri("http://localhost:5249");
        }

        /*  IMPLEMENTAÇÃO DOS ACESSOS AOS ENDPOINTS DA API */

        // Read - todos os registros

        public async Task<List<NivelAcesso>> GetNAcessoAsync()
        {
            var apiResposta = await _httpClient.GetFromJsonAsync<List<NivelAcesso>>($"/api/NivelAcesso/TodosOsRegistros/GetAll");

            return apiResposta;
        }

        // Read - um registro
        public async Task<NivelAcesso> GetNAcessoByIdAsync(int id)
        {
            var apiResposta = await _httpClient.GetFromJsonAsync<NivelAcesso>($"/api/NivelAcesso/RegistroUnico/GetOne/{id}");

            return apiResposta;
        }

        // Create
        public async Task<NivelAcesso> AddNAcessoAsync(NivelAcesso nacesso)
        {
            var apiResposta = await _httpClient.PostAsJsonAsync<NivelAcesso>($"/api/NivelAcesso/InserirRegistro/criarRegistro", nacesso);

            apiResposta.EnsureSuccessStatusCode();

            return await apiResposta.Content.ReadFromJsonAsync<NivelAcesso>();

        }

        // Update
        public async Task<NivelAcesso> UpdateNAcessoAsync(int id, NivelAcesso nacesso)
        {
            var apiResposta = await _httpClient.PutAsJsonAsync<NivelAcesso>($"/api/NivelAcesso/AlterarRegistro/atualizarRegistro/{id}", nacesso);

            apiResposta.EnsureSuccessStatusCode();

            return await apiResposta.Content.ReadFromJsonAsync<NivelAcesso>();
        }

        // Delete
        public async Task DeleteNAcessoAsync(int id)
        {
            var apiResposta = await _httpClient.DeleteAsync($"/api/NivelAcesso/ExcluirRegistro/excluirRegistro/{id}");

            apiResposta.EnsureSuccessStatusCode();
        }
    }
}
