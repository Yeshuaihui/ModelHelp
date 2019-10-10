using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelHelp
{
    public interface IBase
    {
        List<string> getDataBaseName();
        List<string> getTableNameByDataBase(string dataBaseName);
        string CreateClassFile(List<string> TableNames, string dataBaseName, string NameSpace = "");
    }
}
