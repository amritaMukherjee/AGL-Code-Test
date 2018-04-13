using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using PetOwnerServiceclass;

namespace ProgramingTest
{
    public class IoModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<HomeController>().UsingConstructor(typeof(ISampleService));
            builder.RegisterType<PetOwnerList>().As<IPetOwnerList>().InstancePerHttpRequest();
            base.Load(builder);
        }
    }
}