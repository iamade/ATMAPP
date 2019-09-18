using System.ComponentModel.DataAnnotations;

namespace AtmApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "You must specify password between 4 and 10 characters")]
        public string Password { get; set; }
    }
}