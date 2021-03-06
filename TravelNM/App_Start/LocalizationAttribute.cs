﻿using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace TravelNM.App_Start
{
    public class LocalizationAttribute : ActionFilterAttribute
    {
        private string _DefaultLanguage = "en";

        public LocalizationAttribute(string defaultLanguage)
        {
            _DefaultLanguage = defaultLanguage;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string lang = (string)filterContext.RouteData.Values["lang"] ?? _DefaultLanguage;
            if (lang != _DefaultLanguage)
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(lang);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
                }
                catch
                {
                    throw new NotSupportedException(String.Format("ERROR: Invalid language code '{0}'.", lang));
                }
            }
        }
    }
}