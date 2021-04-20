using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Milenium.Managers
{
    public class LocalizationManager
    {
         private const string CookieKey = "language";

        public void SetSelectedCultureInfo(HttpContextBase httpContext)
        {
            var cookie = httpContext.Request.Cookies.Get(CookieKey);
            string cultureType = string.Empty;
            if(cookie == null || string.IsNullOrEmpty(cookie.Value))
            {
                httpContext.Response.Cookies.Add(new HttpCookie(CookieKey,"pl-PL"));
                return;
            }
            else
            {
                cultureType = cookie.Value;
            }

            if(ValidateCultureType(cultureType))
            {
                ChangeCurrentCulutre(cultureType);
            }
            
            httpContext.Request.Cookies.Clear();
            httpContext.Response.Cookies.Clear();

            var responseCookie = new HttpCookie(CookieKey,cultureType);
            responseCookie.Path = "/";

            httpContext.Response.Cookies.Add(responseCookie);
        }

        private bool ValidateCultureType(string cultureType)
        {
            try
            {
                CultureInfo.GetCultureInfo(cultureType);
                return true;
            }
            catch(CultureNotFoundException)
            {
                return false;
            }
        }

        private void ChangeCurrentCulutre(string cultureType)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name;

            if(currentCulture != cultureType)
            {
                var targetCultureInfo = new CultureInfo(cultureType);
                CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureType);
                CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureType);
                CultureInfo.DefaultThreadCurrentCulture = targetCultureInfo;
                CultureInfo.DefaultThreadCurrentUICulture = targetCultureInfo;
            }
        }
    }
}