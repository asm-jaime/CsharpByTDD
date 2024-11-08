using System;

namespace oopliscovfixinheritance;

abstract class Fly
{
    public virtual void Flying(int speed)
    {
        Console.WriteLine("Fly");
    }
}


class Bird : Fly
{
    public override void Flying(int speed)
    {
        base.Flying(speed);
        Console.WriteLine("fly fly");
    }
}

class Penguin : Bird
{
    public override void Flying(int speed)
    {
        Console.WriteLine("can't fly, why?");
    }
}
