using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{

    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            LinkHubDbEntities db = new LinkHubDbEntities();
            string userEmail = value.ToString();
            int count = db.tbl_User.Where(x => x.UserEmail == userEmail).ToList().Count();
            if (count != 0)
                return new ValidationResult("UserEmail Already Exists.");
            return ValidationResult.Success;
        }
    }

    public class tbl_UserValidation 
    {
        [Required]
        [EmailAddress]
        [UniqueEmail]
        public string UserEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }

    [MetadataType(typeof(tbl_UserValidation))]
    public partial class tbl_User
    { }
}
