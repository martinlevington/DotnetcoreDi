using Autofac;
using Autofac.Extras.RegistrationAttributes;

namespace DotnetcoreDi
{
    public class AutoRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.AutoRegistration(GetType().Assembly);
        }
    }
}
