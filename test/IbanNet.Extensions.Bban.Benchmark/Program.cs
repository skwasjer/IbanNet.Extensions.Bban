using System.Reflection;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace IbanNet.Extensions.Bban.Benchmark;

public static class Program
{
    public static void Main(string[] args)
    {
#if DEBUG
        IConfig config = new DebugInProcessConfig();
#else
        IConfig? config = null;
#endif

        Assembly asm = typeof(Program).Assembly;
        if (args.Contains("--all"))
        {
            args = args.Except(["--all"]).ToArray();
            BenchmarkRunner.Run(asm, config, args);
        }
        else
        {
            BenchmarkSwitcher.FromAssembly(asm).Run(args, config);
        }
    }
}
