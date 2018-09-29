using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MiniProgram.Host
{
    /// <summary>
    /// 在Action运行的前、后运行
    /// </summary>
    /// Creator:HYK
    /// Create Time:2018/9/11 9:29
    public class BaseActionController : ActionFilterAttribute
    {

        
        public override void OnActionExecuting(HttpActionContext actionContext)
        {

        }


    }
}
