using GestionLogistica.Abstraction;
using System;
using System.Collections.Generic;

namespace GestionLogistica.Models.Cepsa
{
    public partial class Cliente : IEntity
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public virtual ICollection<Guium> Guia { get; set; }
    }
}
