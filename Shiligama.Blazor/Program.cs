using Shiligama.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

// ── Blazor Server + DI ─────────────────────────────────────────────────────
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// HttpClient apuntando al backend Java 25 (configurable en appsettings.json)
builder.Services.AddHttpClient<ApiClient>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ShiligamaApi"] ?? "http://localhost:8080/api/");
});

// Servicios de negocio (consumen la API Java)
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<ReporteService>();

// Estado del carrito por usuario (RF016, RF017)
builder.Services.AddScoped<CarritoState>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();                  // RNF006 HTTPS
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
