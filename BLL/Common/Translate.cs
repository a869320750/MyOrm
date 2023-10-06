using MODEL.NewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Common
{
    public static class Translate
    {
        /// <summary>
        /// 扩展方法，网上找的代码，把一个List的数据转换成DataTable
        /// 需要测试能不能用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<T>(this List<T> list)
        {
            if (list == null || list.Count <= 0)
            {
                return null;
            }

            //DataSet ds = new DataSet();
            DataTable dt = new DataTable(typeof(T).Name);
            DataColumn column;
            DataRow row;

            System.Reflection.PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            foreach (T t in list)
            {
                if (t == null)
                {
                    continue;
                }

                row = dt.NewRow();

                for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
                {
                    System.Reflection.PropertyInfo pi = myPropertyInfo[i];

                    string name = pi.Name;

                    if (dt.Columns[name] == null)
                    {
                        if (pi.PropertyType.Equals(typeof(Nullable<DateTime>)))
                        {
                            column = new DataColumn(name, typeof(DateTime));
                            dt.Columns.Add(column);
                        }
                        else
                        {
                            column = new DataColumn(name, pi.PropertyType);
                            dt.Columns.Add(column);
                        }
                        
                    }
                    if (pi.PropertyType.Equals(typeof(Nullable<DateTime>))&& pi.GetValue(t, null)==null)
                    {
                        row[name] = DBNull.Value;
                    }
                    else
                    {
                        row[name] = pi.GetValue(t, null);
                    }
                    
                }

                dt.Rows.Add(row);
            }
            //ds.Tables.Add(dt);
            return dt;
        }

    }
}
