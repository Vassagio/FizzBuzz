using System;
using System.Runtime.Remoting.Messaging;

namespace FizzBuzz.Core
{
    public interface INumberConversionService
    {
        string Convert(int n);
    }

    internal sealed class NumberConversionService : INumberConversionService
    {
        private readonly INumberConverter _numberConverter = new FizzNumberConverter();

        public string Convert(int n)
        {
            if (n <= 0) return string.Empty;

            var result = string.Empty;
            result = _numberConverter.Convert(n, result);
            
            return string.IsNullOrEmpty(result) ? n.ToString() : result;
        }
    }
}