Kostya has a piece of paper with n numbers written on it. He also has the opportunity not more than k times to take any number from a piece of paper, then paint over one of the old digits, and write a new arbitrary digit in its place.
By what maximum value can Kostya increase the sum of all the numbers on the sheet?

Input data format

The first line of the input file contains two integers n,k — the number of numbers on the piece of paper and the limit on the number of operations (1<=n<=1000,1<=k<=10^4).
The second line contains n numbers a_i — numbers on a piece of paper (1<=a_i<=10^9).

Output format

Print a single number in the output file — the maximum difference between the final and initial sums.

Comment

In the first example, Kostya can change two ones into two nines, as a result of which the sum of numbers will increase by 16.
In the second example, Kostya changes the number 85 to 95.
In the third example, nothing can be changed.
Note that the response may exceed the capacity of the 32-bit data type.

Data examples

Example 1
in:
5 2
1 2 1 3 5
out:
16
Example 2
in:
3 1
99 5 85
out:
10
Example 3
in:
1 10
9999
out:
0