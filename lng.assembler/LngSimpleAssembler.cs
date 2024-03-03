using System;
using System.Collections.Generic;

namespace SolutionsByTDD
{
    public static class SimpleAssembler
    {
        private static Dictionary<string, int> _state = new Dictionary<string, int>();
        private static int _executionIndex = 0;

        private static void Execute(string command, string operandA)
        {
            if (command.Equals("inc"))
            {
                _state[operandA]++;
                _executionIndex++;
            }
            else if (command.Equals("dec"))
            {
                _state[operandA]--;
                _executionIndex++;
            }
        }

        private static void Execute(string command, string operandA, string operandB)
        {
            if(_state.TryGetValue(operandB, out int valueB).Equals(false))
            {
                valueB = int.Parse(operandB);
            }

            if(command.Equals("mov"))
            {
                _state[operandA] = valueB;
                _executionIndex++;
                return;
            }

            if(_state.TryGetValue(operandA, out int valueA).Equals(false))
            {
                valueA = int.Parse(operandA);
            }

            if (command.Equals("jnz"))
            {
                if (valueA == 0) valueB = 1;

                _executionIndex = _executionIndex + valueB;
            }
        }

        public static Dictionary<string, int> Interpret(string[] program)
        {
            _state = new Dictionary<string, int>();
            _executionIndex = 0;

            while (_executionIndex < program.Length)
            {
                var expression = program[_executionIndex].Split(new char[] {' '});
                if(expression.Length == 2)
                {
                    Execute(expression[0], expression[1]);
                }
                if(expression.Length == 3)
                {
                    Execute(expression[0], expression[1], expression[2]);
                }
            }

            return _state;
        }
    }
}
