using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DotnetcoreDi.Services;

namespace DotnetcoreDi
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceTwo>().As<IServiceTwo>();
        }
    }
}
