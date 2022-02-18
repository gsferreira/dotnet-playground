using BenchmarkDotNet.Attributes;
using RichardSzalay.MockHttp;

namespace AwaitOrReturnTaskBenchmark;

[MemoryDiagnoser]
public class AwaitOrReturnTaskBenchmarks
{
    private HttpClient _httpClient;

    [GlobalSetup]
    public void Setup()
    {
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://localhost/ping")
            .Respond("application/text", "pong");

        _httpClient = mockHttp.ToHttpClient();
    }

    [Benchmark]
    public async Task WithDirectReturnOfDelayedTask()
    {
        await ReturnTask();
    }

    [Benchmark]
    public async Task WithDelayedTaskAwaited()
    {
        await AwaitTask();
    }

    [Benchmark]
    public async Task WithDirectReturnOfHttpCallTask()
    {
        await HttpClientReturnTask();
    }

    [Benchmark]
    public async Task WithHttpCallTaskAwaited()
    {
        await HttpClientAwaitTask();
    }

    private Task ReturnTask()
    {
        return Task.Delay(TimeSpan.FromMilliseconds(1));
    }

    private async Task AwaitTask()
    {
        await Task.Delay(TimeSpan.FromMilliseconds(1));
    }

    private Task HttpClientReturnTask()
    {
        return _httpClient.GetAsync("http://localhost/ping");
    }

    private async Task HttpClientAwaitTask()
    {
        await _httpClient.GetAsync("http://localhost/ping");
    }
}