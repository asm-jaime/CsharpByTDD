using System;
using System.Collections.Generic;
using System.Linq;

namespace dayofweek;

public static class ClosestDay
{
    public static DayOfWeek GetNextClosestDay(this DayOfWeek value, IList<DayOfWeek> listOfDaysOfWeek) =>
        listOfDaysOfWeek
            .Select(day => new
            {
                day = day,
                gap = value <= day ? day - value : (int)DayOfWeek.Saturday + (day - value),
            })
            .OrderBy(dayGap => dayGap.gap).First().day;
}
