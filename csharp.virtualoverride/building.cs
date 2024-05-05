namespace csharpvirtualoverride;

internal abstract class Building
{
    internal virtual int GetFloors()
    {
        return 0;
    }
}

class House : Building
{
    internal override int GetFloors()
    {
        return 1;
    }
}

class SkyScraper : House
{
    internal override int GetFloors()
    {
        return 30;
    }
}

class OrdinaryHouse : House
{
    internal new int GetFloors()
    {
        return 5;
    }
}
