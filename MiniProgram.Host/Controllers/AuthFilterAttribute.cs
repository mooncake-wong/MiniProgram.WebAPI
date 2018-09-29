using MiniProgram.BLL;
using MiniProgram.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MiniProgram.Host
{
    /// <summary>
    /// 最先运行的Filter，被用作请求权限校验
    /// </summary>
    /// Creator:HYK
    /// Create Time:2018/9/11 9:29
    public class AuthFilterAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //如果用户方位的Action带有AllowAnonymousAttribute，则不进行授权验证
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
            {
                return;
            }
            string authParameter = null;
            var authValue = actionContext.Request.Headers.Authorization;
            if (authValue != null && authValue.Scheme == "BasicAuth")
            {
                authParameter = authValue.Parameter;  //获取请求参数
                var authToken = authParameter.Split('|');  //取出参数,参数格式为（当前时间：加密后的token）将其进行分割
                Logging.Error(authParameter);
                if (authToken.Length < 2)
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);//参数不完整，返回406不接受
                }
                else
                {
                    
                    //参数完整，进行验证
                    if (ValidateToken(authToken[0],authToken[1]))
                    {
                        base.OnAuthorization(actionContext);
                    }
                    else
                    {
                        actionContext.Response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);//验证不通过，未满足期望值417
                    }
                }

            }
            else
            {
                //如果验证不通过，则返回401错误，并且Body中写入错误原因
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, new HttpError("Token 不正确"));
            }

        }

        //验证token
        public bool ValidateToken(string loginTime,string token)
        {
            bool flag = true;
            DateTime checkTime = DateTime.Parse(loginTime);

            //验证时间是否过期
            DateTime nowtime = DateTime.Now;

            TimeSpan a = nowtime - checkTime;

            Logging.Error("a:"+ a.TotalSeconds);

            if (a.TotalSeconds > 120)//时间过期
            {
                flag = false;
            }
            else
            {
                string checkToken = Utils.GetTokenString(loginTime);
                Logging.Error("1:"+checkToken+";2:"+token);
                //比较token
                if (token.Equals(checkToken, StringComparison.CurrentCultureIgnoreCase))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }


            }



            return flag;
        }

   
    }
}
