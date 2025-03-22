using System.ComponentModel.DataAnnotations;

namespace MyPymeGames.API.DTOs
{
    // crear los usuarios 
    public class CreateUserDto
    {
       [Required]
       [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength =8)]

        public string Password { get; set;} = string.Empty;

    }
    // actualizar los usuarios
    public class UpdateUserDto
    {
        
        [StringLength(50, MinimumLength = 3)]
        public string? Username { get; set;}

        [EmailAddress]
        public string? Email { get; set;}

    }

    // respuestas de los usuarios 

    public class UserResponseDto
    {
        public int Id { get; set;}
        public string Username { get; set;} = string.Empty;
        public string Email { get; set;} = string.Empty;
        public DateTime CreatedAt { get; set;}
    }
}