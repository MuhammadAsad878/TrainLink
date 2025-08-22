namespace TrainLink.Constants
{
    public static class RegexPatterns
    {
        // Password must have at least one lowercase, one uppercase, one digit, one special char, and minimum length defined by PASSWORD_MIN_LENGTH
        public const string PASSWORD_PATTERN = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
        // Basic email format: must contain text before @, domain name, and TLD
        public const string EMAIL_PATTERN = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        // E.164 phone number format: optional +, followed by up to 15 digits (first digit non-zero)
        public const string PHONE_NUMBER_PATTERN = @"^\+?[1-9]\d{1,14}$";
        // Username must start with a letter, then allow letters, numbers, and underscores, between 3–20 characters long
        public const string USERNAME_PATTERN = @"^[a-zA-Z][a-zA-Z0-9_]{2,19}$";       
        // Must start with http, https, or ftp, followed by a valid domain (e.g., example.com), optional port, and optional path
        public const string VALID_URL = @"^(https?|ftp)://([a-zA-Z0-9\-]+\.)+[a-zA-Z]{2,}(:\d+)?(/.*)?$";
    }
}
