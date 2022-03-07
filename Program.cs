using HibernatingRhinos.Profiler.Appender.NHibernate;
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
            //cfg.DataBaseIntegration(x => {
            //    x.ConnectionString = "Data Source=DESKTOP-69PPK9T;Initial Catalog=NHibernateDemoDB;Integrated Security=True";

            //    x.Driver<SqlClientDriver>();
            //    x.Dialect<MsSql2008Dialect>();
            //    x.LogSqlInConsole = true;
            //    x.BatchSize = 30;
            //});
            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = "Data Source=DESKTOP-69PPK9T;Initial Catalog=NHibernateDemoDB;Integrated Security=True";


                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2008Dialect>();
                x.LogSqlInConsole = true;
            });

            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            var sefact = cfg.BuildSessionFactory();

            // Add Students Record

            using (var session = sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {

                    var student1 = new Student
                    {
                        ID = 1,
                        FirstName = "Allan",
                        LastName = "Bommer",
                        AcademicStanding = StudentAcademicStanding.Excellent
                    };

                    var student2 = new Student
                    {
                        ID = 2,
                        FirstName = "Jerry",
                        LastName = "Lewis",
                        AcademicStanding = StudentAcademicStanding.Good
                    };

                    session.Save(student1);
                    session.Save(student2);
                    var students = session.CreateCriteria<Student>().List<Student>();
                    Console.WriteLine("\nFetch the complete list again\n");

                    foreach (var student in students)
                    {
                        Console.WriteLine("{0} \t{1} \t{2} \t{3}", student.ID,
                           student.FirstName, student.LastName, student.AcademicStanding);
                    }

                    tx.Commit();
                }

                Console.ReadLine();
            }

        }
    }
}

