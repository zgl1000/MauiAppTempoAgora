using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txt_cidade.Text))
                {
                    Tempo? tempo = await DataService.GetPrevisao(txt_cidade.Text);

                    if (tempo != null) 
                    {
                        string dadosPrevisao = $"Latitude: {tempo.Coord?.Lat}\n" +
                                               $"Longitude: {tempo.Coord?.Lon}\n" +
                                               $"Nascer do Sol: {tempo.Sys?.SunriseDateTime:HH:mm}\n" +
                                               $"Por do Sol: {tempo.Sys?.SunsetDateTime:HH:mm}\n" +
                                               $"Temp Máx: {tempo.Main?.TempMax}\n" +
                                               $"Temp Min: {tempo.Main?.TempMin}";

                        lbl_resultado.Text = dadosPrevisao;
                    }
                    else
                    {
                        lbl_resultado.Text = "Dados não encontrados";
                    }
                }
                else
                {
                    lbl_resultado.Text = "Digite o nome da cidade";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Ops", ex.Message, "OK");
            }
        }
    }
}
