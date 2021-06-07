namespace Mink.Services.Common
{
    public static class ServiceError
    {
        public static string InvalidUriFormat = "Unable to shorten that link. It is not a valid url.";
        public static string InvalidUriDomain = "Domain not allowed.";
        public static string InvalidUriType = "Uri not allowed.";
        public static string UriAlreadyTaken = "Uri already taken.";
        public static string UriKeyNotFound = "Uri not found.";
    }
}