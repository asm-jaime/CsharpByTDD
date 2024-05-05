using System.Collections.Generic;
using System.Linq;

namespace extremums;

class PickPeaks
{
    internal static Dictionary<string, List<int>> GetPeaks(int[] arr)
    {
        var skipPlateau = arr
          .Select((element, index) => new { Element = element, Index = index })
          .Where((element, index) =>
          {
              if(index == 0) return true;
              if(index == arr.Length - 1) return true;
              if(element.Element == arr[index - 1]) return false;
              return true;
          }).ToArray();

        var results = skipPlateau.Where((element, index) =>
          {
              if(index == 0) return false;
              if(index == skipPlateau.Length - 1) return false;
              if(
                  element.Element > skipPlateau[index - 1].Element &&
                  element.Element > skipPlateau[index + 1].Element
              ) return true;

              return false;
          });

        var pos = results.Select(element => element.Index).ToList();
        var peaks = results.Select(element => element.Element).ToList();
        var result = new Dictionary<string, List<int>>() { { "pos", pos }, { "peaks", peaks } };
        return result;
    }
}
