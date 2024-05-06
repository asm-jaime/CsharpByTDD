namespace csharprefinout;

class ValueNullificator
{
    internal void NullifyValue(int value)
    {
        value = 0;
    }

    internal void NullifyValue(ref int value)
    {
        value = 0;
    }
}

