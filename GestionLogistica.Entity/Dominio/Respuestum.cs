using GestionLogistica.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLogistica.Entity.Dominio
{
    public partial class Respuestum : IEntity
    {
        public int IdRespuesta { get; set; }
        public int CodigoRespuesta { get; set; }
        public int IdIdioma { get; set; }
        public string MensajeRespuesta { get; set; } = null!;
        public int Estado { get; set; }
    }
}
