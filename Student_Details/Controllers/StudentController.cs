using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using Student_Details.Service;
using System.Web.Security;
using Student_Details.Models;

namespace Student_Details.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        // GET: Student

        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> StudentDetails()
        {
            String ID_value = Session["ID"].ToString();
            int Convert_ID_Value = Int32.Parse(ID_value);
            var Data = await DBaccess.StudentDetailsAsync(Convert_ID_Value);
            return View(Data);
        }

        [HttpGet]
        public async Task<ActionResult> UpdateMail()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UpdateMail(Student_Details_Sundram model)
        {
            String ID_value = Session["ID"].ToString();
            bool Data = await DBaccess.UpdateStudentPassWord(model, ID_value);
            if (Data)
            {
                return RedirectToAction("Index", "Student");
            }
            else
            {
                throw new Exception();
            }

        }
    }
}