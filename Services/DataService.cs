using MyTea.Models;

namespace MyTea.Services
{
    public class DataService
    {
        private HttpClient _httpClient;

        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            /* Lembre de colocar a porta da sua máquina para testar */
            _httpClient.BaseAddress = new Uri("http://localhost:5249");
        }

        /*  IMPLEMENTAÇÃO DOS ACESSOS AOS ENDPOINTS DA API */

        // Read - todos os registros

        public async Task<List<Data>> GetDataAsync()
        {
            var apiResposta = await _httpClient.GetFromJsonAsync<List<Data>>($"/api/Data/TodosOsRegistros/GetAll");

            return apiResposta;
        }

        // Read - um registro
        public async Task<Data> GetDataByIdAsync(DateTime id)
        {
            var apiResposta = await _httpClient.GetFromJsonAsync<Data>($"/api/Data/RegistroUnico/GetOne/{id}");

            return apiResposta;
        }
    }
}
