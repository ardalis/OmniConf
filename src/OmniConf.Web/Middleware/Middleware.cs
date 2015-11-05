using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using OmniConf.Core.Interfaces;

namespace OmniConf.Web.Middleware
{
    // You may need to install the Microsoft.AspNet.Http.Abstractions package into your project
    public class CurrentConferenceMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConferenceSelector _conferenceSelector;

        public CurrentConferenceMiddleware(RequestDelegate next,
            IConferenceSelector conferenceSelector)
        {
            _next = next;
            _conferenceSelector = conferenceSelector;
        }

        public Task Invoke(HttpContext httpContext)
        {
            int confId = _conferenceSelector.GetCurrentConference(DateTime.Now);
            httpContext.Items[SiteConstants.CurrentConferenceKey] = confId;
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CurrentConferenceMiddlewareExtensions
    {
        public static IApplicationBuilder UseCurrentConferenceMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CurrentConferenceMiddleware>();
        }
    }
}
