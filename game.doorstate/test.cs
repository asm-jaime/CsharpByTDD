using NUnit.Framework;

namespace gamedoorstate;


[TestFixture]
public class OpenCloseDoorTest
{
    [TestCase(new int[] { 1, 1, 2, 2 }, ExpectedResult = false)]
    [TestCase(new int[] { 1, 0, 2, 1 }, ExpectedResult = true)]
    [TestCase(new int[] { 1, 2, 1, 0 }, ExpectedResult = true)]
    [TestCase(new int[] { 1, 2, 1, 1 }, ExpectedResult = false)]
    public bool ShouldCheckSeries(int[] series)
    {
        return OpenCloseDoor.CheckOneSeries(series);
    }

    //[TestCase(1, ExpectedResult = 3)]
    //[TestCase(2, ExpectedResult = 8)]
    //[TestCase(3, ExpectedResult = 21)]
    //[TestCase(4, ExpectedResult = 55)]
    [TestCase(5, ExpectedResult = 144)]
    //[TestCase(15, ExpectedResult = 2178309)]
    public int ShouldReturn21On3(int states)
    {
        return OpenCloseDoor.GetSizeOfValidSeriesByFullCombo(states);
    }

    [TestCase(1, ExpectedResult = 3)]
    [TestCase(2, ExpectedResult = 8)]
    [TestCase(3, ExpectedResult = 21)]
    [TestCase(15, ExpectedResult = 2178309)]
    public int ShouldReturnSizeOfValideSeries(int states)
    {
        return OpenCloseDoor.GetSizeOfValidSeriesByCombinatoricFormula(states);
    }

}
