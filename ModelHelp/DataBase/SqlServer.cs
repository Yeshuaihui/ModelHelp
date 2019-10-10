using ModelHelp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelHelp.DataBase
{
    public class SqlServerDb : Base
    {
        public SqlServerDb(string host, string userName, string Pwd, int prot) : base(host, userName, Pwd, prot)
        {
        }

        public override string CreateClassFile(List<string> TableNames, string dataBaseName, string NameSpace = "")
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory + "DataBase\\SqlServer\\";
            SqlConnection connDb2 = getSqlConnection(dataBaseName);
            string sql = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Config\\SqlServer.sql");
            connDb2.Open();
            Directory.CreateDirectory(basePath + dataBaseName);
            foreach (string table in TableNames)
            {
                string execSql = sql.Replace("{$TableName}", table + "").Replace("{$NameSpace}", NameSpace);
                SqlCommand cmd = new SqlCommand(execSql, connDb2);
                cmd.CommandTimeout = 50000;
                string ClassFIle = cmd.ExecuteScalar() + "";
                if (!string.IsNullOrEmpty(ClassFIle))
                {
                    ClassFIle = ClassFIle.Replace("\\n", "\n");
                    if (File.Exists(basePath + dataBaseName + "\\" + table + ".cs"))
                    {
                        File.Delete(basePath + dataBaseName + "\\" + table + ".cs");
                    }
                    File.AppendAllText(basePath + dataBaseName + "\\" + table + ".cs", ClassFIle);
                }
            }
            connDb2.Close();
            return basePath;
        }

        public override List<string> getDataBaseName()
        {
            List<string> result = new List<string>();
            SqlConnection connection = getSqlConnection();
            string sql = "SELECT name FROM master.dbo.sysdatabases where name not in({0}'master','model','msdb','tempdb')";
            string NoReadDB = "";
            ConfigModel.Config.NoReadDB.ForEach(x =>
            {
                NoReadDB += "'"+ x + "',";
            });
            SqlDataAdapter dataAdapter = new SqlDataAdapter(string.Format(sql, NoReadDB), connection);
            DataTable AllDb = new DataTable();
            dataAdapter.Fill(AllDb);
            foreach (DataRow dr in AllDb.Rows)
            {
                result.Add(dr["name"].ToString());
            }
            return result;
        }

        public override List<string> getTableNameByDataBase(string dataBaseName)
        {
            List<string> result = new List<string>();

            SqlConnection connDb = getSqlConnection(dataBaseName);
            SqlDataAdapter dataDB = new SqlDataAdapter("select name from sysobjects where xtype='u' or xtype='v' ", connDb);
            DataTable tabTables = new DataTable();
            dataDB.Fill(tabTables);
            foreach (DataRow dr in tabTables.Rows)
            {
                result.Add(dr["name"].ToString());
            }
            return result;
        }

        SqlConnection getSqlConnection(string db = "master")
        {
            string connectionString = string.Format("Data Source={0},{1};Initial Catalog={2};User ID={3};Password={4};", host, prot, db, userName, Pwd);
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}