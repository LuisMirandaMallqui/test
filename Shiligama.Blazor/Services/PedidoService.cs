using Shiligama.Blazor.Models;

namespace Shiligama.Blazor.Services;

public class PedidoService
{
    private readonly ApiClient _api;
    public PedidoService(ApiClient api) => _api = api;

    public Task<List<Pedido>> ListarAsync()                   => _api.GetAsync<List<Pedido>>("pedidos")!.ContinueWith(t => t.Result ?? new());
    public Task<List<Pedido>> ListarPorClienteAsync(int id)   => _api.GetAsync<List<Pedido>>($"pedidos/cliente/{id}")!.ContinueWith(t => t.Result ?? new());

    /// <summary>Confirma venta presencial (POS) — RF004 descuenta stock, RF006 emite comprobante Nubefact.</summary>
    public Task<Pedido?> ConfirmarVentaPosAsync(Pedido pedido) => _api.PostAsync<Pedido>("pedidos/pos", pedido);

    /// <summary>Confirma pedido web — RF008 valida pago Mercado Pago.</summary>
    public Task<Pedido?> ConfirmarPedidoWebAsync(Pedido pedido) => _api.PostAsync<Pedido>("pedidos/web", pedido);

    /// <summary>Pedidos recibidos vía WhatsApp/n8n (RNF010).</summary>
    public Task<List<Pedido>> ListarWhatsAppAsync() => _api.GetAsync<List<Pedido>>("pedidos/whatsapp")!.ContinueWith(t => t.Result ?? new());
}
