namespace csharpsequenceofexecution;

class SequenceOfExecution
{
    private string _log = "";
    public string Log
    {
        get { return _log; }
        set { _log = $"{_log}{value}"; }
    }

    public string CalculateMain()
    {
        int i = 0;
        Log = $"{i++ + Calculate(i)}";
        Log = $"\r\n{i}";

        return Log;
    }

    public int Calculate(int i)
    {
        Log = $"{i++}";
        return i;
    }
}
