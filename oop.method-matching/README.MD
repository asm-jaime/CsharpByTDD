<!-- ENGLISH -->
# Task template
There are three methods that change information about the product (change the state, change the tag composition and set the weight).

Since in the future it is planned to add another 10-20 methods that change information about the product

(the methods themselves can be implemented as nuget in another service)

it is necessary to implement the only method DoSomethingWithItem that, depending on the input parameters, could cause any change in the product.

That is, the method can be told "Change the state" or "Set the weight" and so on

and its implementation itself will call one of the methods StateChanger.Change or WeightSetter.Set etc.

The classes StateChanger, TagsSetter and WeightSetter can be changed.

Main thing is to keep business functionality


```cs

public sealed class StateChanger
{
    public enum State
    {
        Active,
        InActive
    }

    public void Change(int itemId, State newState)
    {
    }
}

public sealed class TagsSetter
{
    public void Set(int itemId, string[] tags)
    {
    }
}

public sealed class WeightSetter
{
    public void Set(int itemId, int weightNetto, float weightBrutto)
    {
    }
}

public sealed class ItemsService
{
    //"Change state" "Set weight"
    public void DoSomethingWithItem()
    {

    }
}
```
