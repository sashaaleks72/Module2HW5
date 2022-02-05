using Autofac;

namespace M2HW5
{
    public class DIConfig
    {
        public IContainer Build()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileService>().As<IFileService>();
            builder.RegisterType<DirectoryConfigurationService>().As<IDirectoryConfigurationService>();
            builder.RegisterType<Logger>().As<ILogger>();
            builder.RegisterType<NotificationService>().As<INotificationService>();
            builder.RegisterType<Actions>().As<IActions>();
            builder.RegisterType<Starter>();
            var container = builder.Build();

            return container;
        }
    }
}
