using System.ComponentModel.DataAnnotations;

namespace FoodCompany.DataTransferObjects
{
    public class UserDto
    {
        [Required, MinLength(3)]
        public string? Login {  get; set; }

        [Required, MinLength(3)]
        public string? Password { get; set; }

        public string? ReturnUrl { get; set; }

    }
}
