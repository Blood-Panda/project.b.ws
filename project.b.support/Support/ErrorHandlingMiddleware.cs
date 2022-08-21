using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.b.support.Support
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using project.b.support.SupportDto;
    using project.b.support.SupportUtil;
    //using project.b.SupportDto;
    //using osiptel_sigep_support.SupportUtil;
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    public class ErrorHandlingMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, System.Exception ex, ILogger logger)
        {
            var respuesta = new Response();
            String mensaje;
            if (ex is CustomException)
            {
                mensaje = ex.Message;
            }
            else
            {
                mensaje = Message.datosIncompletos;
            }
            respuesta.Mensaje = mensaje;
            respuesta.MensajeDev = ex.Message + " " + ex?.InnerException?.Message;

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var result = JsonConvert.SerializeObject(respuesta, jsonSerializerSettings);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return context.Response.WriteAsync(result);
        }
        private static void getInfo(Exception e, ILogger logger)
        {
            MethodBase site = e.TargetSite;//Get the methodname from the exception.
            string methodName = site == null ? "" : site.Name;//avoid null ref if it's null.
            methodName = ExtractBracketed(methodName);

            StackTrace stkTrace = new System.Diagnostics.StackTrace(e, true);
            for (int i = 0; i < 3; i++)
            {
                //In most cases GetFrame(0) will contain valid information, but not always. That's why a small loop is needed. 
                var frame = stkTrace.GetFrame(i);
                int lineNum = frame.GetFileLineNumber();//get the line and column numbers
                int colNum = frame.GetFileColumnNumber();
                string className = ExtractBracketed(frame.GetMethod().ReflectedType.FullName);
                var log = ThreadAndDateInfo + "Exception: " + className + "." + methodName + ", Ln " + lineNum + " Col " + colNum + ": " + e.Message + " " + e?.InnerException?.Message;
                //Trace.WriteLine(ThreadAndDateInfo + "Exception: " + className + "." + methodName + ", Ln " + lineNum + " Col " + colNum + ": " + e.Message);
                logger.LogError(log);
                if (lineNum + colNum > 0)
                    break; //exit the for loop if you have valid info. If not, try going up one frame...
            }
        }
        private static string ExtractBracketed(string str)
        {
            string s;
            if (str.IndexOf('<') > -1) //using the Regex when the string does not contain <brackets> returns an empty string.
                s = Regex.Match(str, @"\<([^>]*)\>").Groups[1].Value;
            else
                s = str;
            if (s == "")
                return "'Emtpy'"; //for log visibility we want to know if something it's empty.
            else
                return s;

        }

        public static string ThreadAndDateInfo
        {
            //returns thread number and precise date and time.
            get { return "[" + DateTime.Now.ToString("dd/MM HH:mm:ss") + "  thread: " + Thread.CurrentThread.ManagedThreadId + "] "; }
        }
    }
}
