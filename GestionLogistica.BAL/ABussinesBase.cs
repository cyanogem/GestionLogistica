using Gestionlogistica.Repository.CodificacionRespuesta;
using GestionLogistica.Abstraction;
using GestionLogistica.Abstraction.DTO;
using GestionLogistica.Entity.Dominio;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLogistica.BAL
{
    public interface IABussinesBase<T> : ICRUDBAL<T>
    {
    }

    public abstract class ABussinesBase<T> : IABussinesBase<T> where T : IEntity
    {
        public ILogger? logger;
        public RespuestaRepository<Respuestum>? repositorioMensajesRta;


        public abstract ResponseServicesDTO DeleteById(int id);
        public abstract ResponseServicesDTO GetAll();
        public abstract ResponseServicesDTO GetAllByPage(int _page, int _countByPage);
        public abstract ResponseServicesDTO GetById(int id);
        public abstract ResponseServicesDTO Save(T entity);
        public abstract ResponseServicesDTO Update(T entity);

        /// <summary>
        /// Este metodo permita la creación de un objeto de respuesta. 
        /// </summary>
        /// <param name="ObjectResponse">Contiene el objeto que conforma la respuesta, puede ser lista de valores o una entidad</param>
        /// <param name="Success">Indica si el resultado de la operacion fur o nó satisfactorio</param>
        /// <param name="CodeServiceResponse">Codificación en la tabla de las respuestas</param>
        /// <param name="CountRegisters">Cantidad de registros que se retornan, aplica en el caso de que sea una lista</param>
        /// <returns></returns>
        public ResponseServicesDTO createResponse(Object? objectResponse, bool success, int codeServiceResponse, string? descriptionServiceResponse, int CountRegisters)
        {
            return new ResponseServicesDTO()
            {
                ObjectResponse = objectResponse,
                Success = success,
                CodeServiceResponse = codeServiceResponse,
                DescriptionServiceResponse = descriptionServiceResponse,
                CountRegisters = CountRegisters
            };
        }

        public string? getResponseMessage(int code, int language)
        {
            string mesagge = "";
            Respuestum respuesta = this.repositorioMensajesRta.GetByCodigoRespuesta(code, language);
            if (respuesta != null)
                mesagge = respuesta.MensajeRespuesta;
            return mesagge;
        }

    }
}
