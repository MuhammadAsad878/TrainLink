namespace TrainLink.Constants
{
    public static class ValidationMessages
    {
        // Username Messages
        public const string USERNAME_REQUIRED = "Username is required.";
        public const string USERNAME_LENGTH_SHORT = "Username must be at least 3 characters long.";
        public const string USERNAME_LENGTH_LONG = "Username must not exceed 20 characters.";
        public const string USERNAME_INVALID = "Username must start with a letter and can only contain letters, numbers, and underscores.";
        public const string USERNAME_ALREADY_EXISTS = "The username already exists. Please choose a different username.";

        // Password Messages
        public const string PASSWORD_REQUIRED = "Password is required.";
        public const string PASSWORD_TOO_SHORT = "Password must be at least 6 characters long.";
        public const string PASSWORD_TOO_LONG = "Password cannot be longer than 50 characters.";
        public const string PASSWORD_MUST_HAVE_UPPERCASE = "Password must contain at least one uppercase letter.";
        public const string PASSWORD_MUST_HAVE_LOWERCASE = "Password must contain at least one lowercase letter.";
        public const string PASSWORD_MUST_HAVE_DIGIT = "Password must contain at least one digit.";
        public const string PASSWORD_MUST_HAVE_SPECIAL_CHAR = "Password must contain at least one special character.";
        public const string PASSWORD_INVALID = "Password must be at least 6 characters long, contain at least one uppercase letter, one lowercase letter, one digit, and one special character.";

        // Authentication / Login
        public const string INVALID_LOGIN_CREDENTIALS = "Invalid username or password.";
        public const string LOGIN_BAD_REQUEST = "Invalid login data.";
    }
}
