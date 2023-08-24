using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLogistica.Entity.DTO
{
    public class UserLoginResponseDTO
    {
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Token { get; set; }
        public bool Success { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? Email { get; set; }

    }
}
