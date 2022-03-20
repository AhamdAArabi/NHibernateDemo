using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate.Cache;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

using System;
using System.Linq;
using System.Reflection;

namespace NHibernateDemoApp
{

    class Program
    {

        static void Main(string[] args)
        {
            NHibernateProfilerBootstrapper.PreStart();

            NHibernateProfiler.Initialize();
            var cfg = new Configuration();

            String DataSource = "DESKTOP-69PPK9T";
            String InitialCatalog = "NHibernateDemoDB";
            String IntegratedSecurity = "True";
            String ConnectTimeout = "15";
            String Encrypt = "False";
            String TrustServerCertificate = "False";
            String ApplicationIntent = "ReadWrite";
            String MultiSubnetFailover = "False";
            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = "Data Source=DESKTOP-69PPK9T;Initial Catalog=NHibernateDemoDB;Integrated Security=True";

                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2008Dialect>();
                x.LogSqlInConsole = true;
                x.BatchSize = 10;
            });

            cfg.Cache(c => {
                c.UseMinimalPuts = true;
                c.UseQueryCache = true;
            });


            cfg.SessionFactory().Caching.Through<HashtableCacheProvider>()
               .WithDefaultExpiration(1440);
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            var sefact = cfg.BuildSessionFactory();

            var tempID = new Guid("001fb306-9967-4966-83ed-ae5e014a7e6c");
            var tempID2 = new Guid("C9F56A6D-8BEC-45C5-89AF-AE5E014A7E76");
            using (var session = sefact.OpenSession())
            {

                using (var tx = session.BeginTransaction())
                {
                    var studentUsingTheFirstQuery = session.Get<Student>(tempID);
                    var studentUsingTheSecondQuery = session.Get<Student>(tempID2);
                }

                Console.ReadLine();
            }

        }
    }
}

