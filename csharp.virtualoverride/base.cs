namespace csharpvirtualoverride;

abstract class Base
{
    internal abstract string OverridedMethod();

    internal abstract string HideMethod();
}

class Person : Base
{
    internal string Name { get; set; }
    internal virtual string Display()
    {
        return $"Person  {Name}";
    }

    internal override string OverridedMethod()
    {
        return "Overrided 1";
    }

    internal override string HideMethod()
    {
        return "Hide 1";
    }
}
class Employee : Person
{
    internal string Company { get; set; }

    internal override string Display()
    {
        return $"Employee {Name}";
    }

    internal override string OverridedMethod()
    {
        return "Overrided 2";
    }

    internal new string HideMethod()
    {
        return "Hide 2";
    }
}
