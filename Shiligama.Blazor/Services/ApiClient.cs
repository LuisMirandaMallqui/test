using System.Net.Http.Json;

namespace Shiligama.Blazor.Services;

/// <summary>Wrapper sobre HttpClient. Toda llamada va al backend Java 25 vía HTTPS (RNF006).</summary>
public class ApiClient
{
    private readonly HttpClient _http;
    public ApiClient(HttpClient http) => _http = http;

    public Task<T?>  GetAsync<T> (string ruta)              => _http.GetFromJsonAsync<T>(ruta);
    public async Task<T?> PostAsync<T>(string ruta, object body)
    {
        var resp = await _http.PostAsJsonAsync(ruta, body);
        resp.EnsureSuccessStatusCode();
        return await resp.Content.ReadFromJsonAsync<T>();
    }
    public async Task PutAsync<T>(string ruta, T body)
    {
        var resp = await _http.PutAsJsonAsync(ruta, body);
        resp.EnsureSuccessStatusCode();
    }
    public async Task DeleteAsync(string ruta)
    {
        var resp = await _http.DeleteAsync(ruta);
        resp.EnsureSuccessStatusCode();
    }
}
