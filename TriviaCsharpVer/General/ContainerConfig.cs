using Autofac;
using TriviaClassLib;

namespace TriviaServer
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<Server>().As<IServer>();
            builder.RegisterType<RoomsRepository>().As<IRoomsRepository>();
            builder.RegisterType<MainRequestHandler>().As<IMainRequestHandler>();
            builder.RegisterType<LoginManager>().As<ILoginManager>();
            builder.RegisterType<UsersRepository>().As<IUsersRepository>();
            builder.RegisterType<SignupManager>().As<ISignupManager>();
            builder.RegisterType<StatisticsManager>().As<IStatisticsManager>();

            builder.RegisterInstance(new LoggedUsersRepository()).As<ILoggedUsersRepository>();
            builder.RegisterInstance(new StatisticsRepository()).As<IStatisticsRepository>();
            return builder.Build();
        }
    }
}