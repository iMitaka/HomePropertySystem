namespace HomePropertySystem.ServiceInterfaces
{
    using HomePropertySystem.DataTransferModels;
    using HomePropertySystem.DataTransferModels.User;
    using HomePropertySystem.Helpers.Jwt;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<ServiceResultModel<JwtToken>> LoginUser(UserLoginPostModel model);
        Task<ServiceResultModel<bool>> RegisterUser(UserRegisterPostModel model, string currentUserUsername);
        //Task<ServiceResultModel<bool>> DeleteUser(string id);
        //Task<ServiceResultModel<UserModifyPostModel>> ModifyUser(UserModifyPostModel model, string id);
        //ServiceResultModel<UserGetDataModel> GetUserData(string username, string currentUserUsername, ApplicationUser currentUser, ApplicationUser otherUser);
        //ServiceResultModel<List<UserGetDataModel>> SearchForUsers(string searchParameter, string currentUserUsername);
        //Task<bool> LogoutUser();

        //UsersGetModel GetAllUsers(int pageNumber, string searchText, int itemsPerPage);
        //Task<ServiceResultModel<UserGetDataModel>> GetUserDetails(string id);
        //UsersGetModel GetUsersByIds(string ids);
        //ServiceResultModel<List<EventViewModel>> GetUserEvents(string userId, DateTime? fromDate, DateTime? toDate);
    }
}
