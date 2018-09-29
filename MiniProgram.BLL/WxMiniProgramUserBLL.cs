using MiniProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProgram.BLL
{
   public class WxMiniProgramUserBLL
    {
        /// <summary>
        /// 新增小程序用户信息
        /// </summary>
        /// <param name="checkAccountID"></param>
        /// <returns></returns>
        public WxResponseResultModel InsertMiniprogramUserInfo(WxMiniprogramUserModel model)
        {
            WxMiniProgramUserDAL dal = new WxMiniProgramUserDAL();
            return dal.InsertMiniprogramUserInfo(model);
        }

        /// <summary>
        /// 判断是否存在小程序用户信息
        /// </summary>
        /// <param name="checkAccountID"></param>
        /// <returns></returns>
        public bool IfExistsMiniprogramUserInfo(string openid)
        {
            WxMiniProgramUserDAL dal = new WxMiniProgramUserDAL();
            return dal.IfExistsMiniprogramUserInfo(openid);
        }

        /// <summary>
        /// 更新小程序用户信息
        /// </summary>
        /// <returns></returns>
        public WxResponseResultModel UpdateSessionKey(WxMiniprogramUserModel model)
        {
            WxMiniProgramUserDAL dal = new WxMiniProgramUserDAL();
            return dal.UpdateSessionKey(model);
        }
    }
}
