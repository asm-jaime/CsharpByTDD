using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace csharptplmaxparallel;

public record class Response(long Id);

public interface IClient
{
    Task<Response> GetAsync(long id);
}

public class Client : IClient
{
    public async Task<Response> GetAsync(long id)
    {
        await Task.Delay(10);

        return new Response(id);
    }
}

public static class ClientExtensions
{
    public static async Task<Response[]> GetArrayAsync(
        this IClient client, long[] ids, int maxDegreeOfParallelism)
    {
        var semaphore = new SemaphoreSlim(maxDegreeOfParallelism);

        var result = ids.Select(async id =>
        {
            await semaphore.WaitAsync();

            try
            {
                return await client.GetAsync(id);
            }
            finally
            {
                semaphore.Release();
            };
        }).ToArray();

        return await Task.WhenAll(result);
    }
}
