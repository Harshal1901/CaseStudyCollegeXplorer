using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseStudyClgXplorer.Models
{
    public class User
    {
        [Key]
        public int UserId{ get; set; }

        
        [Display(Name ="Username ")]
        [Required(ErrorMessage = "Required Username ")]
        public string Username { get; set; }

     
        [Display(Name ="Password ")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password is Required")]
        public string Password { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }

        [Required(ErrorMessage ="Email is Required ")]
        [Display (Name ="Email Id")]
        [DataType (DataType.EmailAddress,ErrorMessage ="Email is not Valid")]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Mobile ")]
        public string Mobile { get; set; }
    }
}