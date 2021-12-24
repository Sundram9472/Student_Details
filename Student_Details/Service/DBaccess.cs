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
        

        public async static Task<bool> CreateAsync(Student_Details_Sundram model)
        {
          if(model != null)
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
        
        public async static Task<bool>  DeleteAsync(int ID)
        {
                using(var Db = new Student_DBEntities())
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
           using(var DB = new Student_DBEntities())
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
        public async static Task<Student_Details_Sundram> GetDetailsAsync(int ID)
        {
           using (var DB = new Student_DBEntities())
           {
                var Data= DB.Student_Details_Sundram.Where(x => x.Student_ID == ID).FirstOrDefaultAsync();
                return await Data;
           }
            
        }

            public async static Task<bool> UpdatePassWord(Login_SignUp_UserDetails model,String ID_value)
            {
                using (var DB = new Student_DBEntities())
                {
                    int ID_value_Int = Int32.Parse(ID_value);
                    var Data = DB.Login_SignUp_UserDetails.Where(x => x.ID == ID_value_Int).FirstOrDefault();
                        if(Data != null)
                        {
                            Data.PassWord = model.PassWord;
                            await DB.SaveChangesAsync();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                }
            }

        public async static Task<bool> EditUserProfileAsync(Login_SignUp_UserDetails model)
        {
            using (var DB = new Student_DBEntities())
            {
                var Data = DB.Login_SignUp_UserDetails.Where(x => x.ID == model.ID).FirstOrDefault();
                  if(Data != null)
                  {
                    Data.First_Name = model.First_Name;
                    Data.Last_Name = model.Last_Name;
                    Data.Gmail_Id = model.Gmail_Id;
                    Data.User_Name = model.User_Name;
                    await DB.SaveChangesAsync();
                    return true;

                  }
                else
                {
                    return false;
                }

            }
        }

        public async static Task<Login_SignUp_UserDetails> EditUserProfileAsync(int ID)
        {
            using (var DB = new Student_DBEntities())
            {
                var Data = DB.Login_SignUp_UserDetails.Where(x => x.ID == ID).FirstOrDefaultAsync();
                return await Data;
            }
        }

        public async static Task<Login_SignUp_UserDetails> LoginAsync(Login_SignUp_UserDetails model)
        {
            using (var DB = new Student_DBEntities ())
            {
                var Data = DB.Login_SignUp_UserDetails.Where(x => x.User_Name == model.User_Name && x.PassWord == model.PassWord).FirstOrDefaultAsync();
                return await Data;

            }
        }

        public async static Task<bool> RegisterAsync(Login_SignUp_UserDetails model)
        {
            using (var DB = new Student_DBEntities ())
            {
                DB.Login_SignUp_UserDetails.Add(model);
                await DB.SaveChangesAsync();
                return true;
            }
        }

        
    }
}