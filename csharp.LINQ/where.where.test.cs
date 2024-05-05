using FluentAssertions;
using NUnit.Framework;

namespace csharpLINQ;

class WhereWhereTests
{
    [Test]
    public void ShouldTestExecuteExpressionReturnRightValue()
    {
        var wherewhere = new WhereWhere();

        var (count, result) = wherewhere.ExecuteExpression();

        count.Should().Be(1);
        result.Should().Be(15);
    }
}

