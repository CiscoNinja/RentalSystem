using System.ComponentModel.DataAnnotations;

namespace RentalSystem.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}