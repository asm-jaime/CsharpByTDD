namespace csharpvirtualoverride;

public abstract class Building
{
    public virtual int GetFloors()
    {
        return 0;
    }
}

public class House : Building
{
    public override int GetFloors()
    {
        return 1;
    }
}

public class SkyScraper : House
{
    public override int GetFloors()
    {
        return 30;
    }
}

public class OrdinaryHouse : House
{
    public new int GetFloors()
    {
        return 5;
    }
}
