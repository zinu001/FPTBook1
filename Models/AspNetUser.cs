using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FPTLibrary.Models
{
    public class AspNetUser : IdentityUser
    {
        [Required(ErrorMessage = "This field cannot be empty!")]
        [MinLength(2, ErrorMessage = "The name length must be longer than 2!")]
        [MaxLength(50, ErrorMessage = "The name length exceed maximum required characters!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field cannot be empty!")]
        [Url]
        public string Image { get; set; }
        public string Roles { get; set; }
    }
}
