using GestionLogistica.Abstraction.DTO;
using GestionLogistica.Entity.Dominio;
using Gestionlogistica.Repository.CodificacionRespuesta;
using Gestionlogistica.Repository.Dominio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionLogistica.Models.Cepsa;
using GestionLogistica.Abstraction.DTO.Guia;

namespace GestionLogistica.BAL.Dominio
{
    public class MaritimaBAL<T> : ABussinesBase<T> where T : Guium
    {
        MaritimaRepository<T> maritimaRepository;
        private readonly IConfiguration _configuration;
        public MaritimaBAL(ILogger<MaritimaBAL<T>> _logger,
            MaritimaRepository<T> _repositorio,
            RespuestaRepository<Respuestum> _repmensajesrta,
            IConfiguration configuration)
        {
            this.maritimaRepository = _repositorio;
            this.repositorioMensajesRta = _repmensajesrta;
            this.logger = _logger;
            this._configuration = configuration;
        }
        public override ResponseServicesDTO DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public override ResponseServicesDTO GetAll()
        {
            throw new NotImplementedException();
        }

        public override ResponseServicesDTO GetAllByPage(int _page, int _countByPage)
        {
            throw new NotImplementedException();
        }

        public override ResponseServicesDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override ResponseServicesDTO Save(T entity)
        {
            throw new NotImplementedException();
        }

        public override ResponseServicesDTO Update(T entity)
        {
            throw new NotImplementedException();
        }

        #region ReportePlanEntrega

        public ResponseServicesDTO ReportePlanEntrega()
        {
            List<ReportePlanEntregaDTO> reportePlanEntregas = maritimaRepository.ReportePlanEntrega();
            if (reportePlanEntregas != null)
            {
                ResponseServicesDTO response = createResponse(
               reportePlanEntregas,
               true,
               (int)3,
               getResponseMessage((int)3, 1),
               0);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false,
                  (int)2,
                  getResponseMessage((int)2, 1),
                  0);
                return response;
            }
        }

        #endregion

        #region CRUD Guia
        public ResponseServicesDTO ListGuia()
        {
            List<GuiaDTO> guiaDTOs = maritimaRepository.ListGuia();
            if (guiaDTOs != null)
            {
                ResponseServicesDTO response = createResponse(
               guiaDTOs,
               true,
               (int)3,
               getResponseMessage((int)3, 1),
               0);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false,
                  (int)2,
                  getResponseMessage((int)2, 1),
                  0);
                return response;
            }
        }
        public ResponseServicesDTO SaveGuia(GuiaDTO guiaDTO)
        {

            GuiaDTO guiaDTO1 = maritimaRepository.SaveGuia(guiaDTO);

            if (guiaDTO1 != null)
            {
                ResponseServicesDTO response = createResponse(
               guiaDTO1,
               true,
               (int)3,
               //parametrizar el mensaje de respuesta , y si trae opciones de varios idiomas
               getResponseMessage((int)3, 1),
               0);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false,
                  (int)2,
                  getResponseMessage((int)2, 1),
                  0);
                return response;
            }

        }
        public ResponseServicesDTO GetGuia(int GuiaId)
        {
            GuiaDTO guiaDTO = maritimaRepository.GetGuiaBy(GuiaId);
            if (guiaDTO != null)
            {
                ResponseServicesDTO response = createResponse(
               guiaDTO,
               true,
               (int)3,
               getResponseMessage((int)3, 1),
               0);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false,
                  (int)2,
                  getResponseMessage((int)2, 1),
                  0);
                return response;
            }
        }

        #endregion

        #region CRUD GuiaProducto
        public ResponseServicesDTO SaveGuiaProducto(GuiaProductoDTO guiaProductoDTO)
        {
            GuiaProductoDTO guiaProductos = maritimaRepository.SaveGuiaProducto(guiaProductoDTO);
            if (guiaProductos != null)
            {
                ResponseServicesDTO response = createResponse(
               guiaProductos,
               true,
               (int)3,
               getResponseMessage((int)3, 1),
               0);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false,
                  (int)2,
                  getResponseMessage((int)2, 1),
                  0);
                return response;
            }
        }
        public ResponseServicesDTO GetGuiaProducto(int GuiaProductoId)
        {
            GuiaProductoDTO guiaProductoDTO = maritimaRepository.GetGuiaPrpductoBy(GuiaProductoId);
            if (guiaProductoDTO != null)
            {
                ResponseServicesDTO response = createResponse(
               guiaProductoDTO,
               true,
               (int)3,
               getResponseMessage((int)3, 1),
               0);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false,
                  (int)2,
                  getResponseMessage((int)2, 1),
                  0);
                return response;
            }
        }
        public ResponseServicesDTO ListGuiaProducto(int GuiaId)
        {
            List<GuiaProductoDTO> guiaProductos = maritimaRepository.ListGuiaProducto(GuiaId);
            if (guiaProductos != null)
            {
                ResponseServicesDTO response = createResponse(
               guiaProductos,
               true,
               (int)3,
               getResponseMessage((int)3, 1),
               0);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false,
                  (int)2,
                  getResponseMessage((int)2, 1),
                  0);
                return response;
            }
        }

        #endregion

    }
}
