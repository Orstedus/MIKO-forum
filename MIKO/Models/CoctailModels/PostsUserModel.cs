using MIKO.Models.PostsModels;
using MIKO.Models.UserModels;

namespace MIKO.Models.CoctailModels
{
    public class PostsUserModel
    {
        public UserModel user { get; set; }
        public List<PostModel> posts { get; set; }
    }
}
