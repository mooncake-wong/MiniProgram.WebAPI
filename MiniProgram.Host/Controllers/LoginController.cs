using MiniProgram.Models;
using MiniProgram.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using MiniProgram.BLL;

namespace MiniProgram.Host
{
    [RoutePrefix("Login")]
    public class LoginController : BaseAPIController
    {

        // GET: api/Account
        [HttpGet]
        //[AllowAnonymous]//意味着调用这个api无需授权
        [Authorize]//意味着调用这个api需要授权
        [Route("OnLogin")]
        public WxResponseResultModel Login(string code)
        {
            WxResponseResultModel rsEntity = new WxResponseResultModel();

            StringBuilder urlStr = new StringBuilder();
            urlStr.AppendFormat(@"https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code",
                        AppConsts.WxOpenAppId,
                        AppConsts.WxOpenAppSecret,
                        code
                    );
            string resString = Utils.httpGetStr(urlStr.ToString());
            WxAuthenticateModel model = Newtonsoft.Json.JsonConvert.DeserializeObject<WxAuthenticateModel>(resString);
            if (model != null)
            {
                WxMiniProgramUserBLL bll = new WxMiniProgramUserBLL();
                WxMiniprogramUserModel user = new WxMiniprogramUserModel();
                user.OpenId = model.OpenId;
                user.Unionid = model.Unionid;
                user.Session_key = model.Session_key;
                //先判断用户是否存在,返回true则未存在用户，需添加
                if (!string.IsNullOrEmpty(user.OpenId) && !string.IsNullOrEmpty(user.Session_key))
                {
                    if (bll.IfExistsMiniprogramUserInfo(user.OpenId))
                    {
                        //添加用户

                        rsEntity = bll.InsertMiniprogramUserInfo(user);

                    }
                    else
                    {
                        //存在用户，因session_key过期，需要更新
                        rsEntity = bll.UpdateSessionKey(user);
                        //rsEntity.Message = "已存在该用户信息";
                    }
                }



            }
            else
            {
                rsEntity.Message = "转换用户数据出错！";
            }

            return rsEntity;
        }


        [HttpGet]
        [AuthFilter]
        [Route("Test")]
        //public string Test()
        public WxResponseResultModel Test()
        {
            WxResponseResultModel rsEntity = new WxResponseResultModel();
            rsEntity.Code = "200";
            rsEntity.Message = "这是后台传的测试方法";
            //return "这是后台传的测试方法";
            return rsEntity;
        }
    }
}
