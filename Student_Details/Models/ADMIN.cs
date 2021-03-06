//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Student_Details.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    public partial class ADMIN
    {
        public int ADM_ID { get; set; }

        [Required(ErrorMessage ="Name Required !")]
        public string ADM_Name { get; set; }

        [Required(ErrorMessage = "Contact Required !")]
        public string ADM_Contact_Number { get; set; }

        [Required(ErrorMessage = "Gmail Required !")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        public string ADM_Gmail { get; set; }

        [Required(ErrorMessage ="UserName Required!")]
        public string ADM_UserName { get; set; }

        [Required(ErrorMessage = "PassWord Required!")]
        public string ADM_Password { get; set; }
    }
}
