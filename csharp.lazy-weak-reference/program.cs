namespace csharplazyweakreference;

using System;
using System.Threading.Tasks;

public class LargeObject
{
    public byte[] Data;

    public LargeObject()
    {
        Data = new byte[10_000_000];
    }
}


public class Program
{
    public static async Task Main(string[] args)
    {
        var largeObject = new LargeObject();

        var x = new Lazy<WeakReference>(() => new WeakReference(largeObject));


        Console.WriteLine(x.Value.IsAlive);

        largeObject = null;

        GC.Collect();
        GC.Collect(0, GCCollectionMode.Forced);
        GC.Collect(1, GCCollectionMode.Forced);
        await Task.Delay(1000);
        GC.Collect(2, GCCollectionMode.Forced);
        GC.WaitForPendingFinalizers();

        Console.WriteLine(x.Value.IsAlive);
    }
}


