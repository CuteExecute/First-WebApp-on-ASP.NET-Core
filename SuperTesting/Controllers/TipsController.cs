using Microsoft.AspNetCore.Mvc;
using SuperTesting.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperTesting.Controllers
{
    public class TipsController : Controller
    {
        db_work myobj = new db_work();

        public ViewResult Tips()
        {
            ViewBag.rnd = GetRandom();
            var tipz = myobj.getTips();
            return View(tipz);
        }

        public int GetRandom()
        {
            Random rnd = new Random();
            int my_rnd = rnd.Next(0, myobj.getTips().Count);
            return my_rnd;
        }
    }
}
