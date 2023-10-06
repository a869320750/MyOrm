using LinqToDB;
using LinqToDB.Data;
using MODEL.NewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DB
{
    public class DbContext:DataConnection
    {
        private Action<string, int> ShowMsg;
        public DbContext(Action<string, int> ShowMsg) : base("DB")
        {
            this.ShowMsg = ShowMsg;
            OnConnectionOpened += (sender, args) =>
            {
                Console.WriteLine(DateTime.Now.ToString());
                //ShowMsg("数据库链接打开",0);

            };
            OnClosed += (sender, args) => { //ShowMsg("数据库链接关闭", 0);
                                            };
        }
        public DbContext() : base("DB")
        {
            OnConnectionOpened += (sender, args) =>
            {
                Console.WriteLine(DateTime.Now.ToString() + "数据库链接打开");

            };
            OnClosed += (sender, args) => { //Console.WriteLine(DateTime.Now.ToString() + "数据库链接关闭");
                                            };
        }
        public ITable<T> GetEntity<T>() where T : Entity
        {
            return this.GetTable<T>();
        }
    }
}
