using MauiAppEjemplo.Modelo;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiAppEjemplo.Servicios
{
    public class EjerciciosService : IEjerciciosService
    {
        private readonly string _apiUrl = "https://api.openai.com/v1/engines/davinci-codex/completions"; // Cambia la URL según tu configuración
        private readonly string _apiKey = "YOUR_API_KEY"; // Reemplaza con tu clave API

        public async Task<List<EjercicioAdvice>> ObtenerConsejos(string prompt)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

            var requestBody = new
            {
                prompt = prompt,
                max_tokens = 150
            };

            var response = await client.PostAsJsonAsync(_apiUrl, requestBody);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var responseData = JsonSerializer.Deserialize<ChatGptResponse>(responseBody);

            var consejos = ParseConsejos(responseData);
            return consejos;
        }

        private List<EjercicioAdvice> ParseConsejos(ChatGptResponse responseData)
        {
            // Aquí debes implementar el código para analizar la respuesta y extraer los consejos sobre ejercicios.
            // Esto dependerá del formato de respuesta de la API de ChatGPT.
            return new List<EjercicioAdvice> { new EjercicioAdvice { Ejercicio = "Ejemplo", Consejo = responseData.choices[0].text } };
        }
    }
}
