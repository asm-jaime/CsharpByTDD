<!-- ENGLISH -->
# Difference Between Ones and Zeros in Row and Column

You are given a 0-indexed m x n binary matrix grid.

A 0-indexed m x n difference matrix diff is created with the following procedure:

Let the number of ones in the ith row be onesRowi.
Let the number of ones in the jth column be onesColj.
Let the number of zeros in the ith row be zerosRowi.
Let the number of zeros in the jth column be zerosColj.
diff[i][j] = onesRowi + onesColj - zerosRowi - zerosColj
Return the difference matrix diff.

grid[i][j] is either 0 or 1.

Example 1
in:
[[0,1,1],[1,0,1],[0,0,1]]
out:
[[0,0,4],[0,0,4],[-2,-2,2]]
Example 2
in:
[[1,1,1],[1,1,1]]
out:
[[5,5,5],[5,5,5]]