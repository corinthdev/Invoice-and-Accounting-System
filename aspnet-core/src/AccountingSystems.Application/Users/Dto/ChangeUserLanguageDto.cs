using System.ComponentModel.DataAnnotations;

namespace AccountingSystems.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}