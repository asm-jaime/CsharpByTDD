<!-- ENGLISH -->
# Task 4

Ivan loves to read. Once a month he comes to the library and takes out many books to read over the next month.

In order not to forget any book, Vanya keeps a list of book numbers that he would like to read. This list is updated quite chaotically, so the book numbers in this list may be repeated.

Before his next trip to the library, Ivan opened the list and saw n entries in it. Vanya is afraid that the library will not accept him with such a list. Therefore, he wants to obtain a list sorted by numbers of minimum length, containing, perhaps implicitly, exactly only the desired books.

To achieve this goal, Ivan can use the following abbreviation: if he wants to take books with numbers x, x+1, ..., y−1, y, then he can write a total of 33 entries in the list: x, ..., y, which will mean that he needs books x to y.

Help Vanya get the desired list.

### Input format

The first line of the input file contains one integer n - the number of records in the original list of books (1≤n≤1*10\^5). The second line contains n numbers ai - elements of the original list of books (1≤ai≤10\^9).

### Output format

Print a list of books with the minimum number of elements such that it contains exactly all the desired books. If there are several lists with a minimum number of elements, print the list with the smallest number of book numbers specified explicitly.

### Rating system

Points for each subtask are awarded only if all tests for that subtask and the required subtasks are successfully completed.

### Comment

In the third test from the condition, the list "1 3 ... 5 9 ... 11" is the answer, since it contains the minimum number of book numbers, while "1 3 ... 5 9 10 11" is not the answer.

Example 1

in:
```
7
1 3 4 5 7 8 12
```
out:
```
1 3 ... 5 7 8 12
```

Example 2

in:
```
1 3 ... 5 7 8 12
```
out:
```
1 11 12 20 30
```

Example 3

in:
```
8
9 11 10 1 3 5 4 4
```
out:
```
1 3 ... 5 9 ... 11
```