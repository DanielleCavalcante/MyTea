using MyTea.Models;

namespace MyTea.Services
{
    public class DepartamentoService
    {
        private HttpClient _httpClient;

        public DepartamentoService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            /* Lembre de colocar a porta da sua máquina para testar */
            _httpClient.BaseAddress = new Uri("http://localhost:5249");
        }

        /*  IMPLEMENTAÇÃO DOS ACESSOS AOS ENDPOINTS DA API */

        // Read - todos os registros

        public async Task<List<Departamento>> GetDeptoAsync()
        {
            var apiResposta = await _httpClient.GetFromJsonAsync<List<Departamento>>($"/api/Departamento/TodosOsRegistros/GetAll");

            return apiResposta;
        }

        // Read - um registro
        public async Task<Departamento> GetDeptoByIdAsync(int id)
        {
            var apiResposta = await _httpClient.GetFromJsonAsync<Departamento>($"/api/Departamento/RegistroUnico/GetOne/{id}");

            return apiResposta;
        }

        // Create
        public async Task<Departamento> AddDeptoAsync(Departamento depto)
        {
            var apiResposta = await _httpClient.PostAsJsonAsync<Departamento>($"/api/Departamento/InserirRegistro/criarRegistro", depto);

            apiResposta.EnsureSuccessStatusCode();

            return await apiResposta.Content.ReadFromJsonAsync<Departamento>();

        }

        // Update
        public async Task<Departamento> UpdateDeptoAsync(int id, Departamento depto)
        {
            var apiResposta = await _httpClient.PutAsJsonAsync<Departamento>($"/api/Departamento/AlterarRegistro/atualizarRegistro/{id}", depto);

            apiResposta.EnsureSuccessStatusCode();

            return await apiResposta.Content.ReadFromJsonAsync<Departamento>();
        }

        // Delete
        public async Task DeleteDeptoAsync(int id)
        {
            var apiResposta = await _httpClient.DeleteAsync($"/api/Departamento/ExcluirRegistro/excluirRegistro/{id}");

            apiResposta.EnsureSuccessStatusCode();
        }
    }
}
