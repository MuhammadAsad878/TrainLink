namespace TrainLink.Constants
{
    public class RegexPatterns
    {
        public static string PasswordPattern = $@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{{{ValidationLengths.MinPassword},}}$";
        public const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; 
        public const string PhoneNumberPattern = @"^\+?[1-9]\d{1,14}$";
        public static string UsernamePattern =  $@"^[a-zA-Z][a-zA-Z0-9_]{{{ValidationLengths.MinUsername-1},{ValidationLengths.MaxUsername-1}}}$";

        public const string PasswordUppercase = @"[A-Z]";
        public const string PasswordLowercase = @"[a-z]";
        public const string PasswordDigit = @"\d";
        public const string PasswordSpecialChar = @"[@$!%*?&]";
    }
}
