using System;

namespace csharpweakevent;

public class EventSource
{
    public event EventHandler<EventArgs> Event = delegate { };

    public void Raise()
    {
        Event(this, EventArgs.Empty);
    }
}


public class EventListener
{
    public int Counter { get; set; }
    readonly EventSource eventSourceObject;

    public EventListener(EventSource source)
    {
        eventSourceObject = source;
        eventSourceObject.Event += MyHandler;
    }

    private void MyHandler(object source, EventArgs args)
    {
        Counter++;
        Console.WriteLine("MyHandler received event " + Counter);
    }

    public void UnRegisterEvent()
    {
        eventSourceObject.Event -= MyHandler;
    }
}

static class Executor
{
    public static void ExecuteEventSequence()
    {
        EventSource source = new ();
        _ = new EventListener(source);

        Console.WriteLine("Raise event first time");
        Console.Read();
        source.Raise();

        //Set listener to null and call GC to release the  
        //listener object from memory.  

        Console.WriteLine("\nSet listener to null and call GC");
        Console.Read();
        //developer forget to unregister the event               

        //listener.UnRegisterEvent();  
        //listener = null;
        GC.Collect();
        Console.WriteLine("\nRaise event 2nd time");
        Console.Read();
        source.Raise();
        Console.ReadKey();
    }
}
