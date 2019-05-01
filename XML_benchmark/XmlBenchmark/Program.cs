using BenchmarkDotNet.Running;
using System;

namespace XmlBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<FilterInvalidXmlCharactersBenchmark>();

            Console.ReadKey();
        }
    }
}
