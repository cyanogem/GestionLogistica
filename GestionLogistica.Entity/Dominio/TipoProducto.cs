using GestionLogistica.Abstraction;
using System;
using System.Collections.Generic;

namespace GestionLogistica.Models.Cepsa
{
    public partial class TipoProducto : IEntity
    {
        public TipoProducto()
        {
            Productos = new HashSet<Producto>();
        }

        public int TipoProductoId { get; set; }
        public string DescripcionTipoProducto { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
