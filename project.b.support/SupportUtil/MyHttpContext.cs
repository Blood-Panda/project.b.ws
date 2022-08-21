using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace project.b.support.SupportUtil
{
    public static class MyHttpContext
    {
        private static IHttpContextAccessor _httpContextAccessor;
        public static HttpContext Current => _httpContextAccessor.HttpContext;

        internal static void Configure(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }

        /// <summary>
        /// Para obtener la Ip del usuario que usa la aplciación
        /// </summary>
        /// <returns>IP</returns>
        public static string ObtenerIpAddress()
        {
            Configure(new HttpContextAccessor());
            string ipAddress = _httpContextAccessor.HttpContext.Request.Headers["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            }

            return ipAddress;
        }

        /// <summary>
        /// MAC del dispositivo del usuario desde donde se accede a la aplicación
        /// </summary>
        /// <returns>Mac</returns>
        public static string ObtenerMac()
        {
            string mac = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    mac = nic.GetPhysicalAddress().ToString();
                    mac = Regex.Replace(mac, "(.{2})(.{2})(.{2})(.{2})(.{2})(.{2})", "$1:$2:$3:$4:$5:$6"); ;
                }
            }
            return mac.Trim();
        }

        public static string ObtenerPathMetodo()
        {
            Configure(new HttpContextAccessor());
            var url = _httpContextAccessor.HttpContext.Request.Path.ToUriComponent();
            string[] split = url.Split(Path.AltDirectorySeparatorChar);

            var path = "~" + Path.AltDirectorySeparatorChar + split[1] + Path.AltDirectorySeparatorChar + split[2] + Path.AltDirectorySeparatorChar + split[3];

            return path;
        }


    }
}
