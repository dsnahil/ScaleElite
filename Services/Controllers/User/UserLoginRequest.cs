using System.ComponentModel.DataAnnotations;

namespace WebAPI
{
    // UserLoginRequest DTO
    public class UserLoginRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }

}
