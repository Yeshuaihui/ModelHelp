using System;
using System.Linq;
using System.Linq.Expressions;

namespace Ysh.CreateSql
{
    public class SqlServerBaseModel : BaseModel
    {
        /// <summary>
        /// 生成删除语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public override string DeleteSql<T>(Expression<Func<T, bool>> predicate)
        {
            return $"delete {ThisName} " + Where(predicate);
        }
        /// <summary>
        /// 生成查询语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public override string SelectSql<T>(Expression<Func<T, bool>> predicate)
        {
            return $"select * from {ThisName}" + Where(predicate);
        }
        /// <summary>
        /// 生成插入语句
        /// </summary>
        /// <returns></returns>
        public override string InsertSql()
        {
            if (changePV.Count > 0)
            {
                return $"insert into {ThisName}({string.Join(",", changePV.Keys.Select(x => x))}) values({string.Join(",", changePV.Values.Select(x => "'" + x + "'"))})";
            }
            else
            {
                throw new Exception("没有任何属性值改变，无法生成Sql");
            }
        }
        /// <summary>
        /// 生成更新语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public override string UpdateSql<T>(Expression<Func<T, bool>> predicate)
        {
            if (changePV.Count > 0)
            {
                changePV.Keys.Where(x => string.IsNullOrEmpty(x));
                string result = $"update {ThisName} set ";
                foreach (var item in changePV)
                {
                    result += $"{item.Key}='{item.Value}',";
                }
                result = result.Substring(0, result.Length - 1);
                result += Where(predicate);
                return result;
            }
            else
            {
                throw new Exception("没有任何属性值改变，无法生成Sql");
            }
        }
    }
}
