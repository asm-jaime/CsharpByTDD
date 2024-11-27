using System;
using System.Collections.Generic;

namespace oopmethodmatching;

// There are three methods that change information about the product (change the state, change the tag composition and set the weight).
// Since in the future it is planned to add another 10-20 methods that change information about the product
// (the methods themselves can be implemented as nuget in another service)
// it is necessary to implement the only method DoSomethingWithItem that, depending on the input parameters, could cause any change in the product.
// That is, the method can be told "Change the state" or "Set the weight" and so on
// and its implementation itself will call one of the methods StateChanger.Change or WeightSetter.Set etc.

// The classes StateChanger, TagsSetter and WeightSetter can be changed.
// Main thing is to keep business functionality

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


public interface IItemOperation
{
    void Execute(int itemId, params object[] args);
}

public sealed class StateOperation : IItemOperation
{
    public void Execute(int itemId, params object[] args)
    {
        var newState = (StateChanger.State)args[0];
        new StateChanger().Change(itemId, newState);
    }
}

public sealed class TagsOperation : IItemOperation
{
    public void Execute(int itemId, params object[] args)
    {
        var tags = (string[])args[0];
        new TagsSetter().Set(itemId, tags);
    }
}

public static class OperationRegistry
{
    private static readonly Dictionary<string, IItemOperation> operations = new Dictionary<string, IItemOperation>();

    static OperationRegistry()
    {
        OperationRegistry.Register("ChangeState", new StateOperation());
        OperationRegistry.Register("SetTags", new TagsOperation());
        OperationRegistry.Register("SetWeight", new WeightOperation());

    }

    public static void Register(string operationName, IItemOperation operation)
    {
        operations[operationName] = operation;
    }

    public static IItemOperation GetOperation(string operationName)
    {
        if(operations.TryGetValue(operationName, out var operation))
        {
            return operation;
        }
        throw new NotImplementedException($"Operation '{operationName}' is not implemented.");
    }
}


public sealed class WeightOperation : IItemOperation
{
    public void Execute(int itemId, params object[] args)
    {
        var weightNetto = (int)args[0];
        var weightBrutto = (float)args[1];
        new WeightSetter().Set(itemId, weightNetto, weightBrutto);
    }
}


public sealed class ItemsService
{
    public void DoSomethingWithItem(string operationName, int itemId, params object[] args)
    {
        var operation = OperationRegistry.GetOperation(operationName);
        operation.Execute(itemId, args);
    }
}
