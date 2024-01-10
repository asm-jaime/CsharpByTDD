<!-- ENGLISH -->
# Task 1

Sasha and Dima are assembling a robot that could work without human help. To do this, they need to train the AI in the robot's head. The guys decided to start with a simple thing - to teach the robot to determine the result of one move in the game of darts.

Let's remember the rules in this game. In one approach, the player makes 3 dart throws towards the target. For simplicity, we will assume that the target has the shape of a circle with radius 1 and center at point (0,0). For each of the three throws, the player is awarded points.

• If the dart hits a point within 0.1 of the center, three points are added to the player's score.

• If the dart hits a point more than 0.1 but not more than 0.8 from the center, two points are added to the player's score.

• If the dart hits a point more than 0.8 but not more than 1 from the center, one point is added to the player's score.

• If the dart misses the target, the player's score does not change.

You are given the coordinates of the darts hit as a result of three throws. Find the total number of points that were awarded as a result of this approach.

### Input format

Three lines of input data contain pairs of real numbers xi,yi - the coordinates of dart hits (−2≤x1,y1,x2,y2,x3,y3≤2).

### Output format

As an answer, print one number - the sum of points awarded as a result of three throws.

### Rating system

Points for each subtask are awarded only if all tests for that subtask and the required subtasks are successfully completed.

Example 1

in:
```
0.0 0.0
0.1 0.0
0.5 0.5
```

out:
```
8
```

Example 2

in:
```
0.5 0.5
2.0 1.0
0.05 0.05
```

out:
```
5
```

Example 3

in:
```
2.0 2.0
2.0 2.0
2.0 2.0
```

out:
```
0
```