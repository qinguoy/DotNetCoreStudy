using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Reflection;
namespace QinGy.DotNetCoreStudy.SystemData
{
    public class ModelManagement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<T> GenerateModelList<T>(DataTable table) where T : class, new()
        {
            List<T> resultList = new List<T>();
            if (table == null || table.Rows.Count < 1)
            {
                return resultList;
            }
            Type type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            Dictionary<int, PropertyInfo> dic = new Dictionary<int, PropertyInfo>();
            for (int colIndex = 0; colIndex < table.Columns.Count; colIndex++)
            {
                //TODO 可扩展使用特性定义列头
                var property = properties.FirstOrDefault(p => p.Name == table.Columns[colIndex].ColumnName);
                if (property != null)
                {
                    
                    if (property.PropertyType != typeof(string) && (property.PropertyType.IsClass || property.PropertyType.IsGenericType))
                    {
                        continue;   //暂时不支持泛型和类
                    }
                    dic.Add(colIndex, property);
                }
            }
            if (dic.Count < 1)
            {
                return resultList;
            }
            for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
            {
                T instance = (T)Activator.CreateInstance<T>(); // new T();
                foreach (var item in dic)
                {
                    if (table.Rows[rowIndex][item.Key] == null || table.Rows[rowIndex][item.Key] == DBNull.Value)
                    {
                        item.Value.SetValue(instance, null);
                    }
                    else
                    {
                        item.Value.SetValue(instance, GetValue(item.Value.PropertyType.ToString(),table.Rows[rowIndex][item.Key]));
                    }
                }
                resultList.Add(instance);
            }
            return resultList;
        }

        /// <summary>
        /// 实体转DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public static DataTable GenerateDataTable<T>(List<T> modelList) where T : class
        {
            DataTable table = new DataTable();
            Type type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var propertyItem in properties)
            {
                table.Columns.Add(new DataColumn(propertyItem.Name)); //生成列
            }
            foreach (var modelItem in modelList)
            {
                DataRow row = table.NewRow();
                foreach (var propertyItem in properties)
                {
                    row[propertyItem.Name] = propertyItem.GetValue(modelItem) ;
                }
                table.Rows.Add(row);
            }
            return table;
           

        } 

        #region 类型转换
        private static object GetValue(string type, object value)
        {
            switch (type)
            {
                case "System.Int16":
                    return Convert.ToInt16(value);
                case "System.Int32":
                    return Convert.ToInt32(value);
                case "System.Int64":
                    return Convert.ToInt64(value);
                case "System.String":
                    return value.ToString();
                case "System.Boolean":
                    return Convert.ToBoolean(value);
                case "System.DateTime":
                    return Convert.ToDateTime(value);
                case "System.Float":
                    return Convert.ToDouble(value);
                default:
                    return value;

            }

        }
        #endregion
    }
}
