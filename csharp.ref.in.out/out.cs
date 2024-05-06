namespace csharprefinout;

class Out
{
    internal void PassValue(int value)
    {
        value = 10;
    }

    internal void PassValue(out int value)
    {
        // value = value * 10; // you can't use value as RValue passed by out
        value = 15;
    }
}

