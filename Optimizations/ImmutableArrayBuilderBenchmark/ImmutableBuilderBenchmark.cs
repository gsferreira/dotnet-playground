using System.Collections.Immutable;
using BenchmarkDotNet.Attributes;

namespace ImmutableArrayBuilderBenchmark;

[MemoryDiagnoser]
public class ImmutableBenchmark
{
    private readonly List<int> _collection;


    public ImmutableBenchmark()
    {
        _collection = Enumerable.Range(0, 1_000).ToList();
    }

    [Benchmark]
    public ImmutableArray<int> CollectionToImmutableArray()
    {
        return _collection.ToImmutableArray();
    }

    [Benchmark]
    public ImmutableArray<int> ImmutableArrayBuilderFromCollectionWithAdd()
    {
        var builder = ImmutableArray.CreateBuilder<int>(_collection.Count);

        foreach (var entry in _collection)
        {
            builder.Add(entry);
        }

        return builder.ToImmutable();
    }

    [Benchmark]
    public ImmutableArray<int> ImmutableArrayBuilderFromCollectionWithAddRange()
    {
        var builder = ImmutableArray.CreateBuilder<int>(_collection.Count);

        builder.AddRange(_collection);

        return builder.ToImmutable();
    }

    [Benchmark]
    public ImmutableArray<int> ImmutableArrayBuilderAdd()
    {
        var data = Enumerable.Range(0, 1_000);
        var builder = ImmutableArray.CreateBuilder<int>(data.Count());

        foreach (var entry in data)
        {
            builder.Add(entry);
        }

        return builder.ToImmutable();
    }

    [Benchmark]
    public ImmutableArray<int> ImmutableArrayBuilderAddRange()
    {
        var data = Enumerable.Range(0, 1_000);
        var builder = ImmutableArray.CreateBuilder<int>(data.Count());

        builder.AddRange(data);

        return builder.ToImmutable();
    }
}