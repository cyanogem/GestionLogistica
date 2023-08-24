using GestionLogistica.Abstraction;
using System;
using System.Collections.Generic;

namespace GestionLogistica.Models.Cepsa
{
    public partial class Bodega : IEntity
    {
        public int BodegaId { get; set; }
        public string DescripcionBodega { get; set; } = null!;
        public bool Activo { get; set; }
        public virtual ICollection<Guium> Guia { get; set; }
    }
}
