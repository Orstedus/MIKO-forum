using System.ComponentModel.DataAnnotations;

namespace MIKO.Models.UserModels
{
    public class UserProfileModel
    {
        [Required(ErrorMessage = "Please enter all info")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Please enter all info")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter all info")]
        public string Password { get; set; }
    }
}
