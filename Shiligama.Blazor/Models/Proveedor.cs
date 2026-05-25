namespace Shiligama.Blazor.Models;

public class Proveedor
{
    public int    Id       { get; set; }
    public string Razon    { get; set; } = "";
    public string Ruc      { get; set; } = "";
    public int    CategoriaId { get; set; }
    public string CategoriaNombre { get; set; } = "";
    public string Contacto { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string? Email   { get; set; }
    public int    LeadTimeDias { get; set; } = 3;
    public bool   Activo   { get; set; } = true;
}
