using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace SppidAdminWebAPI.Helpers
{
    public class AssemblyHelpers
    {
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        if (pro.PropertyType == typeof(bool))
                        {
                            pro.SetValue(obj, (bool)dr[column.ColumnName], null);
                        }
                        else if (pro.PropertyType == typeof(int))
                        {
                            pro.SetValue(obj, (int)dr[column.ColumnName], null);
                        }
                        else if (pro.PropertyType.IsEnum)
                        {
                            object enumValue = Enum.Parse(pro.PropertyType, dr[column.ColumnName].ToString());
                            if(enumValue.GetType().Equals(pro.PropertyType))
                                pro.SetValue(obj, enumValue, null);
                        }
                        else
                        {
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        }
                        break;
                    }
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}