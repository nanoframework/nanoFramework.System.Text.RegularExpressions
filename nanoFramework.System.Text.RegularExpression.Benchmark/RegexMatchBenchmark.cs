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
    public class RegexMatchBenchmark : RegexBenchmarkBase
    {
        public override object MethodToBenchmark(string input, string pattern, RegexOptions options = default)
        {
            if (options != default(RegexOptions))
            {
                return Regex.Match(input, pattern);
            }
            else
            {
                return Regex.Match(input, pattern, options);
            }
        }
    }

    [DebugLogger]
    [ConsoleParser]
    [IterationCount(100)]
    public class RegexMatchesBenchmark : RegexBenchmarkBase
    {
        public override object MethodToBenchmark(string input, string pattern, RegexOptions options = default)
        {
            if (options != default(RegexOptions))
            {
                return Regex.Matches(input, pattern);
            }
            else
            {
                return Regex.Matches(input, pattern, options);
            }
        }
    }


    public abstract class RegexBenchmarkBase
    {
        private string _input;
        private string _input1000x;

        public RegexBenchmarkBase()
        {
            Debug.WriteLine($"\n\nStarting { this.GetType().Name }...");

            _input = "This is a test. ";
            var builder = new StringBuilder();
            for (var j = 0; j < 1000; j++)
            {
                builder.Append(_input);
            }
            _input1000x = builder.ToString();
        }

        public abstract object MethodToBenchmark(string input, string pattern, RegexOptions options = default);

        [Benchmark]
        public void Regex_Match()
        {
            var test = MethodToBenchmark(_input, "test");
        }
        [Benchmark]
        public void Regex_Match_LargerInput()
        {
            var test = MethodToBenchmark(_input1000x, "test");
        }
        [Benchmark]
        public void Regex_Match_LongerPattern()
        {
            var test = MethodToBenchmark(_input, "This is a test");
        }
        [Benchmark]
        public void Regex_Match_ShorterPattern()
        {
            var test = MethodToBenchmark(_input, "s");
        }
        [Benchmark]
        public void Regex_Match_100xInput_WhitespaceInPattern()
        {
            var test = MethodToBenchmark(_input, @"\sa\s");
        }
        [Benchmark]
        public void Regex_Match_100xInput_WordInPattern()
        {
            var test = MethodToBenchmark(_input, @"\w");
        }
        [Benchmark]
        public void Regex_Match_100xInput_WildcardInPattern()
        {
            var test = MethodToBenchmark(_input, @".s");
        }
        [Benchmark]
        public void Regex_Match_IgnoreCase()
        {
            var test = MethodToBenchmark(_input, "Test", RegexOptions.IgnoreCase);
        }
        [Benchmark]
        public void Regex_Match_Multiline()
        {
            var test = MethodToBenchmark(_input, "Test", RegexOptions.Multiline);
        }
        [Benchmark]
        public void Regex_Match_IgnorePatternWhitespace()
        {
            var test = MethodToBenchmark(_input, "Test", RegexOptions.IgnorePatternWhitespace);
        }
    }
}
