using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Core.Extensions
{
    public static class HttpContextExtensions
    {

        public static T GetHeaderValueAs<T>(this HttpContext httpContext, string headerName)
        {
            StringValues values = new StringValues();

            if (httpContext?.Request?.Headers?.TryGetValue(headerName, out values) ?? false)
            {
                string rawValues = values.ToString();   // writes out as Csv when there are multiple.

                if (!string.IsNullOrWhiteSpace(rawValues))
                    return (T)Convert.ChangeType(values.ToString(), typeof(T));
            }
            return default(T);
        }
        public static string GetRefreshToken(this HttpContext httpContext)
        {
            return httpContext.GetHeaderValueAs<string>("RefreshToken");
        }
        public static string GetAcceptLanguage(this HttpContext httpContext)
        {
            return httpContext.GetHeaderValueAs<string>("Accept-Language");
        }

        public static string GetRecaptchaToken(this HttpContext httpContext)
        {
            return httpContext.GetHeaderValueAs<string>("RecaptchaToken");
        }
        public static string GetAuthorizationHeader(this HttpContext httpContext)
        {
            return httpContext.GetHeaderValueAs<string>("Authorization");
        }
        public static string GetAuthorizationToken(this HttpContext httpContext)
        {
            return httpContext.GetAuthorizationHeader()?.Replace("Bearer", "").Trim();
        }
    }
}
