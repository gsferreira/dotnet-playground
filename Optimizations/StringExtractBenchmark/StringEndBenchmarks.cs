using BenchmarkDotNet.Attributes;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StringExtractBenchmark;

[MemoryDiagnoser]
public class StringEndBenchmarks
{
    private const string Text = "my-long-set-of-text";


    [Benchmark]
    public string UsingSplitAndLast()
    {
        return Text.Split('-').Last();
    }

    [Benchmark]
    public string UsingSplitAndIndex()
    {
        return Text.Split('-')[^1];
    }

    [Benchmark]
    public string UsingSpanSlice()
    {
        var index = Text.LastIndexOf('-') + 1;
        return Text.AsSpan().Slice(index, Text.Length - index).ToString();
    }

    [Benchmark]
    public string UsingRangeOperator()
    {
        var index = Text.LastIndexOf('-') + 1;
        return Text[index..];
    }

    [Benchmark]
    public string UsingSubstring()
    {
        return Text.Substring(Text.LastIndexOf('-') + 1);
    }
}