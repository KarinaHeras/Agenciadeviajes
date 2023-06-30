using AgenciaViajesKarinaHeras.infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgenciaViajesKarinaHeras.Controllers
{


    public class HomeController : Controller
    {
       [ValidateNamAttribute]
        public ActionResult Index()
        {
           
            return View();
        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult AuthenticateUsers()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Creater,Editor, Delete")]
        public ActionResult AdministratorOnly()
        {
            return View();
        }
        [Authorize(Users = "mvazquez@gmail.com, karinaheras@hotmail.com")]
        public ActionResult SpecificUserOnly()
        {
            return View();
        }
        public ActionResult AllUsers()
        {
            return View();
        }
        public ActionResult AuthenUsers()
        {
            return View();
        }
        public ActionResult WithoutPermission() 
        {
            ViewBag.Message = "Usted no cuenta con permisos de accesos a esta seccion.";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}