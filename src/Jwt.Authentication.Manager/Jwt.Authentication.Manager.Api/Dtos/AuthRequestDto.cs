using ServiceStack;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Jwt.Authentication.Manager.Api.Dtos
{
    public class AuthRequestDto
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "EncryptePassword is required")]
        public string EncryptedPassword { get; set; }
        public object? Claims { get; set; }
    }
}
