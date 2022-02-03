using BenchmarkDotNet.Attributes;

namespace PropertyPatternsBenchmark;

public class PropertyPatternBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(Data))]
    public bool OptionA_WithoutPropertyPattern(string[]? list)
    {
        if (list is null || !list.Any())
            return false;
        return true;
    }

    [Benchmark]
    [ArgumentsSource(nameof(Data))]
    public bool OptionB_WithoutPropertyPattern(string[]? list)
    {
        if (list?.Any() == false)
            return false;
        return true;
    }

    [Benchmark]
    [ArgumentsSource(nameof(Data))]
    public bool OptionC_WithoutPropertyPattern(string[]? list)
    {
        if (list == null || list.Length == 0)
            return false;
        return true;
    }

    [Benchmark]
    [ArgumentsSource(nameof(Data))]
    public bool OptionD_WithPropertyPattern(string[]? list)
    {
        if (list is not { Length: > 0 })
            return false;
        return true;
    }

    [Benchmark]
    [ArgumentsSource(nameof(Data))]
    public bool OptionE_WithPropertyPattern(string[]? list)
    {
        if (list is null or { Length: 0 })
            return false;
        return true;
    }

    public static IEnumerable<string[]> Data()
    {
        yield return null!;
        yield return Array.Empty<string>();
        yield return new[] { "A" };
    }
}