﻿using numbercombinations;
using System.Linq;

namespace gamedoorstate;

enum DoorState { Stay, Open, Close }

class OpenCloseDoor
{
    internal static bool CheckOneSeries(int[] oneSeries)
    {
        int acc = 0;
        foreach(int state in oneSeries)
        {
            if(state == (int)DoorState.Open) acc++;
            if(state == (int)DoorState.Close) acc = 0;
            if(acc > 1) return false;
        }

        return true;
    }

    internal static int GetSizeOfValidSeriesByCombinatoricFormula(int states)
    {
        //((states) => Math.pow(3, states) - 2*Math.pow(3, states - 2))(2)
        //
        return states;
    }

    internal static int GetSizeOfValidSeriesByFullCombo(int states)
    {

        var doorStates = new[] { (int)DoorState.Stay, (int)DoorState.Open, (int)DoorState.Close };
        var combinator = new Combinator<int>(doorStates, states);
        var series = combinator.GetCombinations();
        return series
            .Select(oneSeries => CheckOneSeries(oneSeries))
            .Where(status => status.Equals(true))
            .Count();
    }
}
