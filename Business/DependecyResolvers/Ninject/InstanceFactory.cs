using Autofac;
using Business.DependecyResolvers.Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependecyResolvers.NewFolder
{
    public class InstanceFactory
    {

        public static T GetInstance<T>()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacBusinessModule());
            var container = builder.Build();
            return container.Resolve<T>();

        }

    }
}
