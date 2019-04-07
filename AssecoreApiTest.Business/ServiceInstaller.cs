using AssecoreApiTest.Business.IService;
using Autofac;
using AssecoreApiTest.Data;

namespace AssecoreApiTest.Business
{
    public class ServiceInstaller : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AssecoreApiTestDatabaseContext>().InstancePerRequest();
            builder.RegisterAssemblyTypes(ThisAssembly)
                    .Where(c => c.Name.EndsWith("Service"))
                    .AsImplementedInterfaces();
        }
    }
}
