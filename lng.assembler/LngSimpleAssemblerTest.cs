﻿using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace SolutionsByTDD
{

    [TestFixture, Description("Fixed tests")]
    class SimpleAssemblerTest
    {
        private static void Test(Dictionary<string, int> expected, Dictionary<string, int> actual)
        {
            var expectedStr = "{ " +
                              string.Join(", ", expected.Select(kv => $"{kv.Key}: {kv.Value}"))
                              + " }";
            var actualStr = "{ " +
                            string.Join(", ", actual.Select(kv => $"{kv.Key}: {kv.Value}"))
                            + " }";

            Assert.AreEqual(expected, actual, $"Expected: {expectedStr}, Actual: {actualStr}");
        }

        [Test, Description("Should work for some example programs")]
        internal void ExamplePrograms()
        {
            Test(new Dictionary<string, int> { { "a", 1 } },
                SimpleAssembler.Interpret(new[] { "mov a 5", "inc a", "dec a", "dec a", "jnz a -1", "inc a" }));
            Test(new Dictionary<string, int> { { "a", 0 }, { "b", -20 } },
                SimpleAssembler.Interpret(new[] { "mov a -10", "mov b a", "inc a", "dec b", "jnz a -2" }));
        }

    }
}

