using MiniProgram.Models;
using MiniProgram.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MiniProgram.BLL
{
    /// <summary>
    /// 小程序用户实体类
    /// </summary>
    /// Creator:HYK
    /// Create Time:2018/9/7 9:48
    public class WxMiniProgramUserDAL :  BaseMySQLConn
    {
        /// <summary>
        /// 新增小程序用户信息
        /// </summary>
        /// <returns></returns>
        public WxResponseResultModel InsertMiniprogramUserInfo(WxMiniprogramUserModel model)
        {
            WxResponseResultModel result = new WxResponseResultModel();
            bool flag = false;
            try
            {
                string querySql = string.Format(@"INSERT INTO kyk_miniprogram_user (openid,session_key,unionid)
VALUES ('{0}', '{1}','{2}');", model.OpenId,model.Session_key,model.Unionid);
                flag = Convert.ToInt32(DBCommon.MYSQLDB.ExecuteNonQuery(querySql)) > 0 ? true : false;
                if (flag)
                {
                    result.Code = "ok";
                    result.Message = "保存用户信息成功";
                }
                else
                {
                    result.Message = "保存用户信息失败";
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                Logging.Error("保存用户信息出错：" + ex.Message);
               
            }
            return result;
            //return new WxResponseResultModel { Code = "", Message = "" };
        }

        /// <summary>
        /// 判断是否存在小程序用户信息
        /// </summary>
        /// <returns></returns>
        public bool IfExistsMiniprogramUserInfo(string openid)
        {
            bool result = true;//默认不存在用户
            try
            {
                string querySql = string.Format(@"SELECT COUNT(1) FROM kyk_miniprogram_user WHERE openid='{0}'",openid);
                int count = Convert.ToInt32(DBCommon.MYSQLDB.ExecuteScalar(querySql));
                if (count > 0)
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                Logging.Error("保存用户信息出错：" + ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 更新小程序用户信息
        /// </summary>
        /// <returns></returns>
        public WxResponseResultModel UpdateSessionKey(WxMiniprogramUserModel model)
        {
            WxResponseResultModel result = new WxResponseResultModel();
            bool flag = false;
            try
            {
                string querySql = string.Format(@"UPDATE kyk_miniprogram_user SET session_key='{0}' WHERE openid='{1}'",model.Session_key,model.OpenId);
                flag = Convert.ToInt32(DBCommon.MYSQLDB.ExecuteNonQuery(querySql)) > 0 ? true : false;
                if (flag)
                {
                    result.Code = "ok";
                    result.Message = "更新用户信息成功";
                }
                else
                {
                    result.Message = "更新用户信息失败";
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                Logging.Error("更新用户信息出错：" + ex.Message);

            }
            return result;
            //return new WxResponseResultModel { Code = "", Message = "" };
        }

    }
}
