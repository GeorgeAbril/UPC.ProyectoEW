using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UPC.ProyectoEW.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/Maspedido")]
    public class MaspedidoController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IMaspedidosRepository m_repository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public MaspedidoController(IMaspedidosRepository repository)
        {
            m_repository = repository;
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("Listar")]
        public ActionResult GetMaspedidos()
        {
            var rest = m_repository.GetMaspedidos();
            return Json(rest);
        }
    }
}
