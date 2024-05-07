namespace csharpcovariance;

class Root { } // Less Derived Class

class Concrete : Root { } // More Derived Class

delegate Root RootedDelegate(); // Delegate that return Less Derived Class

delegate Concrete ConcreteDelegate(); // Delegate that return More Derived Class

class Covariance
{
    private Root GetRoot() => new Root();

    private Concrete GetConcrete() => new Concrete();

    internal Root TryCovariance()
    {
        RootedDelegate delegateCovariant = GetConcrete;

        return delegateCovariant();
    }

    internal Root TrySetToRootedDelegateGetRootMethod()
    {
        RootedDelegate delegateR = GetRoot;

        return delegateR();
    }

    internal Root TrySetToConcreteDelegateGetConcreteMethod()
    {
        ConcreteDelegate delegateC = GetConcrete;

        return delegateC();
    }

    internal Root TrySetToConcreteDelegateGetRootMethod()
    {
        /*
        ConcreteDelegate delegateC = GetRoot; // syntax error, GetRoot has a wrong return type

        return delegateC();
        */

        return new Root();
    }
}

