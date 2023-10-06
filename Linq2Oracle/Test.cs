using Linq2Oracle.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Linq2Oracle
{
    public class Test
    {
        public static void Test1()
        {
            try
            {
                Plan testModel = new Plan();
                var result = typeof(Plan).GetCustomAttributes(true);
                Console.WriteLine(((TableAttribute)result[0]).Name);
                PropertyInfo item = typeof(Plan).GetProperty("Name");
                Console.WriteLine(((ColumnAttribute)(item.GetCustomAttributes(true)[0])).Name);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
        public static void Test2()
        {
            try
            {
                DataConnection dataConnection = new DataConnection("DB");
                dataConnection.OnClosed += (obj,args) =>
                {
                    Console.WriteLine(obj.ToString()+args.ToString()+"123456798");
                };
                DataTable dataTable = dataConnection.GetTable<Plan>();
                foreach (DataRow item in dataTable.Rows)
                {
                    for (int i = 0; i < item.ItemArray.Length; i++)
                    {
                        Console.WriteLine(item[i]);
                    }
                }
                Console.WriteLine(dataTable);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
