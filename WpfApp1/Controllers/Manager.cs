using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Controllers
{
   public abstract class Manager<T>
    {

       protected IDB<T> db;
       


        protected Manager(IDB<T> db)
        {

            this.db = db;
          
        }

        public void Add(T obj)
        {
            db.Add(obj);
        }
       
        public void Update(T obj)
        {
            db.Update(obj);
        }

        public void Delete(T obj)
        {
            db.Delete(obj);
        }
    }

}
