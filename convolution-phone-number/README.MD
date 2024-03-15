<!-- ENGLISH -->
# Convolution ranges of numbers

* "phone number" ("number") - a sequence of ten digits from 0 to 9 inclusive, for example: 9101234567, 7845124419, etc.

* "range of numbers" ("range") - a continuous sequence of "numbers" from the lower to the upper boundary inclusive, for example: [9101234567; 9101234570].

* "range prefix" ("prefix") - a sequence of the first digits of a "number" (up to ten digits), which, when "padded" with zeros and nines, represents a continuous and non-overlapping "range", for example: the "prefix" "91012" represents the "range" [9101200000; 9101299999].

    What needs to be done:

    Input data can be entered via the console or file, and results can be displayed in the console or file. The found "prefixes" should be output line by line in ascending numerical order.

1. For an arbitrary "range", you need to find the smallest set of "prefixes" of minimal length, "covering" only the given "range" and not exceeding its boundaries. If the lower boundary of the "range" is greater than the upper one, they should be swapped before finding the "prefixes".

2. Solve item 1 for an arbitrary number of "ranges" represented directly as a range [lower_bound; upper_bound]. The "ranges" can intersect.

3. Solve item 2 for "ranges" represented both as a range [lower_bound; upper_bound] and as "prefixes". The "ranges" can intersect.

4. Solve item 1 using two different methods.

Example of "merging ranges of numbers" (according to item 1 of the task):
For the range [9101234567; 9101234731], the program should output to the console (or to a file).
### Comment


Example 1

in:
```
10 19
```
out:
```
10
11
12
13
14
15
16
17
18
19
```

Example 2

in:
```
113 152
```
out:
```
114
115
116
117
118
119
12
13
14
151
152
```

Example 3

in:
```
1234 1550
```
out:
```
1234
1235
1236
1237
1238
1239
124
125
126
127
128
129
13
14
150
151
152
153
154
1250
```

Example 4

in:
```
9101234567 9101234731
```
out:
```
9101234567
9101234568
9101234569
910123457
910123458
910123459
91012346
910123470
910123471
910123472
9101234730
9101234731
```
