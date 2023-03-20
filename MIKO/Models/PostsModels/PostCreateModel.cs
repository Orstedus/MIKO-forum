using System.ComponentModel.DataAnnotations;

namespace MIKO.Models.PostsModels
{
    public class PostCreateModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Text { get; set; }
    }
}
