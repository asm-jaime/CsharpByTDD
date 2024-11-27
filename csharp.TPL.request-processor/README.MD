<!-- ENGLISH -->
# Task template

Our application communicates with a remote service: sends requests and receives responses.
There is only one connection established with the remote server, through which we send requests and receive responses.
Each request contains an Id (GUID), and the response to the request contains the same.
Responses to requests can come in any order and with any delays.
We need to implement an interface that abstracts the fact of such multiplexing.
The implementation of IRequestProcessor must be thread-safe.

We have a ready-made implementation of the INetworkAdapter interface.

```cs

public record Request(Guid Id); // Some other fields

public record Response(Guid Id); // Some other fields

public interface INetworkAdapter
{
	/// Reads the next response
	Task<Response> ReadAsync(CancellationToken cancellationToken);

	/// Sends a request
	Task WriteAsync(Request request, CancellationToken cancellationToken);
}

// We need to implement the IRequestProcessor interface

public interface IRequestProcessor
{
	// Runs the handler. Guaranteed to be called once at application startup
	Task RunAsync(CancellationToken cancellationToken);

	Task StopAsync(CancellationToken cancellationToken);

	// When canceling a CancellationToken, it is not necessary to guarantee that we will not send a request to the server, but the client must receive the task cancellation
	Task<Response> SendAsync(Request request, CancellationToken cancellationToken);
}

public class RequestProcessor : IRequestProcessor
{
    private readonly INetworkAdapter _networkAdapter;

    public RequestProcessor(INetworkAdapter networkAdapter)
    {
    }
    
    private Task Runner() {
    }

    public Task RunAsync(CancellationToken cancellationToken)
    {
    }

    public Task<Response> SendAsync(Request request, CancellationToken cancellationToken)
    {

    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
    }
}
```


### Comment


Example 1

in:
```

```
out:
```

```