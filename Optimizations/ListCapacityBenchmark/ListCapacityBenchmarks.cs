using BenchmarkDotNet.Attributes;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ListCapacityBenchmark;

[MemoryDiagnoser]
public class ListCapacityBenchmarks
{
    private const int ListCapacity = 10000;

    [Benchmark]
    public void AddToListWithCapacity()
    {
        var collectionWithCapacity = new List<int>(ListCapacity);
        foreach (var entry in Enumerable.Range(1, ListCapacity))
        {
            collectionWithCapacity.Add(entry);
        }
    }

    [Benchmark]
    public void AddToListWithoutCapacity()
    {
        var collectionWithoutCapacity = new List<int>();
        foreach (var entry in Enumerable.Range(1, ListCapacity))
        {
            collectionWithoutCapacity.Add(entry);
        }
    }
}