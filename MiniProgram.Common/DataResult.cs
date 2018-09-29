using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProgram.Common
{
    /// <summary>
    /// 执行结果消息类
    /// </summary>
    [Serializable]
    public class DataResult
    {
        /// <summary>
        /// 
        /// </summary>
        bool isSuccess = false;

        /// <summary>
        /// 执行结果
        /// </summary>
        public bool IsSuccess
        {
            get { return isSuccess; }
            set { isSuccess = value; }
        }

        private string successmsg = null;

        /// <summary>
        /// 成功提示消息
        /// </summary>
        public string Successmsg
        {
            get { return successmsg; }
            set { successmsg = value; }
        }


        /// <summary>
        /// 提示消息2
        /// </summary>
        public string Message2
        {
            get { return successmsg; }
            set { successmsg = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        string message = null;

        /// <summary>
        /// 成功提示消息
        /// </summary>
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        System.Exception exception;

        /// <summary>
        /// 异常对象
        /// </summary>
        public System.Exception Exception
        {
            get { return exception; }
            set { exception = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        object data;

        /// <summary>
        /// 返回对象数据
        /// </summary>
        public object Data
        {
            get { return data; }
            set { data = value; }
        }
    }


    [Serializable]
    public class DataResult<T> : DataResult where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        T tdata;

        /// <summary>
        /// 
        /// </summary>
        public T Tdata
        {
            get { return tdata; }
            set { tdata = value; }
        }
    }
}
