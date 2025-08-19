namespace TrainLink.Constants
{
    public static class ApiRoutes
    {
        // login routes
        public const string LOGIN = "login";
        public const string CHANGE_PASSWORD = "change-password";
        public const string LOGOUT = "logout";



        public const string GET_SLOTS = "slot";
        public const string GET_SLOT_BY_ID = "slot/{id}";
        public const string POST_SLOT = "slot";
        public const string PUT_SLOT = "slot/{id}";
        public const string DELETE_SLOT = "slot/{slotId:int}";
    }
}
