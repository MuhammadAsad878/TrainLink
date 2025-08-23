namespace TrainLink.Constants
{
    public static class RegexPatterns
    {
        // Password must contain atlease one uppercase, one lowercase, one digit, one special character MinLength 6
        public const string PASSWORD_PATTERN = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$";
        // Email must follow standard format: local@domain.extension all parts local, domain, extension dont have spaces or @
        public const string EMAIL_PATTERN = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        // Username must: Start with a letter, contain only letters, numbers, underscores and between 3-20 characters long
        public const string USERNAME_PATTERN = @"^[a-zA-Z][a-zA-Z0-9_]{2,19}$";
    }
}
