namespace csharpreferencetypevaluetype;

class In
{
    internal void PassValue(int value)
    {
        value = 0; // you can use value as LValue passed by value
    }

    internal int PassValue(in int value)
    {
        // value = 0; // you can't use value as LValue passed by in
        return value * 10;
    }
}

