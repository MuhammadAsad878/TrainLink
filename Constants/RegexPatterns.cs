namespace TrainLink.Constants
{
    public static class RegexPatterns
    {
        public static string PASSWORD_PATTERN = $@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{{{ValidationLengths.PASSWORD_MIN_LENGTH},}}$";
        public const string EMAIL_PATTERN = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        public const string PHONE_NUMBER_PATTERN = @"^\+?[1-9]\d{1,14}$";
        public static string USERNAME_PATTERN = $@"^[a-zA-Z][a-zA-Z0-9_]{{{ValidationLengths.USERNAME_MIN_LENGTH-1},{ValidationLengths.USERNAME_MAX_LENGTH-1}}}$";

        public const string PASSWORD_UPPERCASE = @"[A-Z]";
        public const string PASSWORD_LOWERCASE = @"[a-z]";
        public const string PASSWORD_DIGIT = @"\d";
        public const string PASSWORD_SPECIAL_CHAR = @"[@$!%*?&]";
    }
}
