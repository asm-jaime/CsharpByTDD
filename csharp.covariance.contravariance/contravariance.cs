namespace csharpcontravariance;

class Root { } // Less Derived Class

class Concrete : Root { } // More Derived Class

delegate void RootedDelegate(Root root); // Delegate that return Less Derived Class

delegate void ConcreteDelegate(Concrete concrete); // Delegate that return More Derived Class

class Contrvariance
{
    private void PassRoot(Root root) { }

    private void PassConcrete(Concrete concrete) { }

    internal void TryContrvariance()
    {
        ConcreteDelegate delegateContrvariant = PassRoot;

        delegateContrvariant(new Concrete());
    }

}

