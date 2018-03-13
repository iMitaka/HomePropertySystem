using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HomePropertySystem.Constants.User;
using HomePropertySystem.Data.Repositories;
using HomePropertySystem.DataTransferModels;
using HomePropertySystem.DataTransferModels.User;
using HomePropertySystem.Helpers.Jwt;
using HomePropertySystem.ServiceInterfaces;
using Microsoft.AspNetCore.Identity;

namespace HomePropertySystem.Services
{
    public class UserService : IUserService
    {
        private const int tokenExpiryMinutes = 60;
        private const int passwordMinimumLenght = 4;

        private readonly IUowData data;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IFileService fileService;

        public UserService(IUowData data,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            FileService fileService)
        {
            this.data = data;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.fileService = fileService;
        }

        public async Task<ServiceResultModel<JwtToken>> LoginUser(UserLoginPostModel model)
        {
            var result = new ServiceResultModel<JwtToken>();

            var loginResult = await signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: false);
            if (loginResult.Succeeded)
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if (!user.Deleted)
                {
                    result.DataResult = GenerateTokenForUser(user.UserName);
                }
                else
                {
                    result.Error = true;
                    result.ErrorMessage = UserMessages.InvalidLoginData();
                }

            }
            else if (loginResult.IsLockedOut)
            {
                result.Error = true;
                result.ErrorMessage = UserMessages.LockedAccount();
            }
            else
            {
                result.Error = true;
                result.ErrorMessage = UserMessages.InvalidLoginData();
            }

            return result;
        }

        public async Task<ServiceResultModel<bool>> RegisterUser(UserRegisterPostModel model, string currentUserUsername)
        {

            var result = new ServiceResultModel<bool>();

            var errorMessage = ValidateUserData(model.Email, model.Username, currentUserUsername);

            if (errorMessage != null)
            {
                result.Error = true;
                result.ErrorMessage = errorMessage;
            }
            else
            {
                var user = new ApplicationUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    CreatedAt = DateTime.Now,
                    Avatar = model.AvatarFile == null ? null : await fileService.GenerateFile(model.AvatarFile, model.Username, null),
                };

                var registerResult = await userManager.CreateAsync(user, model.Password);
                if (registerResult.Succeeded)
                {
                    result.DataResult = true;
                    result.SuccessMessage = UserMessages.AccountSuccessfullyCreate(model.Username);
                }
            }

            return result;
        }

        private JwtToken GenerateTokenForUser(string username)
        {
            return new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create(JwtConstants.GetSigningKey()))
                                .AddSubject(username)
                                .AddIssuer(JwtConstants.GetIssuer())
                                .AddAudience(JwtConstants.GetAudience())
                                .AddClaim(ClaimTypes.Name, username)
                                .AddExpiry(tokenExpiryMinutes)
                                .Build();
        }

        private string ValidateUserData(string email, string username, string currentUserUsername)
        {
            if (email != null && email.Length >= 1 && CheckForExistingEmailorUsername(email, username, currentUserUsername))
            {
                return UserMessages.EmailAlreadyExist();
            }

            return null;
        }

        private bool CheckForExistingEmailorUsername(string email, string username, string currentUserUsername)
        {
            var result = data.ApplicationUsers.All().Any(x => (x.Email.ToLower() == email.ToLower() || x.UserName.ToLower() == username.ToLower()) && !x.Deleted);
            if (currentUserUsername != null)
            {
                result = data.ApplicationUsers.All().Any(x => (x.Email.ToLower() == email.ToLower() || x.UserName.ToLower() == username.ToLower()) && x.UserName != currentUserUsername && !x.Deleted);
            }
            return result;
        }
    }
}
