using System.ComponentModel.DataAnnotations;

namespace GoParty.Web.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}