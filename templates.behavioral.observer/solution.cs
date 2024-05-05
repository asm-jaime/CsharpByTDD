using System.Collections.Generic;
using System.Diagnostics;

namespace templatesbehavioralobserver;

interface IObserver
{
    void Update();
}

interface IObservable
{
    void Attach(IObserver observer);

    void Detach(IObserver observer);

    void NotifyAll();
}

class Observable : IObservable
{
    private readonly List<IObserver> _observers;

    internal Observable()
    {
        _observers = new List<IObserver>();
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyAll()
    {
        foreach(var observer in _observers)
        {
            observer.Update();
        }
    }
}

class Counter : IObserver
{
    private static int _count = 0;

    public void Update()
    {
        _count++;
    }

    public string PrintAllNotifications()
    {
        return $"{_count}";
    }
}

class Solution
{
    internal string Calculate()
    {
        IObservable observable = new Observable();
        var counter1 = new Counter();
        var counter2 = new Counter();
        var counter3 = new Counter();

        observable.Attach(counter1);
        observable.Attach(counter2);
        observable.Attach(counter3);

        observable.NotifyAll();

        var result = counter1.PrintAllNotifications();

        return result;
    }
}
