<!-- ENGLISH -->
# Task sequence of execution

Say what will print next code.


### Comment


Example 1

in:
```
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
```
out:
```
12
1
```