using Newtonsoft.Json;

namespace MauiAppTempoAgora.Models
{
    public class Tempo
    {
        [JsonProperty("coord")]
        public Coord? Coord { get; set; }

        [JsonProperty("weather")]
        public List<Weather?> Weather { get; set; }

        [JsonProperty("main")]
        public Main? Main { get; set; }

        [JsonProperty("visibility")]
        public long? Visibility { get; set; }

        [JsonProperty("wind")]
        public Wind? Wind { get; set; }

        [JsonProperty("sys")]
        public Sys? Sys { get; set; }
    }

    public class Coord
    {
        [JsonProperty("lon")]
        public double? Lon { get; set; }

        [JsonProperty("lat")]
        public double? Lat { get; set; }
    }

    public class Weather
    {
        [JsonProperty("main")]
        public string? Main { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp_min")]
        public double? TempMin { get; set; }

        [JsonProperty("temp_max")]
        public double? TempMax { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double? Speed { get; set; }
    }

    public class Sys
    {
        [JsonProperty("sunrise")]
        public long? Sunrise { get; set; }

        [JsonProperty("sunset")]
        public long? Sunset { get; set; }

        public DateTime SunriseDateTime => DateTimeOffset.FromUnixTimeSeconds(Sunrise.GetValueOrDefault()).LocalDateTime;
        public DateTime SunsetDateTime => DateTimeOffset.FromUnixTimeSeconds(Sunset.GetValueOrDefault()).LocalDateTime;
    }
}