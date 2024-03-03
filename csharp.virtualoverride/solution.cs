namespace csharpvirtualoverride;

class Person
{
    public string Name { get; set; }
    public virtual string Display()
    {
        return $"Person  {Name}";
    }
}
class Employee : Person
{
    public string Company { get; set; }
    public override string Display()
    {
        return $"Employee {Name}";
    }
}
