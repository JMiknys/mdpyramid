using Autofac;

namespace MDPyramid.DependencyResolution
{
	public class ApplicationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<Application>().As<IApplication>();
			builder.RegisterType<PyramidParser>().As<IPyramidParser>();
		}
	}
}
