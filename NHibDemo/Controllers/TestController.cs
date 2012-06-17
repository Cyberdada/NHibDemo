using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibDemo.Models;
using NHibDemo.Infrastructure;

namespace NHibDemo.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index(bool reset)
        {
            var factory = Bootstrapper.CreateSessionFactory(reset);
            using (var session = factory.OpenSession())
            {
                var p = new Person { FirstName = "Anders", LastName = "Hult", Address = new Address { City="Alingsås", Street="Hultebackavägen", ZipCode="44165" } };
                session.SaveOrUpdate(p.Address);
                session.SaveOrUpdate(p);
                ViewBag.Text = "Working";
            }
            return View();
        }


    }
}
