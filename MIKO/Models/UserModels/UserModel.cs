using System.ComponentModel.DataAnnotations;

namespace MIKO.Models.UserModels
{
    public class UserModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Password { get; set; }

        public string Description { get; set; } = "No description yet...";
    }
}
