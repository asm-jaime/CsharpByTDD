using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace csharpTPLlock;

class Solution
{
    public static int inc = 0;

    private void ThreadSafeIncrement(Barrier b)
    {
        Thread.Sleep(100);
        lock(typeof(string)) // block SyncBlock for typeof(string) type
        {
            inc = inc + 1;
        }
        b.SignalAndWait();
    }

    public int StartIncrements()
    {
        using(Barrier b = new Barrier(24))
        {
            var threads = Enumerable.Range(0, 23).Select(i => new Thread(() => ThreadSafeIncrement(b)) { Name = $"{i}" }).ToList();

            foreach(var thread in threads)
            {
                thread.Start();
            }

            Task.Run(() =>
            {

                lock(typeof(string))
                {
                    Task.Delay(5000).Wait(); // this will block the same typeof(string)
                }
            });

            b.SignalAndWait();
            foreach(var thread in threads)
            {
                thread.Join();
            }
        }


        return inc;
    }
}
