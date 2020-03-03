using gorevYoneticisi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gorevYoneticisi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
             return View();
        }

       



        [HttpPost]
        public ActionResult Index(users user)
        {
          

            gorevYoneticisiEntities db = new gorevYoneticisiEntities();


            var kontrol = db.users.FirstOrDefault(x => x.username == user.username && x.password == user.password);
             if (kontrol!=null)
            {
                
                                       Session["userNameSession"] =kontrol.username ;
                TempData["ResultMessage"] = Session["userNameSession"];


                return RedirectToAction("HomePage", "Home");
            }
            return View();
        }


        [HttpPost]
    public ActionResult Kayit(users user2)
        {

            if (ModelState.IsValid)
            {
                using (var context = new gorevYoneticisiEntities())
                {
                    var std = new users()
                    {
                        username = user2.username,
                        password = user2.password,
                        name = user2.name,
                        surname = user2.surname

                    };
                    context.users.Add(std);

                    context.SaveChanges();
                }
                return RedirectToAction("AnaSayfa", "Home");

            }
            else
                return View("Index");

        }


        public ActionResult HomePage()
        {
            return View();
        }


        public ActionResult AnaSayfa()
        {
            return View();
        }





    }
}