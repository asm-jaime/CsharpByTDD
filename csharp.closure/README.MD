<!-- ENGLISH -->
# Closure in c#

Which result will return this method?

```cs

    public string Calculate()
    {
        var result = string.Empty;
        var actions = new List<Action>();

        for(int i = 0; i < 5; i++)
        {
            actions.Add(() => result = $"{result}{i}");
        }

        foreach(var action in actions)
        {
            action();
        }

        return result;
    }
```


### Comment


Example 1

in:
```

```
out:
```

```