using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiniProgram.Host
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    /// Creator:HYK
    /// Create Time:2018/9/11 10:56
    [AuthFilter]
    public class BaseAPIController : ApiController
    {
    }
}
