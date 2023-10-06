using Linq2Oracle.Attributes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OracleCommon;
using Oracle.DataAccess.Client;

namespace Linq2Oracle
{
    public class DataConnection
    {
        public EventHandler OnClosed { get; set; }
        public EventHandler OnOpened { get; set; }
        private string _ConnectString;
        public DataConnection(string ConnName)
        {
            _ConnectString=ConfigurationManager.ConnectionStrings[ConnName].ConnectionString;
        }
        //public List<Tentity> GetTable<Tentity>()
        //{
        //    List<Tentity> tentities = new List<Tentity>();

        //    return tentities;
        //}
        public DataTable GetTable<Tentity>()
        {
            string sql = "select * from " + GetTableName(typeof(Tentity));
            DataSet ds = OracleHelper.ExecuteDataset(_ConnectString, CommandType.Text, sql);
            return ds.Tables[0];
        }
        public void Close()
        {
            OnClosed.Invoke(this, new EventArgs());
        }
        public string GetTableName(Type type)
        {
            return ((TableAttribute)type.GetCustomAttributes(true)[0]).Name;
        }
    }
}
