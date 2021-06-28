using System;

namespace FizzBuzz.Core
{
    internal abstract class NumberConverterBase : INumberConverter
    {
        protected abstract INumberConverter NextConverter { get; }
        protected abstract string Result { get; }
        protected abstract Func<int, bool> CanConvert { get; }

        public string Convert(int value, string result)
        {
            if (CanConvert(value)) result += Result;
            return NextConverter.Convert(value, result);
        }
    }
}