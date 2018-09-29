using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProgram.Models
{
    /// <summary>
    /// 绑定小程序入口的用户
    /// </summary>
    /// Creator:HYK
    /// Create Time:2018/9/7 9:41
    public class WxMiniprogramUserModel
    {
        //主键
        public int MainID { get; set; }

        //小程序openid，用户唯一标识
        public string OpenId { get; set; }
        //会话密钥
        public string Session_key { get; set; }
        //用户在开放平台的唯一标识符
        public string Unionid { get; set; }
   
        //手机号
        public string Mobile { get; set; }
    }
}
