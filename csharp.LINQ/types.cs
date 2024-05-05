using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace csharpLINQ;

class Types
{
    internal static IEnumerable<string> GetOrderedStrings(object[] objects)
    {
        // return objects.Where(str => str is string).OrderBy(str => str.Length).ThenBy(str => str);
        return objects.OfType<string>().OrderBy(str => str.Length).ThenBy(str => str);
    }
}
