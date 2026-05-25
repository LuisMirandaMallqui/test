namespace Shiligama.Blazor.Models;

/// <summary>Registro de devolución / merma — RF011, base para reportes RF012.</summary>
public class Merma
{
    public int      Id            { get; set; }
    public DateTime Fecha         { get; set; } = DateTime.Now;
    public int      ProductoId    { get; set; }
    public string   ProductoNombre{ get; set; } = "";
    public decimal  Cantidad      { get; set; }
    public string   Motivo        { get; set; } = "";       // Vencido, Daño, Rotura, ...
    public decimal  CostoPerdido  { get; set; }
    public int      RegistradoPorId { get; set; }
    public string   RegistradoPor { get; set; } = "";
    public string?  Observaciones { get; set; }
}
