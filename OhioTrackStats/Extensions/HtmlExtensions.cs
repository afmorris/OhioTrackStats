// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlExtensions.cs" company="OhioTrackStats.com">
//   Copyright (c) 2017-2017 OhioTrackStats.com.
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OhioTrackStats.Extensions
{
    using System;
    using System.Web.Mvc;

    /// <summary>
    /// Extensions to be used in Razor markup.
    /// </summary>
    public static class HtmlExtensions
    {
        /// <summary>
        /// Generates a header link with the correct classes.
        /// </summary>
        /// <param name="url">The URL Helper from the Razor engine</param>
        /// <param name="text">The text of the link</param>
        /// <param name="action">The action of the link</param>
        /// <param name="controller">The controller for the link</param>
        /// <returns>
        /// The correctly formatted anchor link
        /// </returns>
        public static MvcHtmlString HeaderLink(this UrlHelper url, string text, string action, string controller)
        {
            var context = url.RequestContext;
            var routeValues = context.RouteData.Values;
            var currentAction = routeValues["action"].ToString();
            var currentController = routeValues["controller"].ToString();
            var activeClass = currentAction.Equals(action, StringComparison.InvariantCultureIgnoreCase) && currentController.Equals(controller, StringComparison.InvariantCultureIgnoreCase) ? " active" : string.Empty;
            var output = $"<a class=\"nav-link{activeClass}\" href=\"{url.Action(action, controller)}\">{text}</a>";
            return new MvcHtmlString(output);
        }
    }
}