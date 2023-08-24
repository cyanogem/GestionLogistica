using GestionLogistica.Abstraction.DTO.Guia;
using GestionLogistica.Abstraction.DTO;
using GestionLogistica.BAL.Dominio;
using GestionLogistica.Models.Cepsa;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace GestionLogistica.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaritimaController : Controller
    {
        ILogger _logger;
        MaritimaBAL<Guium> _logicaBAL;

        public MaritimaController(ILogger<Guium> _logger, MaritimaBAL<Guium> _logicaBAL)
        {
            this._logicaBAL = _logicaBAL;
            this._logger = _logger;
        }

        #region ReportePlanEntrega
        [HttpGet]
        public ActionResult<ResponseServicesDTO> ListReporteplanEntrega()
        {
            return this._logicaBAL.ReportePlanEntrega();
        }
        #endregion
        #region CRUD Guia
        [HttpGet]
        public ActionResult<ResponseServicesDTO> ListGuia()
        {
            return this._logicaBAL.ListGuia();
        }
        [HttpGet]
        public ActionResult<ResponseServicesDTO> GetGuiaById(int GuiaId)
        {
            return this._logicaBAL.GetGuia(GuiaId);

        }
        [HttpPost]
        public ActionResult<ResponseServicesDTO> SaveGuia(GuiaDTO guiaDTO)
        {
            return this._logicaBAL.SaveGuia(guiaDTO);

        }
        #endregion

        #region CRUD GuiaProducto
        [HttpGet]
        public ActionResult<ResponseServicesDTO> ListGuiaProducto(int GuiaId)
        {
            return this._logicaBAL.ListGuiaProducto(GuiaId);
        }
        [HttpGet]
        public ActionResult<ResponseServicesDTO> GetGuiaProductoById(int GuiaId)
        {
            return this._logicaBAL.GetGuia(GuiaId);

        }
        [HttpPost]
        public ActionResult<ResponseServicesDTO> SaveGuiaProducto(GuiaProductoDTO guiaProductoDTO)
        {
            return this._logicaBAL.SaveGuiaProducto(guiaProductoDTO);

        }
        #endregion

    }
}
