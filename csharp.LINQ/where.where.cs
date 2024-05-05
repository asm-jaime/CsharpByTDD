using System.Collections.Generic;
using System.Linq;

namespace csharpLINQ;

class WhereWhere
{

    public (int, int) ExecuteExpression()
    {
        var list = new List<int>();

        var i = 10;

        var query = list.Where(x => x == i).Where(x => x < 20);
        list.Add(10);
        list.Add(15);
        list.Add(20);

        i = 15;

        var result = query.ToList();
        list.Clear();

        return (result.Count, result.FirstOrDefault());
    }
}

