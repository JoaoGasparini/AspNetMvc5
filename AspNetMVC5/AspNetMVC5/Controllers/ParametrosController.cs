using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVC5.Controllers
{
    [RoutePrefix("parametros")]
    public class ParametrosController : Controller
    {
        [Route("{id:int}")]
        public ActionResult Index(int id, string texto)
        {
            return View();
        }
        
        [Route("{id:int}/{texto:maxlength(50)}")]
        public ActionResult IndexParametroObrigatorio(int id, string texto)
        {
            return View();
        }
    }
}