namespace TrainLink.Constants
{
    public static class ApiRoutes
    {
        // Login routes
        public const string LOGIN = "login";
        public const string CHANGE_PASSWORD = "change-password";
        public const string LOGOUT = "logout";
        // Slot Routes
        public const string GET_SLOTS = "slot/{id:int?}";
        public const string POST_SLOT = "slot";
        public const string PUT_SLOT = "slot/{id:int}";
        public const string DELETE_SLOT = "slot/{id:int}";
        // Link Routes
        public const string GET_LINKS = "link/{id:int?}";
        public const string POST_LINK = "link";
        public const string PUT_LINK = "link/{id:int}";
        public const string DELETE_LINK = "link/{id:int}";
        // User Routes
        public const string GET_USERS = "user/{id:int?}";               
        public const string POST_USER = "user";               
        public const string PUT_USER = "user/{id}";           
        public const string DELETE_USER = "user/{id}";                
        // Role Routes
        public const string GET_ROLES = "role";               
        public const string POST_ROLE = "role";               
        public const string PUT_ROLE = "role/{id}";         
        public const string DELETE_ROLE = "role/{id}";

    }
}
