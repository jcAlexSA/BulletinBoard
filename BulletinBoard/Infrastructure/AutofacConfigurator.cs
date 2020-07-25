using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using BusinessLogicLayer;
using Core.DataContext;
using Core.Interfaces.Managers;
using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace BulletinBoard.Infrastructure
{
    public class AutofacConfigurator
    {
        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();

            Build(builder);

            builder.RegisterAssemblyTypes(typeof(BaseRepository<>).Assembly)
                                  .Where(t => t.GetInterfaces()
                                      .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBaseRepository<>))
                                      || typeof(IDataContext).IsAssignableFrom(t)
                                      || (typeof(IUnitOfWork).IsAssignableFrom(t) && !t.IsAbstract))
                                  .AsImplementedInterfaces()
                                  .InstancePerLifetimeScope();

            //registrate managers;
            builder.RegisterType<UsersManager>().As<IUsersManager>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void Build(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }
    }
}