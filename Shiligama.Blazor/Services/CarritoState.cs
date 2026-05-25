using Shiligama.Blazor.Models;

namespace Shiligama.Blazor.Services;

/// <summary>
/// Estado del carrito por usuario (scoped). Implementa RF016 (gestión) y RF017
/// (reserva temporal de stock 10 min). El stock real se bloquea en el backend Java.
/// </summary>
public class CarritoState
{
    public record Item(Producto Producto, int Cantidad);

    private readonly List<Item> _items = new();
    public IReadOnlyList<Item> Items => _items;
    public event Action? OnCambio;

    /// <summary>Marca de tiempo en que se activó la reserva (RF017).</summary>
    public DateTime? ReservaIniciada { get; private set; }
    public TimeSpan  ReservaDuracion => TimeSpan.FromMinutes(10);
    public TimeSpan? TiempoRestante => ReservaIniciada is null
        ? null
        : ReservaDuracion - (DateTime.Now - ReservaIniciada.Value);

    public void Agregar(Producto p, int cant = 1)
    {
        var i = _items.FindIndex(x => x.Producto.Id == p.Id);
        if (i < 0) _items.Add(new Item(p, cant));
        else       _items[i] = _items[i] with { Cantidad = _items[i].Cantidad + cant };
        ReservaIniciada ??= DateTime.Now;          // inicia el contador al agregar el 1er ítem
        OnCambio?.Invoke();
    }

    public void Cambiar(int productoId, int delta)
    {
        var i = _items.FindIndex(x => x.Producto.Id == productoId);
        if (i < 0) return;
        var nueva = _items[i].Cantidad + delta;
        if (nueva <= 0) _items.RemoveAt(i);
        else            _items[i] = _items[i] with { Cantidad = nueva };
        if (_items.Count == 0) ReservaIniciada = null;
        OnCambio?.Invoke();
    }

    public void Vaciar()
    {
        _items.Clear();
        ReservaIniciada = null;
        OnCambio?.Invoke();
    }

    public decimal Subtotal => _items.Sum(i => i.Producto.Precio * i.Cantidad);
    public decimal Igv      => Math.Round(Subtotal * 0.18m, 2);   // SUNAT
    public decimal Total    => Subtotal + Igv;
    public int     ItemsCount => _items.Sum(i => i.Cantidad);
}
