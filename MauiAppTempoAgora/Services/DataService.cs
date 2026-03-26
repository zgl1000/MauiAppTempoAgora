using MauiAppTempoAgora.Models;
using Newtonsoft.Json;

namespace MauiAppTempoAgora.Services
{
    public class DataService
    {
        private readonly static string Chave = "22ea50a4440ab42edb62787d395ff782";
        private static string Url (string cidade, string chave) => $"https://api.openweathermap.org/data/2.5/weather?q={cidade}&appid={chave}&units=metric&lang=pt_br";

        public static async Task<Tempo?> GetPrevisao(string cidade)
        {
            Tempo tempo = new Tempo();

            using (var client = new HttpClient()) 
            { 
                HttpResponseMessage response = await client.GetAsync(Url(cidade, Chave));

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
