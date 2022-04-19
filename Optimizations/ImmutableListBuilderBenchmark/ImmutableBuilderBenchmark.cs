using System.Collections.Immutable;
using BenchmarkDotNet.Attributes;

namespace ImmutableListBuilderBenchmark;

[MemoryDiagnoser]
public class ImmutableBenchmark
{
    private readonly List<int> _collection;


    public ImmutableBenchmark()
    {
        _collection = Enumerable.Range(0, 1_000).ToList();
    }


    [Benchmark]
    public IImmutableList<int> CollectionToImmutableList()
    {
        return _collection.ToImmutableList();
    }

    [Benchmark]
    public IImmutableList<int> ImmutableListBuilderFromCollectionWithAdd()
    {
        var builder = ImmutableList.CreateBuilder<int>();

        foreach (var entry in _collection)
        {
            builder.Add(entry);
        }

        return builder.ToImmutable();
    }

    [Benchmark]
    public IImmutableList<int> ImmutableListBuilderAdd()
    {
        var data = Enumerable.Range(0, 1_000);
        var builder = ImmutableList.CreateBuilder<int>();

        foreach (var entry in data)
        {
            builder.Add(entry);
        }

        return builder.ToImmutable();
    }

    [Benchmark]
    public IImmutableList<int> ImmutableListBuilderAddRange()
    {
        var data = Enumerable.Range(0, 1_000);
        var builder = ImmutableList.CreateBuilder<int>();

        builder.AddRange(data);

        return builder.ToImmutable();
    }

    [Benchmark]
    public IImmutableList<int> ImmutableListBuilderFromCollectionWithAddRange()
    {
        var builder = ImmutableList.CreateBuilder<int>();

        builder.AddRange(_collection);

        return builder.ToImmutable();
    }
}