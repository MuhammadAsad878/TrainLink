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
        // Meeting Slot Messages
        public const string MeetingSlotRequired = "Meeting slot data is required.";
        public const string MeetingSlotNotFound = "Meeting slot not found.";
        public const string FailedToCreateMeetingSlot = "Failed to create meeting slot.";
        public const string FailedToUpdateMeetingSlot = "Failed to update meeting slot.";
        public const string FailedToDeleteMeetingSlot = "Failed to delete meeting slot.";
        public const string MeetingSlotDeletedSuccessfully = "Meeting slot deleted successfully.";
        public const string MeetingSlotUpdatedSuccessfully = "Meeting slot updated successfully.";
        // Meeting Slot Specific
        public const string MeetingSlotDateRequired = "Meeting slot date is required.";
        public const string MeetingSlotDateFuture = "Meeting slot date must be greater than the current date.";
        public const string CreatedByRequired = "CreatedBy is required.";
        public const string UpdatedByRequired = "UpdatedBy is required.";
        public const string SlotIdRequired = "SlotId is required.";
        public const string IsActiveRequired = "IsActive is required.";
        public const string MaxLengthExceeded = "Maximum length exceeded for field.";
        public const string MeetingSlotIdInvalid = "SlotId must be a valid positive number.";
        public const string MustBePositive = "Value must be a positive number.";
        public const string MeetingSlotIsActiveInvalid = "IsActive must be either 0 or 1.";

    }
}
