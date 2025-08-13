namespace TrainLink.Constants
{
    public static class ValidationMessages
    {
        // Username Messages
        public const string UsernameRequired = "Username is required.";
        public static string UsernameLengthShort = $"Username must be at least {ValidationLengths.MinUsername} characters long.";
        public static string UsernameLengthLong = $"Username must not exceed {ValidationLengths.MaxUsername} characters.";
        public const string UsernameInvalid = $"Username Must start with letter can only contain letters, numbers, and underscores.";
        public const string UsernameAlreadyExists = "The username already exists. Please choose a different username.";

        // Password Messages
        public const string PasswordRequired = "Password is required.";
        public static string PasswordTooShort = $"Password must be at least {ValidationLengths.MinPassword} characters long.";
        public static string PasswordTooLong = $"Password cannot be longer than {ValidationLengths.MaxPassword} characters.";
        public const string PasswordMustHaveUppercase = "Password must contain at least one uppercase letter.";
        public const string PasswordMustHaveLowercase = "Password must contain at least one lowercase letter.";
        public const string PasswordMustHaveDigit = "Password must contain at least one digit.";
        public const string PasswordMustHaveSpecialChar = "Password must contain at least one special character.";
        public const string PasswordNotSame = "Both Old and New Passwords are same";

        // Authentication / Login
        public const string InvalidLoginCredentials = "Invalid username or password.";
        public const string LoginBadRequest = "Please Enter Complete Data.";
        public const string NotFound = "Not Found";
        public const string LoginFirst = "Login First";
        public const string LogoutSuccess = "Logout Successfully!";

        // Password Change
        public const string PasswordChangeSuccess = "Password Changed Successfully!";
        public const string PasswordChangeFailed = "Password Not Changed!";
    }
}
