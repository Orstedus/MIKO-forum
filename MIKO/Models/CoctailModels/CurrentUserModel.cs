using MIKO.Models.UserModels;

namespace MIKO.Models.CoctailModels
{
    public class CurrentUserModel
    {
        public static UserModel CurrentUser { get; set; } = new UserModel()
        {
            Login = "Guest",
            Id = 0,
            Email = " ",
            Password = " ",
            Description = "No description yet..."
        };
    }
}
