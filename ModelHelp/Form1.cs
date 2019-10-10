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
        }
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
                alltask.Add(Task.Run(
                    () =>
                    {
                        path = Server.CreateClassFile(tables, dbName, txtNameSpace.Text == "" ? "" : txtNameSpace.Text + ".");
                    }
                    ));
            });
            Task.WaitAll(alltask.ToArray());
            MessageBox.Show("所有文件已创建完成");
            System.Diagnostics.Process.Start("explorer", path);
        }
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
                    serverType = cmbServerType.SelectedItem + ""
                });
            }
            ConfigModel.Save(config);
        }
    


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (config.Conections.ContainsKey(cmbConfig.Text))
            {
                initFrom(config.Conections[cmbConfig.Text]);
            }
        }


        void initConfig(ConfigModel configModel)
        {
            foreach (var item in configModel.Conections)
            {
                cmbConfig.Items.Add(item.Key);
            }
        }

        void initFrom(ConnectionModel connectionModel)
        {
            txtHost.Text = connectionModel.address;
            txtNameSpace.Text = connectionModel.nameSpace;
            txtProt.Text = connectionModel.prot.ToString();
            txtpwd.Text = connectionModel.pwd;
            txtUserName .Text= connectionModel.userName;
            cmbServerType.SelectedItem = connectionModel.serverType;
        }
    }
}
