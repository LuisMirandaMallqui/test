namespace Shiligama.Blazor.Models;

/// <summary>Producto del catálogo — corresponde a tabla PRODUCTO en SQL Server.</summary>
public class Producto
{
    public int     Id          { get; set; }
    public string  Nombre      { get; set; } = "";
    public string  Descripcion { get; set; } = "";
    public decimal Precio      { get; set; }
    public decimal? PrecioOriginal { get; set; }
    public int     Stock       { get; set; }
    public int     StockMinimo { get; set; } = 5;        // RF005
    public string  Unidad      { get; set; } = "und";    // kg, bot, paq, etc.
    public int     CategoriaId { get; set; }
    public string  CategoriaNombre { get; set; } = "";
    public int     Vendidos    { get; set; }
    public bool    Activo      { get; set; } = true;

    /// <summary>Porcentaje de descuento si hay precio original.</summary>
    public int Descuento => PrecioOriginal is null || PrecioOriginal == 0
        ? 0
        : (int)System.Math.Round((1m - Precio / PrecioOriginal.Value) * 100m);

    public bool StockCritico => Stock <= StockMinimo;
}
