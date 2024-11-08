<!-- ENGLISH -->
# What this program will output?:

```cs
public sealed class TaskExample
{
    private static async Task WaitAsync()
    {
        Console.WriteLine("W1");

        Thread.Sleep(1_000);

        Console.WriteLine("W2");

        Task.Delay(1_000).GetAwaiter().GetResult();

        Console.WriteLine("W3");

        await Task.Delay(1_000);

        Console.WriteLine("W4");
    }

    public async Task RunAsync()
    {
        Console.WriteLine("R1");
        WaitAsync();
        Console.WriteLine("R2");
        Console.ReadLine();
    }
}

...
var taskExample = new TaskExample();
taskExample.RunAsync();
```


#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#
#

out:
```
R1
W1
W2
W3
R2
W4
```