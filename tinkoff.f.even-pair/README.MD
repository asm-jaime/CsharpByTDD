<!-- ENGLISH -->
# Task f

In physical education, there is a division into two teams. The guys are lined up, each of them has his own height a_i.
The division into teams will take place according to the "even-odd" principle - all students with even height go to one team, and odd ones go to another.
Unlike the usual lesson, the guys did not line up in height. Instead of the usual order, they got up by accident. Now physical instructor Yasha looks at the line and thinks - can exactly one pair of students change places so that the teams are the same as in the "first-second" principle. In other words, he wants to get such an order in which all students with even height are in even positions, and with odd height are in odd positions.

Help Yasha find the right replacement.

Input data format

The first line contains the number n(2<=n<=1000) — the number of students in the line.
The next line contains n natural numbers a_i (1<=a_i<=10^9) — the height of the students.

Output format

In a single line print i and j — the numbers of the elements to be swapped to achieve the given condition (1<=i, j<=n, i!=j). If there are several answers, any one is allowed.

If there is no way to swap two elements, print −1 −1.

Remarks

In the first example, at least one student with an even height will be in an odd position.
In the second test, the replacement will result in an incorrect state.
In the third test from the condition, the replacement will bring the line to a valid state [1, 2].

Data examples
Example 1
in:
4
2 1 4 6
out:
-1 -1
Example 2
2
1 2
out:
-1 -1
Example 3
in:
2
2 1
out:
1 2