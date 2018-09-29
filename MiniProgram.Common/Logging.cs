using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProgram.Common
{
 
        public class Logging
        {
            public static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            public static void Fatal(string strMsg)
            {
                log.Fatal(strMsg);
            }

            public static void Fatal(Exception ex)
            {
                log.Fatal(ex.ToString());
            }

            public static void Error(string strMsg)
            {
                log.Error(strMsg);
            }

            public static void Error(Exception ex)
            {
                log.Error(ex.ToString());
            }

            public static void Warn(string strMsg)
            {
                log.Warn(strMsg);
            }

            public static void Warn(Exception ex)
            {
                log.Warn(ex.ToString());
            }

            public static void Debug(string strMsg)
            {
                log.Debug(strMsg);
            }

            public static void Debug(Exception ex)
            {
                log.Debug(ex.ToString());
            }

            public static void Info(string strMsg)
            {
                log.Info(strMsg);
            }

            public static void Info(Exception ex)
            {
                log.Info(ex.ToString());
            }

            public static void InitLog()
            {
                log4net.Config.XmlConfigurator.Configure();
            }

            public static string BuildMessageForDBAccess(Exception ex, CommandType commandType, string commandText, params IDataParameter[] commandParameters)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0}: {1}", ex.Source, ex.Message);
                sb.AppendLine();
                sb.AppendFormat("CommandText: {0}", commandText);
                sb.AppendLine();
                sb.AppendFormat("CommandType: {0}", commandType.ToString());
                sb.AppendLine();
                sb.Append("Parameters:");
                sb.AppendLine();
                if (commandParameters != null)
                {
                    foreach (IDataParameter param in commandParameters)
                    {
                        sb.AppendFormat("Name: {0} \t Type: {1} \t Value: {2}", param.ParameterName, param.DbType.ToString(), param.Value);
                        sb.AppendLine();
                    }
                }
                return sb.ToString();
            }
        }
    
}
