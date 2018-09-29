using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;


namespace MiniProgram.Common
{
    public class BaseMySQLConn
    {
        public BaseMySQLConn()
        {
            if (DBCommon.MYSQLDB == null)
            {
                var connectionStr = ConfigurationManager.AppSettings["MySQLDataConn"].ToString();
                DBCommon.MYSQLDB = new MySqlHelper(connectionStr);
            }
        }
    }
}
