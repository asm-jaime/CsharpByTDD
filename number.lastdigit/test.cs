using NUnit.Framework;
using System;

namespace numberlastdigit;

public struct LDCase
{
    public int[] test;
    public int expect;
    public LDCase(int[] t, int e)
    {
        test = t;
        expect = e;
    }
}

[TestFixture]
public class SolutionTest
{
    [Test]
    public void SampleTest()
    {
        Random rnd = new Random();
        int rand1 = rnd.Next(0, 100);
        int rand2 = rnd.Next(0, 10);

        LDCase[] allCases = new LDCase[] {
                new LDCase(new int[0],           1),
                new LDCase(new int[] {0,0},      1),
                new LDCase(new int[] {0,0,0},    0),
                new LDCase(new int[] {1,2},      1),
                new LDCase(new int[] {3,4,5},    1),
                new LDCase(new int[] {7,6,21},   1),
                new LDCase(new int[] {12,30,21}, 6),
                new LDCase(new int[] {937640,767456,981242}, 0),
                new LDCase(new int[] {123232,694022,140249}, 6),
                new LDCase(new int[] {499942,898102,846073}, 6),

                new LDCase(new int[] {rand1}, rand1%10),
                new LDCase(new int[] {rand1,rand2}, (int)Math.Pow(rand1%10,rand2)%10)
            };
        for(int i = 0; i < allCases.Length; i++)
        {
            Assert.That(Calculator.LastDigit(allCases[i].test), Is.EqualTo(allCases[i].expect));
        }
    }
    [Test]
    public void SampleTest2220()
    {
        Assert.That(Calculator.LastDigit(new int[] { 2, 2, 2, 0 }), Is.EqualTo(4));
    }
    [Test]
    public void SampleTest000()
    {
        Assert.That(Calculator.LastDigit(new int[] { 0, 0, 0 }), Is.EqualTo(0));
    }
    [Test]
    public void SampleTest00()
    {
        Assert.That(Calculator.LastDigit(new int[] { 0, 0 }), Is.EqualTo(1));
    }

    [Test]
    public void SampleTest0()
    {
        Assert.That(Calculator.LastDigit(new int[0]), Is.EqualTo(1));
    }

    [Test]
    public void SampleTest1()
    {
        Assert.That(Calculator.LastDigit(new int[] { 2, 3, 4, 5, 6 }), Is.EqualTo(2));
    }

    [Test]
    public void SampleTest2()
    {
        Assert.That(Calculator.LastDigit(new int[] { 12, 30, 21 }), Is.EqualTo(6));
    }

    [Test]
    public void SampleTestLargeSample()
    {
        Assert.That(Calculator.LastDigit(new int[] { 123232, 694022, 140249 }), Is.EqualTo(6));
    }

}
