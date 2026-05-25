# Shiligama Sistema Web — Frontend Blazor

Proyecto **Blazor Server (.NET 10)** correspondiente al frontend del Sistema Web
Shiligama desarrollado por **Team Script E04** (PUCP — Programación 3, 2026).

## Stack

| Capa             | Tecnología                                           |
|------------------|------------------------------------------------------|
| Frontend         | **C# + .NET 10 + Blazor Server** *(este proyecto)*   |
| Backend REST     | Java 25 (IntelliJ) · arquitectura por capas DAO/BL/CTRL |
| Base de datos    | SQL Server · Stored Procedures (CRUD)               |
| Bot mensajería   | WhatsApp + n8n                                       |
| Facturación      | Nubefact (SUNAT, modo pruebas)                       |
| Pasarela pago    | Mercado Pago (sandbox)                               |

## Estructura

```
Shiligama.Blazor/
├── Shiligama.Blazor.csproj      # SDK Web .NET 10
├── Program.cs                   # Bootstrap + DI
├── App.razor                    # Router raíz
├── _Imports.razor               # Usings globales
│
├── wwwroot/
│   ├── index.html               # Host page
│   └── css/site.css             # Design tokens (paleta Shiligama)
│
├── Layout/
│   ├── MainLayout.razor         # Layout cliente / cajero
│   └── AdminLayout.razor        # Sidebar + módulos del admin
│
├── Pages/
│   ├── Login.razor                 # RF015 / RNF004
│   ├── Cliente/
│   │   ├── Home.razor              # RF003 catálogo + flash sale
│   │   ├── Carrito.razor           # RF016 + RF017 reserva stock
│   │   └── Pedidos.razor           # RF018 historial
│   ├── Cajero/
│   │   └── POS.razor               # RF006 + RF007 + comprobante
│   └── Admin/
│       ├── Dashboard.razor         # KPIs + integraciones
│       ├── Inventario.razor        # RF004 + RF005
│       ├── Productos.razor         # RF002 + RF003
│       ├── Proveedores.razor
│       ├── PedidosWA.razor         # RNF010 n8n
│       ├── Mermas.razor            # RF011 + RF012
│       ├── Promociones.razor       # RF009 + RF010
│       ├── Reportes.razor          # RF013 + RF014
│       └── Usuarios.razor          # RF001 + RNF004
│
├── Components/                   # Widgets reutilizables
│   ├── Logo.razor
│   ├── AppHeader.razor
│   ├── ProductCard.razor
│   ├── PaymentModal.razor
│   ├── StatCard.razor
│   ├── Pill.razor
│   └── QrCode.razor
│
├── Models/                       # DTOs alineados al backend Java
│   ├── Producto.cs
│   ├── Categoria.cs
│   ├── Usuario.cs
│   ├── Pedido.cs
│   ├── DetallePedido.cs
│   ├── Merma.cs
│   ├── Proveedor.cs
│   └── Promocion.cs
│
└── Services/                     # Clientes REST (HttpClient → Java)
    ├── ApiClient.cs
    ├── AuthService.cs
    ├── ProductoService.cs
    ├── PedidoService.cs
    ├── CarritoState.cs
    └── ReporteService.cs
```

## Cómo correr

```bash
cd Shiligama.Blazor
dotnet restore
dotnet run
# → http://localhost:5000
```

Configurar la URL del backend Java en `appsettings.json`:

```json
"ShiligamaApi": "http://localhost:8080/api"
```

## Mapeo Requisitos → Páginas

| RF      | Pantalla                              |
|---------|---------------------------------------|
| RF001   | `Admin/Usuarios.razor`                |
| RF002/3 | `Admin/Productos.razor`, `Cliente/Home.razor` |
| RF004/5 | `Admin/Inventario.razor`              |
| RF006/7 | `Cajero/POS.razor` + `PaymentModal`   |
| RF008   | `Cliente/Carrito.razor` (Mercado Pago)|
| RF009/10| `Admin/Promociones.razor`             |
| RF011/12| `Admin/Mermas.razor`                  |
| RF013/14| `Admin/Reportes.razor`                |
| RF015   | `Login.razor`                         |
| RF016/17| `Cliente/Carrito.razor`               |
| RF018   | `Cliente/Pedidos.razor`               |
