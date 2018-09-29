using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProgram.Common
{
    public class DBCommon
    {
        public static MySqlHelper MYSQLDB = null;


        /// <summary>
        /// 类型转换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int? IntConvert(object obj)
        {
            if (DBNull.Value != obj && DBNull.Value != obj)
            {
                return Convert.ToInt32(obj);
            }

            return null;
        }

        /// <summary>
        /// 类型转换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime? DateConvert(object obj)
        {
            DateTime resutl;

            if (DBNull.Value != obj && DateTime.TryParse(obj.ToString(), out resutl))
            {
                return resutl;
            }

            return null;
        }

        /// <summary>
        /// 类型转换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool BoolConvert(object obj)
        {
            if (DBNull.Value != obj)
            {
                return Convert.ToBoolean(obj);
            }

            return false;
        }

        /// <summary>
        /// 类型转换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal DecConvert(object obj)
        {
            decimal resultValue = 0m;

            if (obj != null && obj.ToString() != "")
            {
                resultValue = Convert.ToDecimal(obj);
            }

            return resultValue;
        }

        public static string StrConvert(object obj)
        {
            var resultString = string.Empty;
            if (obj != null)
            {
                resultString = obj.ToString();
            }

            return resultString;
        }
        public static double DouConvert(object obj)
        {
            double resultValue = 0.000;

            if (obj != null && obj.ToString() != "")
            {
                resultValue = double.Parse(obj.ToString());
            }

            return resultValue;
        }
       

    }
}
