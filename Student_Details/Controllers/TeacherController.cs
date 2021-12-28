using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using Student_Details.Service;
using Student_Details.Models;


namespace Student_Details.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        // GET: Teacher
        public async Task<ActionResult> getStudentList()
        {
            var Data = await DBaccess.GetAllStudentsAsync();
            return View(Data);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Student_Details_Sundram studentdetails)
        {
            bool Data = await DBaccess.CreateAsync(studentdetails);
            if (Data)
            {
                return RedirectToAction("getStudentList");
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<ActionResult> Details(int ID)
        {
            var data = await DBaccess.GetDetailsAsync(ID);
            return View(data);
        }

        public async Task<ActionResult> Delete(int ID)
        {
            var Data = await DBaccess.DeleteAsync(ID);
            if (Data)
            {
                return RedirectToAction("getStudentList");
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int ID)
        {
            var Data = await DBaccess.EditAsync(ID);
            return View(Data);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Login_SignUp_UserDetails editStudentobj)
        {
            bool Data = await DBaccess.EditTeacherAsync(editStudentobj);
            if (Data)
            {
                return RedirectToAction("Index");
            }
            else
            {
                throw new Exception();
            }
        }
    }

}