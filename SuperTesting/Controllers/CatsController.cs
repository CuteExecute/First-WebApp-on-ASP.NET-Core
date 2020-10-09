using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperTesting.Data.Models;

namespace SuperTesting.Controllers
{
    public class CatsController : Controller
    {
        public ViewResult List()
        {
            ViewBag.Title = "Cats";
            db_work myobj = new db_work();
            var catz = myobj.getCat();
            return View(catz);
        }
    }
}
