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
    [Route("api/Recomendados")]
    public class RecomendadoController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IRecomendadoRepository _recomendadoRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recomendadoRepository"></param>
        public RecomendadoController(IRecomendadoRepository recomendadoRepository)
        {
            _recomendadoRepository = recomendadoRepository;
        }
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("Listar")]
        public ActionResult GetRecomendados()
        {
            var rest = _recomendadoRepository.GetRecomendados();
            return Json(rest);
        }
    }
}
