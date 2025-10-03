namespace TrainLink.Constants
{
    public static class RegexPatterns
    {      
        // Regex: Requires at least one uppercase, one lowercase, one digit, one special character, minimum 6 characters, and no spaces
        public const string PASSWORD_PATTERN = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z\d\s])[^\s]{6,}$";
        // Basic email format: must contain text before @, domain name, and TLD
        public const string EMAIL_PATTERN = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        // E.164 phone number format: optional +, followed by up to 15 digits (first digit non-zero)
        public const string PHONE_NUMBER_PATTERN = @"^\+?[1-9]\d{1,14}$";
        // Username must start with a letter, then allow letters, numbers, and underscores, between 4–20 characters long
        public const string USERNAME_PATTERN = @"^[a-zA-Z][a-zA-Z0-9_]{3,19}$";
        // Must start with http, https, or ftp, followed by a valid domain (e.g., example.com), optional port, and optional path
        public const string VALID_URL = @"^(https?|ftp)://([a-zA-Z0-9\-]+\.)+[a-zA-Z]{2,}(:\d+)?(/.*)?$";
        // Mobile: must start with + or 0, followed by digits only, length between 11–15 digits
        public const string MOBILE_PATTERN = @"^(?:\+|0)[0-9]{10,14}$";
        /// Allows only alphabets (A–Z, a–z). No digits, spaces, or special characters.
        public const string AlphabetsOnlyRegex = "^[A-Za-z]+$";
    }
}
