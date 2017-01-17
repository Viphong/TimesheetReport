using Autofac;
using MediatR;

namespace TimesheetReport.Core
{
    public static class Bootstrapper
    {
        public static void Bootstrap(ContainerBuilder builder)
        {
            RegisterCommandAndQueryHandlers(builder);
            RegisterModelDependencies(builder);
            RegisterCommandDependencies(builder);
            RegisterQueryDependencies(builder);
        }

        private static void RegisterCommandAndQueryHandlers(ContainerBuilder builder)
        {
            var appCoreAssembly = typeof(Bootstrapper).Assembly;
            builder.RegisterAssemblyTypes(appCoreAssembly).AsClosedTypesOf(typeof(IRequestHandler<,>)).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(appCoreAssembly).AsClosedTypesOf(typeof(IAsyncRequestHandler<,>)).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(appCoreAssembly).AsClosedTypesOf(typeof(INotificationHandler<>)).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(appCoreAssembly).AsClosedTypesOf(typeof(IAsyncNotificationHandler<>)).AsImplementedInterfaces();
        }

        private static void RegisterModelDependencies(ContainerBuilder builder)
        {
        }

        private static void RegisterCommandDependencies(ContainerBuilder builder)
        {
        }

        private static void RegisterQueryDependencies(ContainerBuilder builder)
        {
        }
    }
}