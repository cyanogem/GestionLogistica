using GestionLogistica.Abstraction.DBContext;
using GestionLogistica.DataAccess;
using GestionLogistica.Entity.Dominio;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionlogistica.Repository.CodificacionRespuesta
{
    public class RespuestaRepository<T> : ARepositoryBase<T> where T : Respuestum
    {
        ILogger logger;
        IDBContext<T> dbctx;
        APIDBContext db;
        public RespuestaRepository(ILogger<RespuestaRepository<T>> _logger, IDBContext<T> _ctx, APIDBContext _db) : base(_logger, _ctx, _db)
        {
            this.dbctx = _ctx;
            this.logger = _logger;
            this.db = _db;
        }

        public Respuestum? GetByCodigoRespuesta(int code, int language)
        {
            return this.dbctx.GetAll().Where(x => x.CodigoRespuesta.Equals(code)).Where(x => x.IdIdioma.Equals(language)).Take(1).FirstOrDefault();
        }

    }
}
