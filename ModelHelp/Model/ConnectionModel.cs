using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelHelp.Model
{
    public class ConnectionModel
    {
        public string address { get; set; }
        public int prot { get; set; }
        public string userName { get; set; }
        public string pwd { get; set; }
        public string serverType { get; set; }
        public string nameSpace { get; set; }
    }
}
