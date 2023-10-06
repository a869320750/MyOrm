using BLL.DB;
using LinqToDB;
using LinqToDB.Data;
using MODEL.NewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class BaseDAL<Tentity> where Tentity : Entity
    {
        
        protected DbContext _Dbcontext;
        public BaseDAL()
        {
            
            this._Dbcontext = new DbContext();
        }
        public virtual int Add(Tentity entity)
        {
            //entity.Created = System.DateTime.Now;
            return this._Dbcontext.InsertWithInt32Identity(entity);
        }
        public virtual int Insert(Tentity tentity)
        {
            return this._Dbcontext.Insert(tentity);
        }
        public virtual int AddOrUpdate(Tentity tentity)
        {
            return this._Dbcontext.InsertOrReplace(tentity);
        }
        public virtual int Delete(Tentity tentity)
        {
            return this._Dbcontext.Delete<Tentity>(tentity);
        }
        public virtual int Update(Tentity entity)
        {
            //entity.Updated = System.DateTime.Now;
            return this._Dbcontext.Update<Tentity>(entity);
        }
        public virtual List<Tentity> ToList()
        {
            return this._Dbcontext.GetTable<Tentity>().ToList();
        }
        public virtual Tentity SingleOrDefault()
        {
            return this._Dbcontext.GetTable<Tentity>().AsQueryable().SingleOrDefault();
            //SingleOrDefault(x => x.MsgId == id);
        }
        public virtual Tentity SingleOrDefaultWithCondition(Func<Tentity,bool> func)
        {
            try
            {
                return this._Dbcontext.GetTable<Tentity>().AsQueryable().SingleOrDefault(func);
            }
            catch (Exception ex)
            {
                if (ex.Message== "序列包含一个以上的匹配元素")
                {
                    return this.ToListWithCondition(func)[0];
                }
                else
                {
                    return null;
                }
            }
            
            //SingleOrDefault(x => x.MsgId == id);
        }
        public virtual Tentity FirstOrDefaultWithCondition<Tkey>(Func<Tentity, bool> condition,Func<Tentity,Tkey> KeySelector,bool IsAsc)
        {
            if (IsAsc)
            {
                return this._Dbcontext.GetTable<Tentity>().AsQueryable().OrderBy(KeySelector).FirstOrDefault(condition);
            }
            else
            {
                return this._Dbcontext.GetTable<Tentity>().AsQueryable().OrderByDescending(KeySelector).FirstOrDefault(condition);
            }
            
            //SingleOrDefault(x => x.MsgId == id);
        }
        public virtual List<Tentity> ToListWithCondition(Func<Tentity, bool> Condition)
        {
            return this._Dbcontext.GetTable<Tentity>().AsQueryable().Where(Condition).ToList();
        }

        public virtual int ExectSql(string sql)
        {
            return this._Dbcontext.Execute(sql);
        }
        public virtual T Query<T>(string sql)
        {
            return this._Dbcontext.Query<T>(sql).FirstOrDefault();
        }
        public bool IsExist(string sql)
        {
            
            return this._Dbcontext.Execute<int>(sql) != 0;
        }
    }
}
