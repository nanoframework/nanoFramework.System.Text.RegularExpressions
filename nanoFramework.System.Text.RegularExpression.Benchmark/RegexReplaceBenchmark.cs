﻿using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace nanoFramework.System.Text.RegularExpression.Benchmark
{
    [DebugLogger]
    [ConsoleParser]
    [IterationCount(100)]
    public class RegexReplaceBenchmark { 
        private string _input;
        private string _input10x;
        private Regex _regex;

        public RegexReplaceBenchmark()
        {
            Debug.WriteLine($"\n\nStarting { this.GetType().Name }...");

            _input = "This is a test. ";
            var builder = new StringBuilder();
            for (var j = 0; j < 10; j++)
            {
                builder.Append(_input);
            }
            _input10x = builder.ToString();

            _regex = new Regex("test");
        }


        [Benchmark]
        public void Regex_Replace()
        {
            var test = _regex.Replace(_input, "replacement");
        }
        [Benchmark]
        public void Regex_Replace_LargerInput()
        {
            var test = _regex.Replace(_input10x, "replacement");
        }
        [Benchmark]
        public void Regex_Replace_LargerInput_MaxOccurrences1()
        {
            var test = _regex.Replace(_input10x, "replacement", 1, 0);
        }
        [Benchmark]
        public void Regex_Replace_LargerInput_MaxOccurrences5()
        {
            var test = _regex.Replace(_input10x, "replacement", 5, 0);
        }
    }
}
