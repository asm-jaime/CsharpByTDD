<!-- ENGLISH -->
# Task Types

From the sequence notAllStrings, select only string elements,
arrange the words by length and then alphabetically. You need to use Linq.

The result should be as follows: One,Two,Five,Four,Three

object[] notAllStrings = { "One", "Two", "Three", "Four", "Five", 6 };


# Range task

What will be displayed on the screen?

```cs
int[] numeric = Enumerable.Range(1, 5).ToArray();
var resSum = numeric.Sum();
var resNum2 = numeric.Where(n => n < 4);

Console.WriteLine(resSum); // ?
Console.WriteLine(string.Join(",", resNum2)); // ?
numeric[2] = 0;
Console.WriteLine(resSum); //
Console.WriteLine(string.Join(",", resNum2)); // ?
```

# WhereWhere task

What will be displayed on the screen?

```cs
var list = new List<int>();

var i = 10;

var query = list.Where(x => x == i).Where(x => x < 20);
list.Add(10);
list.Add(15);
list.Add(20);

i = 15;

var result = query.ToList();
list.Clear();

Console.WriteLine(result.Count); // ?
Console.WriteLine(result.FirstOrDefault()); // ?
```