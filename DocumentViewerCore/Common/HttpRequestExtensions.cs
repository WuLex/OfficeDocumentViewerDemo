using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace DocumentViewerCore.Common
{

    public static class HttpRequestExtensions
    {
        public static bool IsPostBack(this HttpRequest request)
        {
            var currentUrl = UriHelper.BuildAbsolute(request.Scheme, request.Host, request.PathBase, request.Path, request.QueryString);
            var referrer = request.Headers["Referer"].FirstOrDefault();

            bool isPost = string.Compare(request.Method, "POST", StringComparison.CurrentCultureIgnoreCase) == 0;
            if (referrer == null)
            {
                return false;
            }

            bool isSameUrl = string.Compare(currentUrl, referrer, StringComparison.CurrentCultureIgnoreCase) == 0;

            return isPost && isSameUrl;
        }
    }

}
