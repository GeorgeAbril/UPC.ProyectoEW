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
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly ICategoryRepository _categoryRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryRepository"></param>
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("Listar")]
        public ActionResult GetCategory()
        {
            var rest = _categoryRepository.GetCategory();
            return Json(rest);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("Obtener")]
        public ActionResult Getcategoriaxid(int id)
        {
            var rest = _categoryRepository.GetCategoryxid(id);
            return Json(rest);
        }
    }
}
