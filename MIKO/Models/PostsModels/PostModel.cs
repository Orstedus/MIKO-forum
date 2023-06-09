﻿using System.ComponentModel.DataAnnotations;

namespace MIKO.Models.PostsModels
{

    public class PostModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Text { get; set; }

        public int AuthorId { get; set; }
        public int parentId { get; set; }

        public string AuthorLogin { get; set; }

        public List<PostCommentModel?> Comments { get; set; } = new List<PostCommentModel?>();
    }
}
