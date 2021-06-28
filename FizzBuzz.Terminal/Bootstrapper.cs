using FizzBuzz.Core;
using FizzBuzz.Terminal.IO;
using Unity;
using Unity.Lifetime;

namespace FizzBuzz.Terminal
{
    internal sealed class Bootstrapper
    {
        public static IUnityContainer Initialize()
        {
            var container = new UnityContainer();
            container.AddNewExtension<CoreDependencies>();
            container.RegisterType<IApplicationService, ApplicationService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IConsoleProxy, ConsoleProxy>(new ContainerControlledLifetimeManager());
            return container;
        }
    }
}