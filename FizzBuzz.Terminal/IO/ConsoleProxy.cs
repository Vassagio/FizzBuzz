using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FizzBuzz.Core;

namespace FizzBuzz.Terminal.IO
{
    internal interface IConsoleProxy
    {
        T AskQuestionWithDefault<T>(string question, T defaultAnswer);
        T AskQuestionWithDefault<T>(string question, T defaultAnswer, IReadOnlyDictionary<string, T> mapping);
        void Write<T>(T item);
        void WriteLine<T>(T item);
        void WriteLine();
        void Wait();
        void Clear();
    }

    internal sealed class ConsoleProxy : IConsoleProxy
    {
        public static readonly IReadOnlyDictionary<string, bool> TRUE_FALSE_MAPPING = new ReadOnlyDictionary<string, bool>(new Dictionary<string, bool>
        {
            {"Y", true},
            {"y", true},
            {"Yes", true},
            {"YES", true},
            {"yes", true},
            {"T", true},
            {"t", true},
            {"True", true},
            {"TRUE", true},
            {"true", true},
            {"N", false},
            {"n", false},
            {"No", false},
            {"NO", false},
            {"no", false},
            {"F", false},
            {"f", false},
            {"False", false},
            {"FALSE", false},
            {"false", false}
        });

        public T AskQuestionWithDefault<T>(string question, T defaultAnswer) => AskQuestionWithDefault(question, defaultAnswer, new Dictionary<string, T>());

        public T AskQuestionWithDefault<T>(string question, T defaultAnswer, IReadOnlyDictionary<string, T> mapping)
        {
            var questionWithDefault = $"{question} (default: {defaultAnswer.ToString()}): ";
            Console.Write(questionWithDefault);

            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return defaultAnswer;
            if (input.TryConvert<T>(out var result)) return result;
            if (mapping.Any() && mapping.TryGetValue(input, out var mappedValue)) return mappedValue;

            Console.WriteLine($"\tInvalid input using default ({defaultAnswer.ToString()})");
            return defaultAnswer;
        }

        public void Write<T>(T item) => Console.Write(item.ToString());

        public void WriteLine() => Console.WriteLine();

        public void WriteLine<T>(T item) => Console.WriteLine(item.ToString());

        public void Clear() => Console.Clear();

        public void Wait() => Console.ReadLine();
    }
}