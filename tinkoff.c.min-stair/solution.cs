using System;

namespace c
{
    public class Solution
    {
        public int GetMinStairClimbed(int numEmployee, int timeTillLeave, int[] floors, int leavingEmployee)
        {
            int timeDownToLeaveE = floors[leavingEmployee - 1] - floors[0];
            int timeUpToLeaveE = floors[floors.Length - 1] - floors[leavingEmployee - 1];
            if (timeTillLeave >= timeDownToLeaveE) return timeUpToLeaveE + timeDownToLeaveE;
            if (timeTillLeave >= timeUpToLeaveE) return timeDownToLeaveE + timeUpToLeaveE;

            if (timeUpToLeaveE < timeDownToLeaveE) return 2 * timeUpToLeaveE + timeDownToLeaveE;
            if (timeUpToLeaveE >= timeDownToLeaveE) return 2 * timeDownToLeaveE + timeUpToLeaveE;
            return 0;
        }
    }
}
