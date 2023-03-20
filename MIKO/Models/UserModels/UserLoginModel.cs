using System.ComponentModel.DataAnnotations;

namespace MIKO.Models.UserModels
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Password { get; set; }
    }
}
