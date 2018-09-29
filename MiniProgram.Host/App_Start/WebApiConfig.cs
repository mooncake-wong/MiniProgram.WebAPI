using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MiniProgram.Host
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //注册全局Filter
            config.Filters.Add(new AuthFilterAttribute());

            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
