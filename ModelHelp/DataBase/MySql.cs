using ModelHelp.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelHelp.DataBase
{
    public class MySqlDb : Base
    {
        List<DbTable> dbTables = new List<DbTable>();
        ConfigModel configModel = null;
        public MySqlDb(string host, string userName, string Pwd, int prot) : base(host, userName, Pwd, prot)
        {
            InitDbTable();
            configModel = ConfigModel.Config;
        }

        public override string CreateClassFile(List<string> TableNames, string dataBaseName, bool sqlBase, string NameSpace = "")
        {
            base.CreateClassFile(TableNames, dataBaseName, sqlBase, NameSpace);
            string basePath = AppDomain.CurrentDomain.BaseDirectory + "DataBase\\MySql\\";
            MySqlConnection connDb2 = getSqlConnection();
            string sql = "select `TABLE_SCHEMA`,`TABLE_NAME`,`COLUMN_NAME`,`COLUMN_TYPE`,`COLUMN_COMMENT`, `IS_NULLABLE`,`DATA_TYPE` from information_schema.columns where table_schema not in ('information_schema','mysql','performance_schema','sqlwave_pa','sys')";
            DataTable dataTable = new DataTable();
            MySqlDataAdapter mySqlData = new MySqlDataAdapter(sql, connDb2);
            mySqlData.Fill(dataTable);
            List<DbColumn> dbColumns = new List<DbColumn>();
            foreach (DataRow dr in dataTable.Rows)
            {

                Directory.CreateDirectory(basePath + dr["TABLE_SCHEMA"] + "");
                dbColumns.Add(new DbColumn()
                {
                    COLUMN_COMMENT = dr["COLUMN_COMMENT"] + "",
                    COLUMN_NAME = dr["COLUMN_NAME"] + "",
                    COLUMN_TYPE = dr["COLUMN_TYPE"] + "",
                    DATA_TYPE = dr["DATA_TYPE"] + "",
                    IS_NULLABLE = dr["IS_NULLABLE"] + "",
                    TABLE_NAME = dr["TABLE_NAME"] + "",
                    TABLE_SCHEMA = dr["TABLE_SCHEMA"] + ""
                });
            }
            TableNames.ForEach(table =>
            {
                List<DbColumn> columns = dbColumns.Where(x => x.TABLE_NAME == table&&x.TABLE_SCHEMA==dataBaseName).ToList();
                StringBuilder ClassFIle = new StringBuilder(
                    $"namespace  {NameSpace}{columns.FirstOrDefault()?.TABLE_SCHEMA}\n{{\n\tusing System.ComponentModel.DataAnnotations;\n\tusing System;\n\t/// <summary>\n\t///{dbTables.FirstOrDefault(x => x.DbName == dataBaseName && x.TableName == table).TableDescription}\n\t/// </summary>\n\t[Serializable]\n\tpublic partial class {table}{(sqlBase ? ":MySqlBaseModel" : "")}\n\t{{\n");                
                string sqlPRIMARY = $"SELECT column_name  FROM INFORMATION_SCHEMA.`KEY_COLUMN_USAGE`  WHERE table_name = '{table}' AND CONSTRAINT_SCHEMA = '{ columns.FirstOrDefault()?.TABLE_SCHEMA}' AND constraint_name = 'PRIMARY'";
                MySqlCommand sqlCommand = new MySqlCommand(sqlPRIMARY, connDb2);
                connDb2.Open();
                string PRIMARY = sqlCommand.ExecuteScalar() + "";
                connDb2.Close();
                columns.ForEach(column =>
                {
                    ClassFIle.Append($"\t\t/// <summary>\n\t\t///{column.COLUMN_COMMENT}\n\t\t/// </summary>\n");
                    if (column.COLUMN_NAME == PRIMARY)
                    {
                        ClassFIle.Append("\t\t[Key]\n");
                    }
                    string type = "";

                    if (configModel.MysqlType.ContainsKey(column.DATA_TYPE))
                    {
                        type = configModel.MysqlType[column.DATA_TYPE];
                    }
                    else
                    {
                        type = "object";
                    }
                    if (column.IS_NULLABLE.Equals("yes", StringComparison.OrdinalIgnoreCase) && type != "string")
                    {
                        type += "?";
                    }
                    ClassFIle.Append($"        public {type} {column.COLUMN_NAME} {{get;set;}}\n");
                });
                ClassFIle.Append("\n\t}\n}");
                if (File.Exists(basePath + dataBaseName + "\\" + table + ".cs"))
                {
                    File.Delete(basePath + dataBaseName + "\\" + table + ".cs");
                }
                File.AppendAllText(basePath + dataBaseName + "\\" + table + ".cs", ClassFIle.ToString());
            });
            return basePath;
        }

        public override List<string> getDataBaseName()
        {
            return dbTables.Select(x => x.DbName).Distinct().ToList();
        }

        public override List<string> getTableNameByDataBase(string dataBaseName)
        {
            return dbTables.Where(x=>x.DbName == dataBaseName).Select(x => x.TableName).ToList();
        }

        MySqlConnection getSqlConnection(string db = "information_schema")
        {
            string connectionString = string.Format("Server={0};PORT={1};Database={2};Uid={3};Pwd={4};", host, prot, db, userName, Pwd);
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }
        void InitDbTable()
        {
            if (dbTables.Count == 0)
            {
                DataTable dataTable = new DataTable();
                string NoReadDB = "";
                ConfigModel.Config.NoReadDB.ForEach(x =>
                {
                    NoReadDB += "'" + x + "',";
                });
                MySqlDataAdapter mySqlData = new MySqlDataAdapter(string.Format("select distinct `TABLE_SCHEMA` DbName ,`TABLE_NAME` tableName ,`table_comment` TableDescription from `TABLES` where `TABLE_SCHEMA` not in ({0}'information_schema','mysql','performance_schema','sqlwave_pa','sys')", NoReadDB), getSqlConnection());
                mySqlData.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {
                    dbTables.Add(new DbTable()
                    {
                        DbName = dr["DbName"] + "",
                        TableName = dr["tableName"] + "",
                        TableDescription = dr["TableDescription"] + ""
                    });
                }
            }
        }

        class DbTable
        {
            public string DbName { get; set; }
            public string TableName { get; set; }
            public string TableDescription { get; set; }
        }
        class DbColumn
        {
            public string TABLE_SCHEMA { get; set; }
            public string TABLE_NAME { get; set; }
            public string COLUMN_NAME { get; set; }
            public string COLUMN_TYPE { get; set; }
            public string COLUMN_COMMENT { get; set; }
            public string IS_NULLABLE { get; set; }
            public string DATA_TYPE { get; set; }
        }
    }
}
