using System.Linq;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace Prime.Services.Benchmarks
{
    //[RPlotExporter]
    public class PrimeService_GetPrimes
    {
        private const int N = 10000;
        private readonly PrimeService service = new PrimeCalculator();
        private readonly Consumer consumer = new Consumer();

        [Params(100, 200, 500, 1000)]
        public int Count { get; set; }

        [Params(0, 1000, 2000, 5000, 10000)]
        public int Offset { get; set; }


        [Benchmark]
        public void FirstN () => service.GetPrimes(Offset).Take(Count).Consume(consumer);
    }
}