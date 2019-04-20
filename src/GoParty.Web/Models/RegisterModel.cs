using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GoParty.Business.Contract.Geography.Models;
using GoParty.Business.Contract.UserContacts.Models;

namespace GoParty.Web.Models
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public Location Location { get; set; }

        public string Image { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}