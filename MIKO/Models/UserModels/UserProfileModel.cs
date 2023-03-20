using System.ComponentModel.DataAnnotations;

namespace MIKO.Models.UserModels
{
    public class UserProfileModel
    {
        [Required(ErrorMessage = "Please enter all info")]
        [StringLength(12, MinimumLength = 3)]
        public string Login { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public string Description { get; set; } = "No description...";

        [Required(ErrorMessage = "Please enter all info")]
        [StringLength(15, MinimumLength = 5)]
        public string Password { get; set; }
    }
}
