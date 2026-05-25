using Shiligama.Blazor.Models;

namespace Shiligama.Blazor.Services;

/// <summary>Catálogo de productos — RF002, RF003.</summary>
public class ProductoService
{
    private readonly ApiClient _api;
    public ProductoService(ApiClient api) => _api = api;

    public async Task<List<Producto>> ListarAsync(int? categoriaId = null, string? busqueda = null)
    {
        var ruta = "productos";
        var q = new List<string>();
        if (categoriaId.HasValue)       q.Add($"categoriaId={categoriaId}");
        if (!string.IsNullOrWhiteSpace(busqueda)) q.Add($"q={Uri.EscapeDataString(busqueda)}");
        if (q.Count > 0) ruta += "?" + string.Join('&', q);

        return await _api.GetAsync<List<Producto>>(ruta) ?? new();
    }

    public Task<Producto?> ObtenerAsync(int id)       => _api.GetAsync<Producto>($"productos/{id}");
    public Task<Producto?> CrearAsync(Producto p)     => _api.PostAsync<Producto>("productos", p);
    public Task            ActualizarAsync(Producto p)=> _api.PutAsync($"productos/{p.Id}", p);
    public Task            EliminarAsync(int id)      => _api.DeleteAsync($"productos/{id}");

    /// <summary>Productos con stock por debajo del mínimo — RF005.</summary>
    public Task<List<Producto>> StockCriticoAsync()
        => _api.GetAsync<List<Producto>>("productos/stock-critico")!
              .ContinueWith(t => t.Result ?? new());

    /// <summary>Recomendaciones cross-selling — RF010. El algoritmo vive en la BL del backend Java.</summary>
    public Task<List<Producto>> RecomendarAsync(IEnumerable<int> productosCarrito)
        => _api.PostAsync<List<Producto>>("productos/recomendar", new { ids = productosCarrito })!
              .ContinueWith(t => t.Result ?? new());
}
