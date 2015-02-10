using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DXWebApplication1.Database;
using DXWebApplication1.Infrastructure.Caching;
using DXWebApplication1.Infrastructure.EntityException;
using DXWebApplication1.Infrastructure;

namespace DXWebApplication1.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        SEVESOIIEntities dbcontext = new SEVESOIIEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult partial()
        {
            var data = dbcontext.BILDIRIM.Where(b => b.FK_KATEGORI == 2).AsQueryable();
            return PartialView("partial", data);
        }

        public ActionResult Maps()
        {
            return View();
        }
        public ActionResult MapTrain()
        {
            return View();
        }
    }
}