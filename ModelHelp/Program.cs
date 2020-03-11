using ETP.BL.Hotel.Model.traveplay_new;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelHelp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //T_Hotel t_Hotel = new T_Hotel();

            //t_Hotel.Hotelname = "测试酒店";
            //t_Hotel.BrandId = 123;
            //t_Hotel.Hotelname = "冈山格兰比亚酒店";
            //string sql = t_Hotel.InsertSql();
            //string sql2 = t_Hotel.UpdateSql<T_Hotel>(x => x.Id == 189442 && x.Wellness == false);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
