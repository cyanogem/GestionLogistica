using GestionLogistica.Abstraction.DTO;
using GestionLogistica.Entity.Dominio;
using Gestionlogistica.Repository.CodificacionRespuesta;
using GestionLogistica.Models.Cepsa;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestionlogistica.Repository.Dominio;
using GestionLogistica.Abstraction.DTO.Guia;

namespace GestionLogistica.BAL.Dominio
{
    public class TerrestreBAL<T> : ABussinesBase<T> where T : Guium
    {
        TerrestreRepository<T> terrestreRepository;
        private readonly IConfiguration _configuration;
        public TerrestreBAL(ILogger<TerrestreBAL<T>> _logger,
            TerrestreRepository<T> _repositorio,
            RespuestaRepository<Respuestum> _repmensajesrta,
            IConfiguration configuration)
        {
            this.terrestreRepository = _repositorio;
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
            List<ReportePlanEntregaDTO> reportePlanEntregas = terrestreRepository.ReportePlanEntrega();
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
            List<GuiaDTO> guiaDTOs = terrestreRepository.ListGuia();
            if (guiaDTOs != null)
            {
                ResponseServicesDTO response = createResponse(
               guiaDTOs,
               true,
               (int)3,
               getResponseMessage((int)3,1),
               0);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false,
                  (int)2,
                  getResponseMessage((int)2,1),
                  0);
                return response;
            }
        }
        public ResponseServicesDTO SaveGuia(GuiaDTO guiaDTO)
        {

            GuiaDTO guiaDTO1 = terrestreRepository.SaveGuia(guiaDTO);

            if (guiaDTO1 != null)
            {
                ResponseServicesDTO response = createResponse(
               guiaDTO1,
               true,
               (int)3,
               //parametrizar el mensaje de respuesta , y si trae opciones de varios idiomas
               getResponseMessage((int)3,1),
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
            GuiaDTO guiaDTO = terrestreRepository.GetGuiaBy(GuiaId);
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
            GuiaProductoDTO guiaProductos = terrestreRepository.SaveGuiaProducto(guiaProductoDTO);
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
        public ResponseServicesDTO ListGuiaProducto(int GuiaId)
        {
            List<GuiaProductoDTO> guiaProductos = terrestreRepository.ListGuiaProducto(GuiaId);
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
            GuiaProductoDTO guiaProductoDTO = terrestreRepository.GetGuiaProductoBy(GuiaProductoId);
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

        #endregion

        #region CRUD Cliente
        public ResponseServicesDTO ListCliente()
        {
            List<ClienteDTO> clienteDTOs = terrestreRepository.ListCliente();
            if (clienteDTOs != null)
            {
                ResponseServicesDTO response = createResponse(
               clienteDTOs,
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
        public ResponseServicesDTO SaveCliente(ClienteDTO clienteDTO)
        {

            ClienteDTO cliente = terrestreRepository.SaveCliente(clienteDTO);

            if (cliente != null)
            {
                ResponseServicesDTO response = createResponse(
               cliente,
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
        public ResponseServicesDTO GetCliente(int ClienteId)
        {
            ClienteDTO cliente = terrestreRepository.GetClienteBy(ClienteId);
            if (cliente != null)
            {
                ResponseServicesDTO response = createResponse(
               cliente,
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

        #region CRUD Bodega
        public ResponseServicesDTO ListBodega()
        {
            List<BodegaDTO> bodegas = terrestreRepository.ListBodega();
            if (bodegas != null)
            {
                ResponseServicesDTO response = createResponse(
               bodegas,
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
        public ResponseServicesDTO SaveBodega(BodegaDTO bodegaDTO)
        {

            BodegaDTO bodega = terrestreRepository.SaveBodega(bodegaDTO);

            if (bodega != null)
            {
                ResponseServicesDTO response = createResponse(
               bodega,
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
        public ResponseServicesDTO GetBodega(int BodegaId)
        {
            BodegaDTO bodega = terrestreRepository.GetBodegaBy(BodegaId);
            if (bodega != null)
            {
                ResponseServicesDTO response = createResponse(
               bodega,
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

        #region CRUD Producto
        public ResponseServicesDTO ListProducto()
        {
            List<ProductoDTO> productos = terrestreRepository.ListProducto();
            if (productos != null)
            {
                ResponseServicesDTO response = createResponse(
               productos,
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
        public ResponseServicesDTO SaveProducto(ProductoDTO productoDTO)
        {

            ProductoDTO producto = terrestreRepository.SaveProducto(productoDTO);

            if (producto != null)
            {
                ResponseServicesDTO response = createResponse(
               producto,
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
        public ResponseServicesDTO GetProducto(int ProductoId)
        {
            ProductoDTO productoDTO = terrestreRepository.GetProductoBy(ProductoId);
            if (productoDTO != null)
            {
                ResponseServicesDTO response = createResponse(
               productoDTO,
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
