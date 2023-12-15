<!-- ENGLISH -->
# Task b

Vanya brought a roll into the kitchen, which he wants to share with his colleagues. To do this, he wants to cut the roll into N equal parts. Of course, the roll can only be cut across. Accordingly, Kostya will make N−1 cuts with a knife at regular intervals.
Upon returning from the coffee break, Vanya thought - could it have been possible to get by with a smaller number of movements if Vanya's knife had been infinitely long (in other words, if he could make as many cuts as he wanted at a time, if these cuts lie on one straight line)? It is believed that the places for cuts are planned in advance, and all cuts are made with jeweler's precision.
It turns out that it is possible. For example, if Vanya wanted to divide the roll into 4 parts, he could get by with two cuts - first he would divide the roll into two halves, and then he would combine the two halves and cut both in half at the same time.
You are given the number N, you need to say what is the minimum number of cuts you can do.

Input data format

Given one natural number N(1<=N<=2*10^9) — the number of people at the coffee break.

Output format

Print a single number — the minimum number of moves Kostya will have to make.

Comment

To cut the roll into 6 parts, Vanya will first have to cut it into two equal parts, then combine the two halves and make two cuts.
To cut the roll into 5 parts, Vanya will need to divide it in a ratio of 2:3, then combine the two rolls along the left edge and cut the larger roll into single pieces - the smaller one will also be divided into single pieces.

Data examples

Example 1
in:
6
out:
3
Example 2
in:
5
out:
3