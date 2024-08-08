using LoadMoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoadMoreData.Controllers
{
    public class HomeController : Controller
    {
        LoadMoreEntities db = new LoadMoreEntities();

        public ActionResult Index()
        {
            int num = 3;
            Session["data"] = num;
            var data = db.loadings.ToList().Take(num);
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(loading l)
        {
            int rows = Convert.ToInt32(Session["data"]) + 3;
            var data = db.loadings.ToList().Take(rows);
            Session["data"] = rows;
            return PartialView("_Empdata", data); 
        }
        
    }
}