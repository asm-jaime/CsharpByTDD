<!-- ENGLISH -->
# Task Spiral Pattern Generator

Your goal is to write a function that generates a square matrix of a given size that contains a unique spiral pattern. The pattern consists of 1s marking the path of the spiral and 0s filling the rest of the matrix space. The spiral starts at the top-left corner, extends to the right, and curls inwards in a clockwise direction.

The challenge is to ensure that the spiral never overlaps itself, maintaining a consistent path marked by 1s, while the areas not part of the spiral are filled with 0s. The width of the spiral path is a single unit throughout.


### Comment


Example 1

in:
```
3
```
out:
```
1 1 1
0 0 1
1 1 1
```

Example 2

in:
```
5
```
out:
```
1 1 1 1 1
0 0 0 0 1
1 1 1 0 1
1 0 0 0 1
1 1 1 1 1
```

Example 3

in:
```
8
```
out:
```
1 1 1 1 1 1 1 1
0 0 0 0 0 0 0 1
1 1 1 1 1 1 0 1
1 0 0 0 0 1 0 1
1 0 1 0 0 1 0 1
1 0 1 1 1 1 0 1
1 0 0 0 0 0 0 1
1 1 1 1 1 1 1 1
```