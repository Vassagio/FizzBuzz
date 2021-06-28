using System.ComponentModel;
using Unity;
using Unity.Extension;

namespace FizzBuzz.Core
{
    public class CoreDependencies : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<INumberConversionService, NumberConversionService>();
        }
    }
}