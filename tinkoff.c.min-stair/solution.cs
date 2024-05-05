using System;

namespace c
{
    class Solution
    {
        public static int GetMinStairClimbed(int _, int timeTillLeave, int[] floors, int leavingEmployee)
        {
            int timeDownToLeaveE = floors[leavingEmployee - 1] - floors[0];
            int timeUpToLeaveE = floors[^1] - floors[leavingEmployee - 1];
            if (timeTillLeave >= timeDownToLeaveE) return timeUpToLeaveE + timeDownToLeaveE;
            if (timeTillLeave >= timeUpToLeaveE) return timeDownToLeaveE + timeUpToLeaveE;

            if (timeUpToLeaveE < timeDownToLeaveE) return 2 * timeUpToLeaveE + timeDownToLeaveE;
            if (timeUpToLeaveE >= timeDownToLeaveE) return 2 * timeDownToLeaveE + timeUpToLeaveE;
            return 0;
        }
    }
}
