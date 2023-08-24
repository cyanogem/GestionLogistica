using GestionLogistica.Abstraction;
using System;
using System.Collections.Generic;

namespace GestionLogistica.Models.Cepsa
{
    public partial class TipoGuium : IEntity
    {
        public int TipoGuiaId { get; set; }
        public string DescripcionTipoGuia { get; set; } = null!;
        public bool Activo { get; set; }
        public virtual ICollection<Guium> Guia { get; set; }
    }
}
