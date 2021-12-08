using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVC5.Controllers
{
    [RoutePrefix("Rota-fixa")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route(template:"sobre-nos")]
        public ActionResult About()
        {
            return View();
        }

        [Route(template: "institucional/fale-conosco")]
        public ActionResult Contact()
        {
            return View();
        }

        public ContentResult ContentResult()
       {
            return Content("Olá");
       }

        public FileContentResult fileContentResult()
        {
            //FAZ UM DOWNLOAD QUANDO EXECUTADO NESSA URL
            byte[] foto = System.IO.File.ReadAllBytes(Server.MapPath("/content/Images/passaros.jpg"));

            return File(foto, contentType:"image/jpg",fileDownloadName:"passaros.jpg");
        }

        public HttpUnauthorizedResult httpUnauthorizedResult()
        {
            return new HttpUnauthorizedResult();
        }

        public JsonResult JsonResult()
        {
            return Json(data: "teste:'teste'", JsonRequestBehavior.AllowGet);
        }

        public RedirectResult RedirectResult()
        {
            //DA PRA RETORNAR O QUE VOCE QUISER, DENTRO DA APLICAÇÃO OU FORA
            return new RedirectResult(url: "https://desenvolvedor.io");
        }
        

    }
}