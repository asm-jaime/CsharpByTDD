namespace csharpreferencetypevaluetype;

internal class MyObject
{
    public int Value { get; set; }
}

class LosingReference
{
    private int _value;

    internal LosingReference(int value)
    {
        _value = value;
    }

    private void ModifyReference(MyObject input)
    {
        input = new MyObject() {Value = _value};
    }

    internal int TryToLoseReference(int value)
    {
        MyObject myObject = new MyObject() { Value = value };

        ModifyReference(myObject);

        return myObject.Value;
    }
}

