using MyTea.Models;

namespace MyTea.Services
{
    public class FuncionarioService
    {
        private HttpClient _httpClient;

        // construtor
        public FuncionarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            /* Lembre de colocar a porta da sua máquina para testar */
            _httpClient.BaseAddress = new Uri("http://localhost:5249");
        }

        /*  IMPLEMENTAÇÃO DOS ACESSOS AOS ENDPOINTS DA API */

        // READ - todos os registros
        public async Task<List<Funcionario>> GetFuncAsync()
        {
            var apiResposta = await _httpClient.GetFromJsonAsync<List<Funcionario>>($"/api/Funcionario/TodosOsRegistros/GetAll");

            return apiResposta;
        }

        // READ - um registro
        public async Task<Funcionario> GetFuncByIdAsync(int id)
        {
            var apiResposta = await _httpClient.GetFromJsonAsync<Funcionario>($"/api/Funcionario/RegistroUnico/GetOne/{id}");

            return apiResposta;
        }

        // CREATE
        public async Task<Funcionario> AddFuncAsync(Funcionario func)
        {
            var apiResposta = await _httpClient.PostAsJsonAsync<Funcionario>($"/api/Funcionario/InserirRegistro/criarRegistro", func);

            apiResposta.EnsureSuccessStatusCode();

            return await apiResposta.Content.ReadFromJsonAsync<Funcionario>();

        }

        // UPDATE
        public async Task<Funcionario> UpdateFuncAsync(int id, Funcionario func)
        {
            var apiResposta = await _httpClient.PutAsJsonAsync<Funcionario>($"/api/Funcionario/AlterarRegistro/atualizarRegistro/{id}", func);

            apiResposta.EnsureSuccessStatusCode();

            return await apiResposta.Content.ReadFromJsonAsync<Funcionario>();
        }

        // DELETE
        public async Task DeleteFuncAsync(int id)
        {
            var apiResposta = await _httpClient.DeleteAsync($"/api/Funcionario/ExcluirRegistro/excluirRegistro/{id}");

            apiResposta.EnsureSuccessStatusCode();
        }
    }
}
