using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Reflection;
using WebApplication.Data;

namespace WebApplication.Controllers
{
    public class NHibernateManager
    {
        private static ISessionFactory Factory { get; set; }

        private static ConnectionData CurrentConnectionData { get; set; }

        public static void CreateFactory()
        {
            if (Factory == null || Factory.IsClosed)
            {
                CurrentConnectionData = new ConnectionData() { DBName = "mydb", Host = "127.0.0.1", Username = "root" };

                Factory = Fluently.Configure().Database(MySQLConfiguration.Standard.ConnectionString(GenerateConnectionString())).Mappings(m => m.FluentMappings
                           .AddFromAssembly(Assembly.GetExecutingAssembly())).BuildSessionFactory();
            }
        }

        public static ISession OpenSession()
        {
            if (Factory == null || Factory.IsClosed)
                CreateFactory();
            return Factory.OpenSession();
        }

        private static string GenerateConnectionString()
        {
            string result = "";
            if (CurrentConnectionData.DBName?.Length > 0)
                result += $"Database={CurrentConnectionData.DBName};";
            if (CurrentConnectionData.Host?.Length > 0)
                result += $"Datasource={CurrentConnectionData.Host};";
            if (CurrentConnectionData.Port?.Length > 0)
                result += $"Port={CurrentConnectionData.Port};";
            if (CurrentConnectionData.Username?.Length > 0)
                result += $"User={CurrentConnectionData.Username};";
            if (CurrentConnectionData.Password?.Length > 0)
                result += $"Password={CurrentConnectionData.Password};";
            return result;
        }
    }
}
