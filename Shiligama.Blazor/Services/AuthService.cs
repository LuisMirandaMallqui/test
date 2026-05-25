using Shiligama.Blazor.Models;

namespace Shiligama.Blazor.Services;

/// <summary>Autenticación contra el backend Java. RF015 + RNF004 (roles).</summary>
public class AuthService
{
    private readonly ApiClient _api;
    public AuthService(ApiClient api) => _api = api;

    public Usuario? UsuarioActual { get; private set; }
    public event Action? OnCambio;

    public async Task<bool> IniciarSesionAsync(string user, string pass, RolUsuario rol)
    {
        var payload = new { user, pass, rol };
        var resp = await _api.PostAsync<Usuario>("auth/login", payload);
        if (resp is null) return false;
        UsuarioActual = resp;
        OnCambio?.Invoke();
        return true;
    }

    public void CerrarSesion()
    {
        UsuarioActual = null;
        OnCambio?.Invoke();
    }

    public bool TieneRol(RolUsuario rol) => UsuarioActual?.Rol == rol;
}
