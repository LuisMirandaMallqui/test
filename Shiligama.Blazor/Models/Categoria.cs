namespace Shiligama.Blazor.Models;

public class Categoria
{
    public int    Id           { get; set; }
    public string Nombre       { get; set; } = "";
    public string Icono        { get; set; } = "📦";
    public bool   Activa       { get; set; } = true;
    public int    TotalProductos { get; set; }
}
