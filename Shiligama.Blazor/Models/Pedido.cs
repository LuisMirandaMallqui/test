namespace Shiligama.Blazor.Models;

public enum CanalVenta   { Presencial, WhatsApp, Web }
public enum MetodoPago   { Efectivo, Yape, Plin, Tarjeta, MercadoPago }
public enum EstadoPedido { Pendiente, Pagado, Preparando, EnRuta, Entregado, Anulado }

public class Pedido
{
    public int                   Id        { get; set; }
    public string                Codigo    { get; set; } = "";    // "WA-0142", "POS-0001"
    public DateTime              Fecha     { get; set; } = DateTime.Now;
    public int                   ClienteId { get; set; }
    public string                ClienteNombre { get; set; } = "";
    public CanalVenta            Canal     { get; set; }
    public MetodoPago            MetodoPago { get; set; }
    public EstadoPedido          Estado    { get; set; }
    public decimal               Subtotal  { get; set; }
    public decimal               Igv       { get; set; }          // 18% SUNAT
    public decimal               Total     { get; set; }
    public string?               DireccionEntrega { get; set; }
    public List<DetallePedido>   Detalles  { get; set; } = new();

    /// <summary>Nro. de comprobante emitido por Nubefact — RF006.</summary>
    public string? NumeroComprobante { get; set; }
}
