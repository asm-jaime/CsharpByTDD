namespace csharpsequenceofexecution;

class SequenceOfExecution
{
    private string _log = "";
    internal string Log
    {
        get { return _log; }
        set { _log = $"{_log}{value}"; }
    }

    internal string CalculateMain()
    {
        int i = 0;
        Log = $"{i++ + Calculate(i)}";
        Log = $"\r\n{i}";

        return Log;
    }

    internal int Calculate(int i)
    {
        Log = $"{i++}";
        return i;
    }
}
