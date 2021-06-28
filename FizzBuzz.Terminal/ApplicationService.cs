using System;
using System.CodeDom;
using FizzBuzz.Core;
using FizzBuzz.Terminal.IO;

namespace FizzBuzz.Terminal
{
    internal interface IApplicationService
    {
        void Run();
    }

    internal sealed class ApplicationService : IApplicationService
    {
        private readonly INumberConversionService _numberConversionService;
        private readonly IConsoleProxy _consoleProxy;

        public ApplicationService(INumberConversionService numberConversionService, IConsoleProxy consoleProxy)
        {
            _numberConversionService = numberConversionService ?? throw new ArgumentNullException(nameof(numberConversionService));
            _consoleProxy = consoleProxy ?? throw new ArgumentNullException(nameof(consoleProxy));
        }

        public void Run()
        {
            for (int i = 0; i < 1000; i++)
            {
                var result = _numberConversionService.Convert(i);
                _consoleProxy.WriteLine(result);
            }
            
            _consoleProxy.Wait();
        }
    }
}