using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelHelp.Model
{
    /// <summary>
    /// 数据库连接模型
    /// </summary>
    public class ConnectionModel
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public int prot { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string pwd { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string serverType { get; set; }
        /// <summary>
        /// 命名空间
        /// </summary>
        public string nameSpace { get; set; }
        /// <summary>
        /// 是否继承SqlBase
        /// </summary>
        public bool SqlBase { get; set; }
    }
}
