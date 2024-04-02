namespace csharpvirtualoverride;

abstract class Base
{
    public abstract string OverridedMethod();

    public abstract string HideMethod();
}

class Person : Base
{
    public string Name { get; set; }
    public virtual string Display()
    {
        return $"Person  {Name}";
    }

    public override string OverridedMethod()
    {
        return "Overrided 1";
    }

    public override string HideMethod()
    {
        return "Hide 1";
    }
}
class Employee : Person
{
    public string Company { get; set; }

    public override string Display()
    {
        return $"Employee {Name}";
    }

    public override string OverridedMethod()
    {
        return "Overrided 2";
    }

    public new string HideMethod()
    {
        return "Hide 2";
    }
}
