using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Student_Details.Models;

namespace Student_Details.Service
{

    public class DBaccess
    {
        public async static Task<List<Student_Details_Sundram>> GetAllStudentsAsync()
        {
            Student_DBEntities db = new Student_DBEntities();
            var query = from item in db.Student_Details_Sundram
                        select item;
            return await query.ToListAsync();
        }

        public async static Task<List<Login_SignUp_UserDetails>> GetAllteachersAsync()
        {
            Student_DBEntities db = new Student_DBEntities();
            var query = from item in db.Login_SignUp_UserDetails
                        select item;
            return await query.ToListAsync();
        }


        public async static Task<bool> CreateAsync(Student_Details_Sundram model)
        {
            if (model != null)
            {
                using (var Db = new Student_DBEntities())
                {
                    Db.Student_Details_Sundram.Add(model);
                    await Db.SaveChangesAsync();
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

        public async static Task<bool> DeleteAsync(int ID)
        {
            using (var Db = new Student_DBEntities())
            {
                var removeQuery = Db.Student_Details_Sundram.Where(x => x.Student_ID == ID).FirstOrDefault();
                Db.Student_Details_Sundram.Remove(removeQuery);
                await Db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async static Task<Student_Details_Sundram> EditAsync(int ID)
        {
            using (var DB = new Student_DBEntities())
            {
                var Data = DB.Student_Details_Sundram.Where(x => x.Student_ID == ID).FirstOrDefaultAsync();
                return await Data;
            }
        }

        public async static Task<bool> EditAsync(Student_Details_Sundram model)
        {
            using (var DB = new Student_DBEntities())
            {
                var EditData = DB.Student_Details_Sundram.Where(x => x.Student_ID == model.Student_ID).FirstOrDefault();
                if (EditData != null)
                {
                    EditData.Student_Roll_Number = model.Student_Roll_Number;
                    EditData.Student_FirstName = model.Student_FirstName;
                    EditData.Student_LastName = model.Student_LastName;
                    EditData.Student_UniversityName = model.Student_UniversityName;
                    EditData.Student_MailId = model.Student_MailId;
                    EditData.Student_Preffered_ProgrammingLanguage = model.Student_Preffered_ProgrammingLanguage;
                    await DB.SaveChangesAsync();
                    return true;

                }
                else
                {
                    return false;
                }
            }
        }

        public async static Task<Login_SignUp_UserDetails> EditTeacherAsync(int ID)
        {
            using (var DB = new Student_DBEntities())
            {
                var Data = DB.Login_SignUp_UserDetails.Where(x => x.ID == ID).FirstOrDefaultAsync();
                return await Data;
            }
        }

        public async static Task<bool> EditTeacherAsync(Login_SignUp_UserDetails model)
        {
            using (var DB = new Student_DBEntities())
            {
                var EditData = DB.Login_SignUp_UserDetails.Where(x => x.ID == model.ID).FirstOrDefault();
                if (EditData != null)
                {
                    EditData.First_Name = model.First_Name;
                    EditData.Last_Name = model.Last_Name;
                    EditData.Gmail_Id = model.Gmail_Id;
                    EditData.PassWord = model.PassWord;
                    await DB.SaveChangesAsync();
                    return true;

                }
                else
                {
                    return false;
                }
            }
        }
        public async static Task<Student_Details_Sundram> GetDetailsAsync(int ID)
        {
            using (var DB = new Student_DBEntities())
            {
                var Data = DB.Student_Details_Sundram.Where(x => x.Student_ID == ID).FirstOrDefaultAsync();
                return await Data;
            }

        }

       

        public async static Task<bool> EditUserProfileAsync(ADMIN model)
        {
            using (var DB = new Student_DBEntities())
            {
                var Data = DB.ADMINs.Where(x => x.ADM_ID == model.ADM_ID).FirstOrDefault();
                if (Data != null)
                {
                    Data.ADM_Name = model.ADM_Name;
                    Data.ADM_Gmail = model.ADM_Gmail;
                    Data.ADM_UserName = model.ADM_UserName;
                    Data.ADM_Contact_Number = model.ADM_Contact_Number;
                    Data.ADM_Password = model.ADM_Password;
                    await DB.SaveChangesAsync();
                    return true;

                }
                else
                {
                    return false;
                }

            }
        }

        public async static Task<ADMIN> EditUserProfileAsync(int ID)
        {
            using (var DB = new Student_DBEntities())
            {
                var Data = DB.ADMINs.Where(x => x.ADM_ID== ID).FirstOrDefaultAsync();
                return await Data;
            }
        }

        public async static Task<ADMIN> LoginAdminAsync(ADMIN model)
        {
            using (var DB = new Student_DBEntities())
            {
                var Data = DB.ADMINs.Where(x => x.ADM_UserName == model.ADM_UserName && x.ADM_Password == model.ADM_Password).FirstOrDefaultAsync();
                return await Data;

            }
        }

        public async static Task<Login_SignUp_UserDetails> LoginTeacherAsync(Login_SignUp_UserDetails model)
        {
            using (var DB = new Student_DBEntities())
            {
                var Data = DB.Login_SignUp_UserDetails.Where(x => x.User_Name == model.User_Name && x.PassWord == model.PassWord).FirstOrDefaultAsync();
                return await Data;
            }
        }

        public async static Task<bool> RegisterAsync(Login_SignUp_UserDetails model)
        {
            using (var DB = new Student_DBEntities())
            {
                DB.Login_SignUp_UserDetails.Add(model);
                await DB.SaveChangesAsync();
                return true;
            }
        }

        public async static Task<Student_Details_Sundram> LoginStudentAsync(String Mail)
        {
            using (var DB = new Student_DBEntities())
            {
                var Data = DB.Student_Details_Sundram.Where(x => x.Student_MailId == Mail).FirstOrDefaultAsync();
                return await Data;
            }
        }

        public async static Task<Student_Details_Sundram> StudentDetailsAsync(int ID)
        {
            using (var DB = new Student_DBEntities())
            {
                var Data = DB.Student_Details_Sundram.Where(x => x.Student_ID == ID).FirstOrDefaultAsync();
                return await Data;
            }
        }

        public async static Task<bool> CreateTeacherAsync(Login_SignUp_UserDetails model)
        {
            if (model != null)
            {
                using (var Db = new Student_DBEntities())
                {
                    Db.Login_SignUp_UserDetails.Add(model);
                    await Db.SaveChangesAsync();
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

        public async static Task<Login_SignUp_UserDetails> DetailsTeacherAsync(int ID)
        {
            using (var DB = new Student_DBEntities())
            {
                var Data = DB.Login_SignUp_UserDetails.Where(x => x.ID == ID).FirstOrDefaultAsync();
                return await Data;
            }

        }

        public async static Task<bool> DeleteTeacherAsync(int ID)
        {
            using (var Db = new Student_DBEntities())
            {
                var removeQuery = Db.Login_SignUp_UserDetails.Where(x => x.ID == ID).FirstOrDefault();
                Db.Login_SignUp_UserDetails.Remove(removeQuery);
                await Db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async static Task<bool> UpdateStudentPassWord(Student_Details_Sundram model, String ID_value)
        {
            using (var DB = new Student_DBEntities())
            {
                int ID_value_Int = Int32.Parse(ID_value);
                var Data = DB.Student_Details_Sundram.Where(x => x.Student_ID == ID_value_Int).FirstOrDefault();
                if (Data != null)
                {
                    Data.Student_MailId = model.Student_MailId;
                    await DB.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}