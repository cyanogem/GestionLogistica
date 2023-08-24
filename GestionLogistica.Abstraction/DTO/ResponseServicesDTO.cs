using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLogistica.Abstraction.DTO
{
    public class ResponseServicesDTO
    {
        public Object? ObjectResponse { get; set; }
        public bool Success { get; set; }
        public int CodeServiceResponse { get; set; }
        public string DescriptionServiceResponse { get; set; }
        public int CountRegisters { get; set; }
        public ErrorDetails ErrorDetails { get; set; }

        public ResponseServicesDTO()
        {
            this.ObjectResponse = null;
            this.Success = false;
            this.DescriptionServiceResponse = String.Empty;
            this.ErrorDetails = new ErrorDetails();
        }


    }
}
