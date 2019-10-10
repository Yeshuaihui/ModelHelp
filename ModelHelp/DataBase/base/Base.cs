using System;
using System.Collections.Generic;
using System.Data.Common;
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
        public string host { get; set; }
        public string userName { get; set; }
        public string Pwd { get; set; }
        public int prot { get; set; }
        public abstract string CreateClassFile(List<string> TableNames, string dataBaseName, string NameSpace = "");

        public abstract List<string> getDataBaseName();

        public abstract List<string> getTableNameByDataBase(string dataBaseName);
    }
}
