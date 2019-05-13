namespace MyEvernote.DataAccessLayer.EntityFramework
{
    public class RepositoryBase
    {
        protected static DatabaseContext context;
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
                if (context == null) context = new DatabaseContext();
            }
        }
    }
}