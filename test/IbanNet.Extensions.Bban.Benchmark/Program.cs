using System.Reflection;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using IbanNet.Extensions.Bban.Benchmark.Algorithms;

namespace IbanNet.Extensions.Bban.Benchmark;

public static class Program
{
    private const string RunAllSwitch = "--all";
    private const string RunAlgorithmsSwitch = "--algorithms";

    public static void Main(string[] args)
    {
        IConfig config = ManualConfig.CreateMinimumViable();
#if DEBUG
        config = ManualConfig.Union(config, new DebugInProcessConfig());
#endif

        Assembly asm = typeof(Program).Assembly;
        if (args.Contains(RunAllSwitch))
        {
            args = args.Except([RunAllSwitch]).ToArray();
            BenchmarkRunner.Run(asm, config, args);
        }
        else if (!RunSelectionIfArgsContains<AlgorithmBenchmark>(RunAlgorithmsSwitch, args))
        {
            BenchmarkSwitcher.FromAssembly(asm).Run(args, config);
        }
    }

    private static bool RunSelectionIfArgsContains<T>(string arg, params string[] args)
        where T : class
    {
        if (!args.Contains(arg))
        {
            return false;
        }

        args = args.Except([arg]).ToArray();
        Type[] types = typeof(T).Assembly.GetTypes()
            .Where(t => typeof(T).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
            .ToArray();

        BenchmarkRunner.Run(types, ManualConfig.CreateMinimumViable(), args);
        return true;
    }
}
