using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ComplainCenter.Controllers
{
   
    public class AccountController : Controller
    {
        ComplainCenterEntities db = new ComplainCenterEntities();
        //
        // GET: /Account/

        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if(user == null)
            {
                ViewBag.Error = "Invalid Email or Password....";
                return View("Index");
               
            }

            else
            {
                Session["email"] = user.Email;
                Session["uid"] = user.Id;
                Session["name"] = user.Name;
                Session["ut"] = user.UserType.Name;

                return RedirectToAction("Index", "Home");
               
            }
        }

    }
}
