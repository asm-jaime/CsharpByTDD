<!-- ENGLISH -->
# Task 5

Irina works in a company that delivers online orders.
This company delivers through n delivery points. Point number 1 is a warehouse; all goods begin their journey from there.
There are cars running between some delivery points that can deliver a package from one point to another or vice versa. No more than 100 cars arrive at each location, and each of them is given a number from 1 to 100. Each of the cars that arrive at delivery point x has a unique number among the cars arriving at point x, but is not necessarily unique among all cars . There may be points x and y, between which more than one car runs, and the numbers of these cars will be different. However, it cannot be that a car transports parcels from point x to point x.
Ira noticed that some parcels were lost and did not reach their destination, so she decided to consider how one of the parcels would move between delivery points. Irina knows the sequence of vehicle numbers on which the parcel must travel, starting its journey to point 1. Check whether this parcel can travel its entire path and get to the final delivery point, or one day it will end up at a point where a car with the required number does not arrive .
Input format
The first line of the input data contains three numbers n, m, k - the number of delivery points, the number of vehicles running and the length of the parcel path that Irina wants to consider (1≤n≤5*10^4, 1≤m≤2*10\^ 5, 1≤k≤2*10\^5).
The next m lines contain a description of the vehicles running between delivery points. A car is described by three numbers ui, di, vi - the car runs between points ui, vi and it has the number di. (1≤ui, vi≤n, ui != vi, 1≤di≤100). It is guaranteed that only one car with number di will arrive at point ui. A similar statement is true about point vi.
The last line of the input data contains k integers ai (1≤ai≤100) - a description of the path of the parcel that Irina wants to track, namely the sequence of license plates of the cars on which the parcel should be transported.
Output format
As an answer, output a single integer - the number of the point where the parcel will end up, if the entire parcel route can be completed using the described cars, or the number 0, if it is impossible to carry the parcel to the end of its route.
Rating system
Points for each subtask are awarded only if all tests for that subtask and the required subtasks are successfully completed.

Example 1:
in:
2 3 5
1 3 2
2 3 1
1 4 2
3 3 3 3 4
out:
2

Example 2:
in:
2 2 5
1 4 2
1 3 2
3 5 5 5 5
out:
0