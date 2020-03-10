using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelHelp
{
    public abstract class Base : IBase
    {
        public Base(string host, string userName, string Pwd,int prot)
        {
            this.host = host;
            this.userName = userName;
            this.Pwd = Pwd;
            this.prot = prot;
        }
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string host { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 端口号
        /// </summary>
        public int prot { get; set; }

        private bool execBaseModel = false;
        public virtual string CreateClassFile(List<string> TableNames, string dataBaseName,bool sqlBase, string NameSpace = "")
        {
            if (!execBaseModel)
            {
                execBaseModel = true;
            }
            return "";
        }

        public abstract List<string> getDataBaseName();

        public abstract List<string> getTableNameByDataBase(string dataBaseName);
    }
}
