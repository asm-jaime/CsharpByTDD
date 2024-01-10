<!-- ENGLISH -->
# Task e

During the development of a certain task, Sasha decided to generate several new tests. Each test by Sasha must be a natural number not less than l and not greater than r. In addition, a natural number in the test must necessarily consist of the same digits.

For example, the number 999 fits this requirement, but the number 123 does not. What is the maximum number of different tests Sasha can create?

### Input data format

The only line contains two natural numbers (1<=l, r<=10\^18) - restrictions on Sasha's tests.

Note that these numbers will not fit in a 32-bit data type, use 64-bit if necessary

### Output format

Print one number - the number of tests that Sasha can do.

### Comment

Numbers [4,5,6,7] suit Sasha in the first test.

In the second test, all numbers that are multiples of 11, from 11 to 99, are suitable.

### Data examples

Example 1

in:
```
4 7
```
out:
```
4
```

Example 2

in:
```
10 100
```
out:
```
9
```