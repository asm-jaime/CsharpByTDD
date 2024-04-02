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
