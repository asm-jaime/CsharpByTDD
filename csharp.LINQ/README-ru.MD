<!-- RUSSIAN -->
# Задача Types

Из последовательности  notAllStrings выбрать только строковые элементы, 
упорядочить слова по длине и затем в алфавитном порядке. Нужно использовать Linq.

Результат должен получиться следующим: One,Two,Five,Four,Three

object[] notAllStrings = { "One", "Two", "Three", "Four", "Five", 6 };


# Задача Range

Что выведется на экран?

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

# Задача WhereWhere

Что выведется на экран?

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
