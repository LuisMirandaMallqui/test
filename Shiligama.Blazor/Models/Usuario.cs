namespace Shiligama.Blazor.Models;

/// <summary>Rol de acceso — RNF004 control basado en roles.</summary>
public enum RolUsuario { Administrador, Trabajador, Cliente }

public class Usuario
{
    public int        Id        { get; set; }
    public string     Nombre    { get; set; } = "";
    public string     Username  { get; set; } = "";
    /// <summary>Hash MD-5 — RNF005 (almacenado por backend Java).</summary>
    public string     PasswordHash { get; set; } = "";
    public RolUsuario Rol       { get; set; }
    public string?    Telefono  { get; set; }
    public string?    Dni       { get; set; }
    public string?    Direccion { get; set; }
    public bool       Activo    { get; set; } = true;
    public DateTime?  UltimoAcceso { get; set; }
}
