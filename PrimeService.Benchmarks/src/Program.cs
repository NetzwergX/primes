using BenchmarkDotNet.Running;

namespace Prime.Services.Benchmarks
{
    public class Program
    {
        static void Main(string[] args)
            => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}