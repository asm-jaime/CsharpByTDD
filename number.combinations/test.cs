using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace numbercombinations;


[TestFixture]
public class ProofOfThreeAndFiveTest
{
    [Test]
    public void ShouldCreateCombinations()
    {
        var elements = new[] { 1, 2 };
        const int size = 2;
        var combinator = new Combinator<int>(elements, size);
        combinator.GetCombinations().Should().BeEquivalentTo(
            new List<int[]> { new int[] { 1, 1 }, new int[] { 1, 2 }, new int[] { 2, 1 }, new int[] { 2, 2 } }
        );
        //combinator.Should().Be()
    }

    [Test]
    public void ShouldProofPassabilityComboOfThreeAndFiveForEvenToTwenty()
    {
        /*
        var elements = new[] {3, 5};
        var combinations = new Combinator<int>(elements, 3).GetCombinations();
        combinations.AddRange(new Combinator<int>(elements, 4).GetCombinations());
        */
        ProofOfThreeAndFive.IsAllRangeCanBeCombinedByNumbers(11, 20, new int[] { 3, 5 }).Should().BeTrue();
        //ProofOfThreeAndFive.IsAllRangeCanBeCombinedByThreeAndFive(11, 20, combinations).Should().BeTrue();
        //List<int[]> combinations = combinationsForThreeSize.Join<List<int[]>, List<int[]>, int[], int[]>(combinationsForFourSize);
        /*
        combinator.GetCombinations().Should().BeEquivalentTo(
            new List<int[]> { new int[] { 1, 1 }, new int[] { 1, 2 }, new int[] { 2, 1 }, new int[] {2 ,2} }
        );
        */
        //combinator.Should().Be()
    }
}
