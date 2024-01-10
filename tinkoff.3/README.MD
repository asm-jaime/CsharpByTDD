<!-- ENGLISH -->
# Task 3

Maria is building a city in a famous mobile game.

Each city district has its own integer height above the surface ai. In this game there is exactly one road that connects n districts of this city. The road smoothly overcomes the elevation changes in the city. For example, if two neighboring areas i and i+1 have different heights x and y (x<y), then the road rises smoothly from area i to area i+1. Likewise, the road can descend.

Today Masha learned that she can finally turn the road into a highway. Unlike a regular road, the highway runs the same distance from the surface in all areas.

Maria wants to rebuild her existing road into a highway in such a way that the total level of the road at all points does not change. That is, she wants to choose a highway height such that the total area in the section by which some sections of the road will have to be raised is equal to the total area by which other sections of the road will need to be lowered.

Help Masha and find the level above the surface where you need to build a highway.

### Input format

The first line of the input data contains one number n - the number of districts in the city (1≤n≤5*10\^5). The second line contains n integers ai - levels of city districts (0≤ai≤10\^5).

### Output format

Print a single real number - the answer to the problem. The accuracy of the answer must be at least 10\^-4.

### Rating system

Points for each subtask are awarded only if all tests for that subtask and the required subtasks are successfully completed.

Example 1

in:
```
3
1 2 3
```
out:
```
2.0
```

Example 2

in:
```
4
1 1 1 1
```
out:
```
1.0
```

Example 3

in:
```
4
0 1 1 0
```
out:
```
0.6666666666666666
```