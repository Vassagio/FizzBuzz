using Unity;

namespace FizzBuzz.Terminal
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = Bootstrapper.Initialize();
            container.Resolve<IApplicationService>().Run();
        }
    }
}