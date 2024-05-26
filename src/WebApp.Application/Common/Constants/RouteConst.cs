namespace WebApp.Application.Common.Constants;

public struct RouteConst
{
    public const string Default = "/";

    public struct Identity
    {
        public const string SignIn = "sign-in";
        public const string Register = "register";
        public const string UnAuthorised = "unauthorised";
    }

    public struct Dashboard
    {
        public const string User = "user";
        public const string Admin = "admin";
    }
}

public struct PageConst
{
    public struct Title
    {
        public const string Index = "Index";
        public const string SignIn = "Sign-in";
        public const string Register = "Register";
        public const string UnAuthorised = "403 - UnAuthorised";

        public struct Dashboard
        {
            public const string User = "User Dashboard";
            public const string Admin = "Admin Dashboard";
        }
    }
}
