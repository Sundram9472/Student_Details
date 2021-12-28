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
    [HandleError]
    public class AccountController : Controller
    {
        

        [HttpGet]
        public ActionResult AdminAuth()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult>AdminAuth(ADMIN model)
        {
            var Data = await DBaccess.LoginAdminAsync(model);
                if (Data != null)
                {
                    FormsAuthentication.SetAuthCookie(model.ADM_UserName, false);
                    Session["Name"] = Data.ADM_Name;
                    Session["ID"] = Data.ADM_ID;
                    Session["UserType"] = "Admin";
                    return RedirectToAction("Index", "Home");
                }
               
            ModelState.AddModelError("", "Invalid UserName And Password");
            return View();
        }

        [HttpGet]
        public ActionResult TeacherAuth()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> TeacherAuth(Login_SignUp_UserDetails model)
        {
            var Data = await DBaccess.LoginTeacherAsync(model);
            if (Data != null)
            {
                FormsAuthentication.SetAuthCookie(model.User_Name, false);
                Session["Name"] = Data.First_Name;
                Session["ID"] = Data.ID;
                Session["UserType"] = "Teacher";
                return RedirectToAction("Index", "Teacher");
            }

            ModelState.AddModelError("", "Invalid UserName And Password");
            return View();
        }

        [HttpGet]
        public ActionResult StudentAuth()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> StudentAuth(Student_Details_Sundram model)
        {
            var MailID = model.Student_MailId;
            var Data = await DBaccess.LoginStudentAsync(MailID);
            if (Data != null)
            {
                FormsAuthentication.SetAuthCookie(model.Student_FirstName, false);
                Session["Name"] = Data.Student_FirstName;
                Session["ID"] = Data.Student_ID;
                Session["UserType"] = "Student";
                return RedirectToAction("Index", "Student");
            }

            ModelState.AddModelError("", "Invalid Gmail");
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
            return RedirectToAction("Index", "Home");
        }
    }
}