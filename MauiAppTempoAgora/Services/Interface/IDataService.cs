using MauiAppTempoAgora.Models;

public interface IDataService
{
    Task<Tempo?> GetPrevisao(string cidade);
}