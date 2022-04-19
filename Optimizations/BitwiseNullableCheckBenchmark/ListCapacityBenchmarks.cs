using BenchmarkDotNet.Attributes;

namespace BitwiseNullableCheckBenchmark;

[MemoryDiagnoser]
public class BitwiseNullableCheckBenchmarks
{

    // [Params(true, false)]
    // public bool WitBitwise { get; set; }




    // [Benchmark]
    // [Arguments(null, null)]
    // [Arguments(1, 2)]
    // [Arguments(null, 2)]
    // [Arguments(1, null)]
    // public bool Check(int? a, int? b)
    // {
    //     if (WitBitwise)
    //         return BitwiseAnd(a, b);
    //     else
    //         return LogicalAnd(a, b);
    // }
    // public bool LogicalAnd(int? a, int? b)
    // {
    //     return a.HasValue && b.HasValue;
    // }

    // public bool BitwiseAnd(int? a, int? b)
    // {
    //     return a.HasValue & b.HasValue;
    // }


    public int? a { get; set; } = 1;
    public int? b { get; set; } = 2;





    [Benchmark]
    public bool LogicalAnd()
    {
        return a.HasValue && b.HasValue && a.Value > b.Value;
    }
    [Benchmark]
    public bool BitwiseAnd()
    {
        return a.HasValue & b.HasValue & a.Value > b.Value;
    }

    [Benchmark]
    public bool c()
    {
        return a > b;
    }
}