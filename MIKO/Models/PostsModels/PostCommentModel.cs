namespace MIKO.Models.PostsModels
{
    public class PostCommentModel
    {
        public int Id { get; set; }
        public int parentId { get; set; }
        public string AuthorLogin { get; set; }
        public int AuthorId { get; set; }
        public string Text { get; set; }
    }
}
