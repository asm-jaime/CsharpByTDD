<!-- ENGLISH -->
# Task 2

Pavel trains his machine learning model to generate text. Training artificial intelligence is a very difficult task, but our hero has already achieved some results and now wants to evaluate the quality of the texts he produces.
Pasha has not yet come up with a good way to evaluate the resulting texts, so for each of them he wants to find out two simple characteristics - the length of the minimum and maximum lines in the resulting text.
Help a novice researcher and write a program that will find the necessary characteristics for the generated text.
Input format
The first line of the input file contains one integer n - the length of the generated text (1≤n≤10^6).
The second line contains the generated text, consisting of lowercase and uppercase letters of the Latin alphabet, an underscore and the “#” symbol. The "#" character is used as a line break character.
Output format
On one line, print two integers — the minimum and maximum length of the line in the text.
Rating system
Points for each subtask are awarded only if all tests for that subtask and the required subtasks are successfully completed.

Example 1
in:
5
a#aba
out:
13

Example 2
in:
31
You_know#how_to_solve#this_task
out:
8 12

Example 3
in:
9
a#b##c#d#
out:
0 1