using CRUD_Operations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Operations.Controllers
{
    public class HomeController : Controller
    {
        private cntContext db = new cntContext();
        [Route("")]
        public ActionResult Index()
        {
            return View(db.MissingPersons.ToList());
        }
    }
}