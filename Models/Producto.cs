using System;
using System.Collections.Generic;

namespace ReportesMVC.Models;

public partial class Producto
{
    public int Iidproducto { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();
}
