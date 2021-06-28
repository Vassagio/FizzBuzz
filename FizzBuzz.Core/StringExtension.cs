using System;
using System.ComponentModel;

namespace FizzBuzz.Core
{
    public static class StringExtension
    {
        public static bool TryConvert<T>(this string input, out T result)
        {
            result = default;
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                result = (T) converter.ConvertFromString(input);
                return true;
            }
            catch (NotSupportedException)
            {
                return false;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}