using MauiAppTempoAgora.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MauiAppTempoAgora.Services
{
    public class DataService : IDataService
    {
        private readonly string _chave;
        private string Url (string cidade, string chave) => $"https://api.openweathermap.org/data/2.5/weather?q={cidade}&appid={_chave}&units=metric&lang=pt_br";

        public DataService(IConfiguration configuration)
        {
            _chave = configuration["OpenWeather:ApiKey"]
                 ?? throw new InvalidOperationException("API Key não configurada.");
        }

        public async Task<Tempo?> GetPrevisao(string cidade)
        {
            Tempo tempo = new Tempo();

            using (var client = new HttpClient()) 
            { 
                HttpResponseMessage response = await client.GetAsync(Url(cidade, _chave));

                if (response.IsSuccessStatusCode) 
                {
                    string json = await response.Content.ReadAsStringAsync();
                    tempo = JsonConvert.DeserializeObject<Tempo>(json);
                }
            }

            return tempo;
        }
    }
}
