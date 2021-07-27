using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentViewerCore.Common
{
    public class HttpContextHelper
    {
        private static Microsoft.AspNetCore.Http.IHttpContextAccessor m_httpContextAccessor;
        private static IWebHostEnvironment _wevHostEnviroment;
        public static string WebPath => _wevHostEnviroment.WebRootPath;

      
        public static void Configure(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
        {
            m_httpContextAccessor = httpContextAccessor;
        }

        public static void Configure(IWebHostEnvironment webhostEnviroment)
        {
            _wevHostEnviroment = webhostEnviroment;
        }

        public static Microsoft.AspNetCore.Http.HttpContext Current
        {
            get
            {
                return m_httpContextAccessor.HttpContext;
            }
        }

        public static string MapPath(string path)
        {
            return Path.Combine(_wevHostEnviroment.WebRootPath, path);
        }


    }
}
