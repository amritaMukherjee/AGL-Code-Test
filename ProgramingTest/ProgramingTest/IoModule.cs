namespace ProgramingTest
{
    using Autofac;
    using Autofac.Integration.Mvc;
    using PetOwnerServiceclass;
    using LoggingService;
    
    public class IoModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PetOwnerService>().As<IPetOwnerservice>().InstancePerHttpRequest();
            builder.RegisterType<Logger>().As<ILogger>().InstancePerHttpRequest();
            base.Load(builder);
        }
    }
}