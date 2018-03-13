namespace HomePropertySystem.DataTransferModels.User
{
    using System.ComponentModel.DataAnnotations;

    public class UserLoginPostModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
