<!-- ENGLISH -->
# max-parallel
There is a remote service that can return a response by id.

It is necessary to implement a method that returns an array of responses by an array of id,

observing the limit on the number of simultaneously executed requests

```csharp

public class Response
{
}

public interface IClient
{
    Task<Response> GetAsync(long id);
}

public static class ClientExtensions
{
    public static async Task<Response[]> GetArrayAsync(
        this IClient client, long[] ids, int maxDegreeOfParallelism)
    {
        // Получаем массив ответов по массиву id
    }
}
```


### Comment

TPL is not allowed.
