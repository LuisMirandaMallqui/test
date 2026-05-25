namespace Shiligama.Blazor.Models;

public class DetallePedido
{
    public int     ProductoId     { get; set; }
    public string  ProductoNombre { get; set; } = "";
    public int     Cantidad       { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal       => Cantidad * PrecioUnitario;
}
