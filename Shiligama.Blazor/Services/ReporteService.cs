using Shiligama.Blazor.Models;

namespace Shiligama.Blazor.Services;

public class ReporteService
{
    private readonly ApiClient _api;
    public ReporteService(ApiClient api) => _api = api;

    public record VentaPorDia(string Dia, decimal Total);
    public record RankingProducto(string Producto, int Presencial, int WhatsApp, int Total);
    public record MermaResumen(decimal CostoTotal, int Registros, string MotivoTop);

    /// <summary>RF013 — Ventas por período y canal.</summary>
    public Task<List<VentaPorDia>> VentasSemanaAsync()
        => _api.GetAsync<List<VentaPorDia>>("reportes/ventas-semana")!.ContinueWith(t => t.Result ?? new());

    /// <summary>RF014 — Más vendidos presencial vs WhatsApp.</summary>
    public Task<List<RankingProducto>> MasVendidosAsync(DateTime desde, DateTime hasta)
        => _api.GetAsync<List<RankingProducto>>($"reportes/mas-vendidos?desde={desde:yyyy-MM-dd}&hasta={hasta:yyyy-MM-dd}")!
              .ContinueWith(t => t.Result ?? new());

    /// <summary>RF012 — Reporte de mermas.</summary>
    public Task<MermaResumen?> MermasAsync(DateTime desde, DateTime hasta)
        => _api.GetAsync<MermaResumen>($"reportes/mermas?desde={desde:yyyy-MM-dd}&hasta={hasta:yyyy-MM-dd}");
}
