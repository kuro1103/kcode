using Amazon.Runtime.Internal;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace RestaurantMaker.App_Start
{
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務
            //config.Filters.Add(new RequestActionFilterAttribute());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            // 移除XML格式輸出
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // 對 JSON 資料使用 CamelCase，但是 JaveScript 首字母使用小寫。
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            // Exceptionless
            //ExceptionlessClient.Default.Configuration.UseTraceLogger();
            //ExceptionlessClient.Default.Configuration.UseReferenceIds();
            //ExceptionlessClient.Default.RegisterWebApi(config);

            // 置換錯誤攔截器
            //config.Services.Replace(typeof(IExceptionHandler), new ErrorHandler());
        }
    }
}