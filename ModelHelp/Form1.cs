using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ModelHelp.DataBase;
using ModelHelp.Model;

namespace ModelHelp
{
    public partial class Form1 : Form
    {
        ConfigModel config = null;
        public Form1()
        {
            InitializeComponent();
            config = ConfigModel.Config;
            initConfig(config);
            //悬浮label在10秒钟之后隐藏
            labSlhelp.VisibleChanged += (obj, ex) =>
            {
                if (labSlhelp.Visible)
                {
                    Delay.DelayDo(x =>
                    {
                        Invoke(new Action(() =>
                        {
                            x.Visible = false;
                        }), labSlhelp);
                    }, labSlhelp, 10);
                }
            };
        }
        /// <summary>
        /// 生成模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Base Server = null;
            switch (cmbServerType.Text)
            {
                case "Sql Server":
                    Server = new SqlServerDb(txtHost.Text, txtUserName.Text, txtpwd.Text, Convert.ToInt32(txtProt.Text));
                    break;
                case "MySql":
                    Server = new MySqlDb(txtHost.Text, txtUserName.Text, txtpwd.Text, Convert.ToInt32(txtProt.Text));
                    break;
            }
            string path = "";
            List<Task> alltask = new List<Task>();

            List<string> DbNames = Server.getDataBaseName();
            DbNames.ForEach(dbName =>
            {
                List<string> tables = Server.getTableNameByDataBase(dbName);
                alltask.Add(
                    Task.Run(() =>
                    {
                        path = Server.CreateClassFile(tables, dbName, chkSqlHelp.Checked, txtNameSpace.Text == "" ? "" : txtNameSpace.Text + ".");
                    })
                );
            });
            Task.Run(() =>
            {
                Task.WaitAll(alltask.ToArray());
                Invoke(new Action(()=> {
                    System.Diagnostics.Process.Start("explorer", path);
                    MessageBox.Show("所有文件已创建完成");
                }));
            });
        }
        /// <summary>
        /// 选择数据库类型加载默认端口号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbServerType_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cmbServerType.Text)
            {
                case "Sql Server":
                    txtProt.Text = "1433";
                    break;
                case "MySql":
                    txtProt.Text = "3306";
                    break;
            }
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (config.Conections.ContainsKey(cmbConfig.Text))
            {
                config.Conections[cmbConfig.Text].address = txtHost.Text;
                config.Conections[cmbConfig.Text].nameSpace = txtNameSpace.Text;
                config.Conections[cmbConfig.Text].prot = Convert.ToInt32(txtProt.Text);
                config.Conections[cmbConfig.Text].pwd = txtpwd.Text;
                config.Conections[cmbConfig.Text].userName = txtUserName.Text;
                config.Conections[cmbConfig.Text].serverType = cmbServerType.SelectedItem + "";
                config.Conections[cmbConfig.Text].SqlBase = chkSqlHelp.Checked;
            }
            else
            {
                config.Conections.Add(cmbConfig.Text, new ConnectionModel()
                {
                    address = txtHost.Text,
                    nameSpace = txtNameSpace.Text,
                    prot = Convert.ToInt32(txtProt.Text),
                    pwd = txtpwd.Text,
                    userName = txtUserName.Text,
                    serverType = cmbServerType.SelectedItem + "",
                    SqlBase = chkSqlHelp.Checked
                });
            }
            ConfigModel.Save(config);
        }
    

        /// <summary>
        /// 选择配置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (config.Conections.ContainsKey(cmbConfig.Text))
            {
                initFrom(config.Conections[cmbConfig.Text]);
            }
        }

        /// <summary>
        /// 加载配置信息
        /// </summary>
        /// <param name="configModel"></param>
        void initConfig(ConfigModel configModel)
        {
            foreach (var item in configModel.Conections)
            {
                cmbConfig.Items.Add(item.Key);
            }
        }
        /// <summary>
        /// 根据选择配置信息加载数据到窗体
        /// </summary>
        /// <param name="connectionModel"></param>
        void initFrom(ConnectionModel connectionModel)
        {
            txtHost.Text = connectionModel.address;
            txtNameSpace.Text = connectionModel.nameSpace;
            txtProt.Text = connectionModel.prot.ToString();
            txtpwd.Text = connectionModel.pwd;
            txtUserName .Text= connectionModel.userName;
            cmbServerType.SelectedItem = connectionModel.serverType;
            chkSqlHelp.Checked = connectionModel.SqlBase;
        }

        /// <summary>
        /// 继承Sql帮助悬浮提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSqlHelp_MouseHover(object sender, EventArgs e)
        {
            if (!labSlhelp.Visible)
            {
                labSlhelp.Visible = true;
            }
        }
    }
}
