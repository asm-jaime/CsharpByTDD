<!-- ENGLISH -->
# Task a

Kostya is connected to the mobile operator "Mobile". Kostya's subscription fee is A rubles per month. For this cost, Kostya gets B megabytes of Internet traffic. If Kostya goes beyond the traffic limit, then each next megabyte will cost him C rubles.

Kostya plans to spend D megabytes of Internet traffic next month. Help him calculate how much the Internet will cost him.

Input data format

Enter 4 positive integers

A,B,C,D(1<=A,B,C,D<=100) — Cost of Kostya's tariff, Kostya's tariff size, cost of each extra megabyte, Kostya's Internet traffic size in the next month. The numbers in the input file are separated by spaces.

Output format

Print one natural number — Kostya's total expenses for the Internet.

Comment

In the first example, Kostya will first pay for the Internet package, after which he will spend 5 megabytes more than allowed by the tariff. Therefore, for 5 megabytes it supplements separately, the resulting cost is 100 + 12 * 5 = 160 rubles.
In the second example, Kostya fits into the tariff plan, so he pays only for it.

Data examples

Example 1
in:
100 10 12 15
out:
160
Example 2
in:
100 10 12 1
out:
100