using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniProgram.Models
{
    /// <summary>
    ///  
    /// 开发者服务器以code换取 用户唯一标识openid 和 会话密钥session_key。
    /// </summary>
    /// Creator:HYK
    /// Create Time:2018/9/5 17:55
    public class WxAuthenticateModel
    {

       
        public string OpenId { get; set; }


      
        public string Session_key { get; set; }

        public string Unionid { get; set; }
    }
}