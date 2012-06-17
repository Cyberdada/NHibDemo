using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibDemo.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace NHibDemo.Infrastructure
{
    public class Bootstrapper
    {
        public static ISessionFactory CreateSessionFactory(bool reset)
        {
            var configuration = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2000.ConnectionString(x => x.FromConnectionStringWithKey("connectionstring")))
            .Mappings(m =>
            {
                m.FluentMappings
                    .AddFromAssemblyOf<MvcApplication>()
                    .Conventions.AddFromAssemblyOf<MvcApplication>()
                    .ExportTo("d:\\");
                 //m.AutoMappings
                 //   .Add(AutoMap.AssemblyOf<Person>());
           })
            .ExposeConfiguration(b => BuildSchema(b, reset))
            .BuildSessionFactory();
            return configuration;
        }

        private static void BuildSchema(Configuration config, bool reset)
        {
            if (!reset)
                return;

            new SchemaExport(config).Create(false, true);
        }
    }
}