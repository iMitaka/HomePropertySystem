namespace HomePropertySystem.Constants.User
{
    public static class UserMessages
    {
        private const string lockedAccount = "Account Is Locked!";
        private const string emailAlreadyExist = "The email is already taken!";
        private const string invalidLevel = "Invalid Level!";
        private const string invalidFavoriteMarket = "Invalid Favorite Market!";
        private const string invalidTypeTrading = "Invalid Type Trading!";
        private const string accountSuccessfullyCreate = "Account successfully created for user: ";
        private const string invalidLoginData = "Invalid Credentials!";
        private const string userNotExist = "The user does not exist!";
        private const string forbiddenDelete = "You can not delete another user!";
        private const string usernameAlreadyTaken = "The username is already taken!";
        private const string forbiddenModify = "You can not change another user!";
        private const string modifyUserError = "Error modify user!";
        private const string deleteUserError = "Error deleting user!";
        private const string searchParameterMissing = "The search parameter is missing!";
        private const string searchNotMatch = "Search does not match!";

        public static string LockedAccount()
        {
            return lockedAccount;
        }

        public static string EmailAlreadyExist()
        {
            return emailAlreadyExist;
        }

        public static string InvalidLevel()
        {
            return invalidLevel;
        }

        public static string InvalidFavoriteMarket()
        {
            return invalidFavoriteMarket;
        }

        public static string InvalidTypeTrading()
        {
            return invalidTypeTrading;
        }

        public static string AccountSuccessfullyCreate(string user)
        {
            return accountSuccessfullyCreate + user;
        }

        public static string InvalidLoginData()
        {
            return invalidLoginData;
        }

        public static string UserNotExist()
        {
            return userNotExist;
        }

        public static string ForbiddenDelete()
        {
            return forbiddenDelete;
        }

        public static string UsernameAlreadyTaken()
        {
            return usernameAlreadyTaken;
        }

        public static string ForbiddenModify()
        {
            return forbiddenModify;
        }

        public static string ModifyUserError()
        {
            return modifyUserError;
        }

        public static string DeleteUserError()
        {
            return deleteUserError;
        }

        public static string SearchParameterMissing()
        {
            return searchParameterMissing;
        }

        public static string SearchNotMatch()
        {
            return searchNotMatch;
        }
    }
}
