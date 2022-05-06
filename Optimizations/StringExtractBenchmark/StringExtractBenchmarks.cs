using BenchmarkDotNet.Attributes;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StringExtractBenchmark;

[MemoryDiagnoser]
public class StringExtractBenchmarks
{
    private const string Text = "my-long-text";


    [Benchmark]
    public string UsingSplitAndIndex()
    {
        return Text.Split('-')[1];
    }

    [Benchmark]
    public string UsingSpanSlice()
    {
        var startIndex = Text.IndexOf('-') + 1;
        var endIndex = Text.LastIndexOf('-') - startIndex;
        return Text.AsSpan().Slice(startIndex, endIndex).ToString();
    }

    [Benchmark]
    public string UsingRangeOperator()
    {
        var startIndex = Text.IndexOf('-') + 1;
        var endIndex = Text.LastIndexOf('-') - startIndex;
        return Text[startIndex..endIndex];
    }

    [Benchmark]
    public string UsingSubstring()
    {
        var startIndex = Text.IndexOf('-') + 1;
        var endIndex = Text.LastIndexOf('-') - startIndex;
        return Text.Substring(startIndex, endIndex);
    }
}