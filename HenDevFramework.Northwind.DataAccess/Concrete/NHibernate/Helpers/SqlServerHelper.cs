using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HenDevFramework.Core.DataAccess.NHibernate;
using HenDevFramework.Core.Entities;
using NHibernate;

namespace HenDevFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers
{
    public class SqlServerHelper : NHibernateHelper
    {
        protected override ISessionFactory InitializeFactory()
        {
            //Mapping Varsa
            //return Fluently.Configure()
            //        .Database(MsSqlConfiguration.MsSql2012
            //        .ConnectionString(c => c
            //        .FromConnectionStringWithKey("NorthwindContext")))
            //        .Mappings(t => t.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())).BuildSessionFactory();

            //Mapping Yoksa Deneme
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(c => c
                        .FromConnectionStringWithKey("NorthwindContext")))
                .Mappings(t => t.AutoMappings.Add(AutoMap.AssemblyOf<IEntity>())).BuildSessionFactory();
        }
    }
}
