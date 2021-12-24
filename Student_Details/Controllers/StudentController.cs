using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using Student_Details.Service;

namespace Student_Details.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public async Task<ActionResult> AllStudent()
        {
            var Data = await DBaccess.GetAllStudentsAsync();
            return View(Data);
        }
    }
}