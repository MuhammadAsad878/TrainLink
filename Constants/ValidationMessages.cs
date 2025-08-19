namespace TrainLink.Constants
{
    public static class ValidationMessages
    {
        // Username Messages
        public const string USERNAME_REQUIRED = "Username is required.";
        public const string USERNAME_LENGTH_SHORT = "Username must be at least 3 characters long.";
        public const string USERNAME_LENGTH_LONG = "Username must not exceed 20 characters.";
        public const string USERNAME_INVALID = "Username must start with letter can only contain letters, numbers, and underscores.";
        public const string USERNAME_ALREADY_EXISTS = "The username already exists. Please choose a different username.";

        // Password Messages
        public const string PASSWORD_REQUIRED = "Password is required.";
        public const string PASSWORD_TOO_SHORT = "Password must be at least 6 characters long.";
        public const string PASSWORD_TOO_LONG = "Password cannot be longer than 50 characters.";
        public const string PASSWORD_MUST_HAVE_UPPERCASE = "Password must contain at least one uppercase letter.";
        public const string PASSWORD_MUST_HAVE_LOWERCASE = "Password must contain at least one lowercase letter.";
        public const string PASSWORD_MUST_HAVE_DIGIT = "Password must contain at least one digit.";
        public const string PASSWORD_MUST_HAVE_SPECIAL_CHAR = "Password must contain at least one special character.";
        public const string PASSWORD_NOT_SAME = "Both Old and New Passwords are same";

        // Authentication / Login
        public const string INVALID_LOGIN_CREDENTIALS = "Invalid username or password.";
        public const string LOGIN_BAD_REQUEST = "Please Enter Complete Data.";
        public const string NOT_FOUND = "Not Found.";
        public const string LOGIN_FIRST = "Login First";
        public const string LOGOUT_SUCCESS = "Logout Successfully!";

        // Password Change
        public const string PASSWORD_CHANGE_SUCCESS = "Password Changed Successfully!";
        public const string PASSWORD_CHANGE_FAILED = "Password Not Changed!";

        // Meeting Slot Messages
        public const string MEETING_SLOT_REQUIRED = "Meeting slot data is required.";
        public const string MEETING_SLOT_NOT_FOUND = "Meeting slot not found.";
        public const string FAILED_TO_CREATE_MEETING_SLOT = "Failed to create meeting slot.";
        public const string FAILED_TO_UPDATE_MEETING_SLOT = "Failed to update meeting slot.";
        public const string FAILED_TO_DELETE_MEETING_SLOT = "Failed to delete meeting slot.";
        public const string MEETING_SLOT_DELETED_SUCCESSFULLY = "Meeting slot deleted successfully.";
        public const string MEETING_SLOT_UPDATED_SUCCESSFULLY = "Meeting slot updated successfully.";

        // Meeting Slot Specific
        public const string MEETING_SLOT_DATE_REQUIRED = "Meeting slot date is required.";
        public const string MEETING_SLOT_DATE_FUTURE = "Meeting slot date must be greater than the current date.";
        public const string CREATED_BY_REQUIRED = "CreatedBy is required.";
        public const string UPDATED_BY_REQUIRED = "UpdatedBy is required.";
        public const string SLOT_ID_REQUIRED = "SlotId is required.";
        public const string IS_ACTIVE_REQUIRED = "IsActive is required.";
        public const string MAX_LENGTH_EXCEEDED = "Maximum length exceeded for field.";
        public const string MEETING_SLOT_ID_INVALID = "SlotId must be a valid positive number.";
        public const string MUST_BE_POSITIVE = "Value must be a positive number.";
        public const string MEETING_SLOT_IS_ACTIVE_INVALID = "IsActive must be either 0 or 1.";
        public const string INVALID_MEETING_SLOT_ID = "Invalid Meeting Slot ID provided.";
        public const string SLOT_TIME_MUST_BE = "Slot time must be valid between 00:00:00 and 23:59:00 in 24 hr format.";
        public const string UNAUTHORIZED_USER = "Unauthorized user. Please log in to perform this action.";
        public const string SLOT_TIME_REQUIRED = "Slot time is required.";
    }
}
