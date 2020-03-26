using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Ysh.CreateSql
{
    /// <summary>
    /// 所以数据库模型的基类
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public abstract class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected Dictionary<string, object> changePV = new Dictionary<string, object>();
        private List<PropertyInfo> thispropertyinfo = new List<PropertyInfo>();

        public BaseModel()
        {
            PropertyChanged += (sender, e) =>
            {
                if (changePV.ContainsKey(e.PropertyName))
                {
                    changePV[e.PropertyName] = PropertyValue(e.PropertyName);
                }
                else
                {
                    changePV.Add(e.PropertyName, PropertyValue(e.PropertyName));
                }
            };
        }

        /// <summary>
        /// 属性值改变事件
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanging(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 获取指定属性的值
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>

        private object PropertyValue(string propertyName)
        {
            if (thispropertyinfo.Count == 0)
            {
                thispropertyinfo = GetType().GetProperties().ToList();
            }
            var propertyinfo = thispropertyinfo.FirstOrDefault(x => x.Name.Equals(propertyName));
            if (propertyinfo != null)
            {
                return propertyinfo.GetValue(this);
            }
            return null;
        }

        public abstract string InsertSql();
        public abstract string UpdateSql<T>(Expression<Func<T, bool>> predicate) where T : BaseModel;
        public abstract string DeleteSql<T>(Expression<Func<T, bool>> predicate) where T : BaseModel;
        public abstract string SelectSql<T>(Expression<Func<T, bool>> predicate) where T : BaseModel;
        protected virtual string Where<T>(Expression<Func<T, bool>> predicate)
        {
            var heler = new AnalyseExpressionHelper();
            heler.AnalyseExpression(predicate);
            return $" where {heler.Result}";
        }

        protected string ThisName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(thisName))
                {
                    thisName = GetType().Name;
                }
                return GetType().Name;
            }
        }
        private string thisName;
    }
}
