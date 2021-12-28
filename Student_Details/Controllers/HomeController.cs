using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using Student_Details.Models;
using Student_Details.Service;


namespace Student_Details.Controllers
{

    [Authorize]
    [HandleError]
    public class HomeController : Controller
    {
        Student_DBEntities DB = new Student_DBEntities();

        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }

        [AllowAnonymous]
        [OutputCache(Duration = 30)]
        public ActionResult Contact()
        {

            return View();
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> getList()
        {
            List<Student_Details_Sundram> data = await DBaccess.GetAllStudentsAsync();
            return View(data);
        }

        [ChildActionOnly]
        public String TotaltNoOfstudent()
        {
            String total = "Total No Of Students:-" + "\t" + DB.Student_Details_Sundram.Count().ToString();
            return total;
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
                return RedirectToAction("getList");
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
                return RedirectToAction("getList");
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
        public async Task<ActionResult> Edit(Student_Details_Sundram editStudentobj)
        {
            bool Data = await DBaccess.EditAsync(editStudentobj);
            if (Data)
            {
                return RedirectToAction("getList");
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpGet]
        public async Task<ActionResult> EditUserProfile()
        {
            String ID_value = Session["ID"].ToString();
            int ID_Value_convert = Int32.Parse(ID_value);
            var Data = await DBaccess.EditUserProfileAsync(ID_Value_convert);
            return View(Data);
        }

        [HttpPost]
        public async Task<ActionResult> EditUserProfile(ADMIN model)
        {
            bool Data = await DBaccess.EditUserProfileAsync(model);
            if(Data)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
            
        }
        [HttpGet]
        public ActionResult CreateTeacher()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateTeacher(Login_SignUp_UserDetails Teacherdetails)
        {
            bool Data = await DBaccess.CreateTeacherAsync(Teacherdetails);
            if (Data)
            {
                return RedirectToAction("getList");
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<ActionResult> GetTeacherList()
        {
            List<Login_SignUp_UserDetails > data = await DBaccess.GetAllteachersAsync();
            return View(data);
        }


        public async Task<ActionResult> DeleteTeacher(int ID)
        {
            bool Data = await DBaccess.DeleteTeacherAsync(ID);
            if(Data)
            {
                return RedirectToAction("GetTeacherList");
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpGet]
        public async Task<ActionResult> EditTeacher(int ID)
        {
            var Data = await DBaccess.EditTeacherAsync(ID);
            return View(Data);
        }

        [HttpPost]
        public async Task<ActionResult> EditTeacher(Login_SignUp_UserDetails editStudentobj)
        {
            bool Data = await DBaccess.EditTeacherAsync(editStudentobj);
            if (Data)
            {
                return RedirectToAction("GetTeacherList");
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<ActionResult> DetailsTeacher(int ID)
        {
            var data = await DBaccess.DetailsTeacherAsync(ID);
            return View(data);
        }

    }
}