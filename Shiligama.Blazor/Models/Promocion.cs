namespace Shiligama.Blazor.Models;

public enum TipoPromocion { Descuento, Combo, DosPorUno }

/// <summary>Promoción — RF009. Recomendaciones cruzadas en CrossSellService (RF010).</summary>
public class Promocion
{
    public int           Id          { get; set; }
    public string        Nombre      { get; set; } = "";
    public TipoPromocion Tipo        { get; set; }
    public List<int>     ProductosIds { get; set; } = new();
    public string        ProductosTexto { get; set; } = "";
    public int           DescuentoPct { get; set; }
    public DateTime      Desde       { get; set; }
    public DateTime      Hasta       { get; set; }
    public bool          Activa      { get; set; } = true;
}
