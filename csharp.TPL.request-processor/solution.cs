using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace csharpTPLrequestprocessor;

public record Request(Guid Id);

public record Response(Guid Id);

public interface INetworkAdapter
{
    /// Вычитывает очередной ответ
    Task<Response> ReadAsync(CancellationToken cancellationToken);

    /// Отправляет запрос
    Task WriteAsync(Request request, CancellationToken cancellationToken);
}

public interface IRequestProcessor
{
    // Запускает обработчик. Гарантированно вызывается 1 раз при старте приложения
    Task RunAsync(CancellationToken cancellationToken);

    Task StopAsync(CancellationToken cancellationToken);

    // При отмене CancellationToken не обязательно гарантировать то, что мы не отправим запрос на сервер, но клиент должен получить отмену задачи
    Task<Response> SendAsync(Request request, CancellationToken cancellationToken);
}

public class RequestProcessor : IRequestProcessor
{
    private readonly INetworkAdapter _networkAdapter;
    private readonly ConcurrentDictionary<Guid, TaskCompletionSource<Response>> _pendingRequests = new();
    private Task _runnerTask;
    private CancellationTokenSource _cts;

    public RequestProcessor(INetworkAdapter networkAdapter)
    {
        _networkAdapter = networkAdapter;
    }

    public Task RunAsync(CancellationToken cancellationToken)
    {
        _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        _runnerTask = Runner(_cts.Token);
        return Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _cts.Cancel();
        if (_runnerTask != null)
        {
            await _runnerTask;
        }
    }

    public Task<Response> SendAsync(Request request, CancellationToken cancellationToken)
    {
        var tcs = new TaskCompletionSource<Response>(TaskCreationOptions.RunContinuationsAsynchronously);
        if (!_pendingRequests.TryAdd(request.Id, tcs))
        {
            throw new InvalidOperationException("Duplicate request Id");
        }

        _ = SendRequestAsync(request, cancellationToken);
        return tcs.Task;
    }

    private async Task SendRequestAsync(Request request, CancellationToken cancellationToken)
    {
        // Exception handling would be here
        await _networkAdapter.WriteAsync(request, CancellationToken.None);
        if (cancellationToken.CanBeCanceled)
        {
            cancellationToken.Register(() =>
            {
                if (_pendingRequests.TryRemove(request.Id, out var tcs))
                {
                    tcs.TrySetCanceled(cancellationToken);
                }
            });
        }
    }

    private async Task Runner(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            Response response;
            // Exception handling would be here
            response = await _networkAdapter.ReadAsync(cancellationToken);
            if (_pendingRequests.TryRemove(response.Id, out var tcs))
            {
                tcs.TrySetResult(response);
            }
        }
        foreach (var kvp in _pendingRequests)
        {
            if (_pendingRequests.TryRemove(kvp.Key, out var tcs))
            {
                tcs.TrySetCanceled(cancellationToken);
            }
        }
    }
}

