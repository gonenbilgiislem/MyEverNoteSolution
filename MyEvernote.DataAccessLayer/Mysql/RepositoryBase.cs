using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.DataAccessLayer.Mysql
{
    public class RepositoryBase
    {
        
        protected static object context;
        private static readonly object _locksync = new object();

        protected RepositoryBase()
        {
            CreateContext();
        }

        private static void CreateContext()
        {
            if (context != null) return;
            lock (_locksync)
            {
                if (context == null) context = new object();
            }
        }
    }
}
