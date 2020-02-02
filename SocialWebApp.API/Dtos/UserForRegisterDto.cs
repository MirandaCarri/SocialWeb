using System.ComponentModel.DataAnnotations;

namespace SocialWebApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8,MinimumLength = 4, ErrorMessage = "You must have 4-8 chars.")]        
        public string  Password { get; set; }
    }
}