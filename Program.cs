using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate.Cache;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

using System;
using System.Data;
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

          
            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = @"Data Source=DESKTOP-LAACQV2\SQLEXPRESS01;Initial Catalog=NHibernateDemo;Integrated Security=True";

                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2008Dialect>();
                x.LogSqlInConsole = true;
                x.IsolationLevel = IsolationLevel.RepeatableRead;
                x.Timeout = 10; x.BatchSize = 10;

            });
            cfg.SessionFactory();
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            var sessionFactory = cfg.BuildSessionFactory();

            Guid id;
            using (var session = sessionFactory.OpenSession())

            using (var tx = session.BeginTransaction())
            {
                var newCustomer = CreateCustomer();
                Console.WriteLine("New Customer:");
                Console.WriteLine(newCustomer);
                session.Save(newCustomer);
                id = newCustomer.Id;
                tx.Commit();
            }

            using (var session = sessionFactory.OpenSession())

            using (var tx = session.BeginTransaction())
            {
                var reloaded = session.Load<Customer>(id);
                Console.WriteLine("Reloaded:");
                Console.WriteLine(reloaded);
                tx.Commit();
            }

            Console.WriteLine("Press <ENTER> to exit...");
            Console.ReadLine();
        }

        private static Customer CreateCustomer()
        {

            var customer = new Customer
            {
                FirstName = "John",
                LastName = "Doe",
                Points = 100,
                HasGoldStatus = true,
                MemberSince = new DateTime(2012, 1, 1),
                CreditRating = CustomerCreditRating.Good,
                AverageRating = 42.42424242,
                Address = CreateLocation()
            };

            var order1 = new Order
            {
                Ordered = DateTime.Now
            };

            customer.AddOrder(order1);

            var order2 = new Order
            {
                Ordered = DateTime.Now.AddDays(-1),
                Shipped = DateTime.Now,
                ShipTo = CreateLocation()
            };

            customer.AddOrder(order2);
            return customer;
        }

        private static Location CreateLocation()
        {

            return new Location
            {
                Street = "123 Somewhere Avenue",
                City = "Nowhere",
                Province = "Alberta",
                Country = "Canada"
            };
        }

    }
}

