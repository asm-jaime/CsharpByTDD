﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace dayofweek;

internal static class ClosestDay
{
    internal static DayOfWeek GetNextClosestDay(this DayOfWeek value, IList<DayOfWeek> listOfDaysOfWeek) =>
        listOfDaysOfWeek
            .Select(day => new
            {
                day,
                gap = value <= day ? day - value : (int)DayOfWeek.Saturday + (day - value),
            })
            .OrderBy(dayGap => dayGap.gap).First().day;
}
