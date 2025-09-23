namespace TrainLink.Constants
{
    public static class ValidationMessages
    {
        // General Messages
        public const string ID_REQUIRED = "Id is required.";
        public const string ID_NOT_FOUND = "Id not found.";
        public const string ID_INVALID = "Id must be a valid positive number.";
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
        public const string PASSWORD_MUST_BE = "Password must be at least 6 characters long, contain at least one uppercase letter, one lowercase letter, one digit, and one special character.";
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
        public const string INVALID_MEETING_SLOT_ID = "Invalid Meeting Slot ID provided. It Must be positive integer";
        public const string SLOT_TIME_MUST_BE_LESS = "Slot time must be less than 23:59:00 in 24 hr format.";
        public const string SLOT_TIME_MUST_BE_GREATER = "Slot time must be greater than 00:00:00 in 24 hr format.";
        public const string UNAUTHORIZED_USER = "Unauthorized user. Please log in to perform this action.";
        public const string SLOT_TIME_REQUIRED = "Slot time is required.";
        // Meeting Link Messages
        public const string MEETING_LINK_REQUIRED = "Meeting link data is required.";
        public const string MEETING_LINK_NOT_FOUND = "Meeting link not found.";
        public const string FAILED_TO_CREATE_MEETING_LINK = "Failed to create meeting link.";
        public const string FAILED_TO_UPDATE_MEETING_LINK = "Failed to update meeting link.";
        public const string FAILED_TO_DELETE_MEETING_LINK = "Failed to delete meeting link.";
        public const string MEETING_LINK_DELETED_SUCCESSFULLY = "Meeting link deleted successfully.";
        public const string MEETING_LINK_UPDATED_SUCCESSFULLY = "Meeting link updated successfully.";
        public const string MEETING_LINK_ID_INVALID = "Meeting Link ID must be a valid positive number.";
        public const string MEETING_URL_REQUIRED = "Meeting URL is required.";
        public const string MEETING_URL_INVALID = "Meeting URL is not valid. Please provide a valid URL.";
        // =====================
        // USER MESSAGES
        // =====================
        public const string USER_REQUIRED = "User data is required.";
        public const string USER_NOT_FOUND = "User not found.";
        public const string USER_CREATED_SUCCESSFULLY = "User created successfully.";
        public const string USER_CREATION_FAILED = "Failed to create user.";
        public const string USER_UPDATED_SUCCESSFULLY = "User updated successfully.";
        public const string USER_UPDATE_FAILED = "Failed to update user.";
        public const string USER_DELETED_SUCCESSFULLY = "User deleted successfully.";
        public const string USER_DELETE_FAILED = "Failed to delete user.";
        public const string INVALID_USER_ID = "Invalid User ID provided. It must be a positive integer.";
        public const string USER_PASSWORD_CHANGE_SUCCESS = "Password changed successfully.";
        public const string USER_PASSWORD_CHANGE_FAILED = "Failed to change password.";
        // =====================
        // ROLE MESSAGES
        // =====================
        public const string ROLE_REQUIRED = "Role name is required and must be alphabet";
        public const string ROLE_NOT_FOUND = "Role not found.";
        public const string ROLE_ALREADY_EXISTS = "Role with this name already exists.";
        public const string ROLE_CREATED_SUCCESSFULLY = "Role created successfully.";
        public const string ROLE_CREATION_FAILED = "Failed to create role.";
        public const string ROLE_UPDATED_SUCCESSFULLY = "Role updated successfully.";
        public const string ROLE_UPDATE_FAILED = "Failed to update role.";
        public const string ROLE_DELETED_SUCCESSFULLY = "Role deleted successfully.";
        public const string ROLE_DELETE_FAILED = "Failed to delete role.";
        public const string INVALID_ROLE_ID = "Invalid Role ID provided. It must be a positive integer.";
        public const string ROLE_NAME_INVALID = "Role name must contain only alphabets (A–Z).";



        public const string NAME_REQUIRED = "Name is required.";
        public const string NAME_LENGTH_LONG = "Name is too long.";

        public const string MOBILE_REQUIRED = "Mobile number is required.";
        public const string MOBILE_INVALID = "Mobile number format is invalid.";


        public const string MEMBERSHIP_EXPIRY_INVALID = "Membership expiry must be a future date.";
    }
}
