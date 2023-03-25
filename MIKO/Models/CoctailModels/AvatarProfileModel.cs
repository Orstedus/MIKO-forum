using MIKO.Models.UserModels;
using System.ComponentModel.DataAnnotations;

namespace MIKO.Models.CoctailModels
{
    public class AvatarProfileModel
    {
        public string Login { get; set; }
        public string Description { get; set; } = "No description...";
        public string Password { get; set; }

        public IFormFile Avatar { get; set; }
    }
}
