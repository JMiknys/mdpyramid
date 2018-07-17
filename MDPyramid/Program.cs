using Autofac;
using MDPyramid.DependencyResolution;

namespace MDPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
			ContainerBuilder containerBuilder = new ContainerBuilder();
			containerBuilder.RegisterModule(new ApplicationModule());
			IContainer container = containerBuilder.Build();

			using (ILifetimeScope scope = container.BeginLifetimeScope())
			{
				IApplication application = scope.Resolve<IApplication>();
				application.Run();
			}
        }
    }
}
