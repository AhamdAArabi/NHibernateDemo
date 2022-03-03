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
            });

            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            var sefact = cfg.BuildSessionFactory();

            // Add Students Record
            //using (var session = sefact.OpenSession())
            //{

            //    using (var tx = session.BeginTransaction())
            //    {
            //        var student1 = new Student
            //        {
            //            ID = 1,
            //            FirstMidName = "Allan",
            //            LastName = "Bommer"
            //        };

            //        var student2 = new Student
            //        {
            //            ID = 2,
            //            FirstMidName = "Jerry",
            //            LastName = "Lewis"
            //        };

            //        var student3 = new Student
            //        {
            //            ID = 3,
            //            FirstMidName = "Ahmad",
            //            LastName = "A Al Arabi"
            //        };

            //        var student4 = new Student
            //        {
            //            ID = 4,
            //            FirstMidName = "Ali",
            //            LastName = "Man"
            //        };

            //        session.Save(student1);
            //        session.Save(student2);
            //        session.Save(student3);
            //        session.Save(student4);
            //        tx.Commit();
            //    }

            //    Console.ReadLine();
            //}

            // Fetch Students
            //using (var session = sefact.OpenSession())
            //{

            //    using (var tx = session.BeginTransaction())
            //    {
            //        var students = session.CreateCriteria<Student>().List<Student>();

            //        foreach (var student in students)
            //        {
            //            Console.WriteLine("{0} \t{1} \t{2}",
            //               student.ID, student.FirstMidName, student.LastName);
            //        }

            //        tx.Commit();
            //    }

            //    Console.ReadLine();
            //}


            //Update Students and Fetch
            //using (var session = sefact.OpenSession())
            //{

            //    using (var tx = session.BeginTransaction())
            //    {
            //        var students = session.CreateCriteria<Student>().List<Student>();

            //        foreach (var student in students)
            //        {
            //            Console.WriteLine("{0} \t{1} \t{2}", student.ID,
            //               student.FirstMidName, student.LastName);
            //        }

            //        var stdnt = session.Get<Student>(1);
            //        Console.WriteLine("Retrieved by ID");
            //        Console.WriteLine("{0} \t{1} \t{2}", stdnt.ID, stdnt.FirstMidName, stdnt.LastName);

            //        Console.WriteLine("Update the last name of ID = {0}", stdnt.ID);
            //        stdnt.LastName = "Donald";
            //        session.Update(stdnt);
            //        Console.WriteLine("\nFetch the complete list again\n");

            //        foreach (var student in students)
            //        {
            //            Console.WriteLine("{0} \t{1} \t{2}", student.ID,
            //               student.FirstMidName, student.LastName);
            //        }

            //        tx.Commit();
            //    }

            //Console.ReadLine();
            //}

            //Delete Student Record
            //using (var session = sefact.OpenSession())
            //{

            //    using (var tx = session.BeginTransaction())
            //    {
            //        var students = session.CreateCriteria<Student>().List<Student>();

            //        foreach (var student in students)
            //        {
            //            Console.WriteLine("{0} \t{1} \t{2}", student.ID,
            //               student.FirstMidName, student.LastName);
            //        }

            //        var stdnt = session.Get<Student>(1);
            //        Console.WriteLine("Retrieved by ID");
            //        Console.WriteLine("{0} \t{1} \t{2}", stdnt.ID, stdnt.FirstMidName, stdnt.LastName);

            //        Console.WriteLine("Delete the record which has ID = {0}", stdnt.ID);
            //        session.Delete(stdnt);
            //        Console.WriteLine("\nFetch the complete list again\n");

            //        foreach (var student in students)
            //        {
            //            Console.WriteLine("{0} \t{1} \t{2}", student.ID, student.FirstMidName,
            //               student.LastName);
            //        }

            //        tx.Commit();
            //    }

            //    Console.ReadLine();
            //}

        }
    }
}