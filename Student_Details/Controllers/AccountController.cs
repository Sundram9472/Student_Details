using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Student_Details.Models;
using Student_Details.Service;
using System.Web.Security;

namespace Student_Details.Controllers
{

    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [HandleError]
        public async Task<ActionResult>Login(Login_SignUp_UserDetails model)
        {
            var Data = await DBaccess.LoginAsync(model);
                if (Data != null)
                {
                    FormsAuthentication.SetAuthCookie(model.User_Name, false);
                     Session["Name"] = Data.First_Name;
                     Session["ID"] = Data.ID;
                    return RedirectToAction("Index", "Home");
                }
               
            ModelState.AddModelError("", "Invalid UserName And Password");
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [HandleError]
        public async Task<ActionResult> Register(Login_SignUp_UserDetails model)
        {
            bool Data = await DBaccess.RegisterAsync(model);
            if(Data)
            {
                return RedirectToAction("Login");
            }
            else
            {
                throw new Exception("Exeption occured");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

       
    }
}