using System.Text.RegularExpressions;
using Data;

namespace Domain
{
    public class EquationSolver : IEquationSolver
    {
        // Matches only single number and addition of numbers like "117+316+92"
        private const string Pattern = @"^[0-9]+(\+[0-9]+)*$";
        private const string ErrorResult = "ERROR";
        
        private readonly Regex _matcher;

        public EquationSolver()
        {
            _matcher = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
        
        public Result Solve(Equation equation)
        {
            if (!_matcher.IsMatch(equation.Value))
            {
                return GenerateResult(equation, ErrorResult);
            }

            long result = 0;
            foreach (var item in equation.Value.Split("+"))
            {
                if (long.TryParse(item, out long parsed))
                {
                    result += parsed;
                }
                else
                {
                    return GenerateResult(equation, ErrorResult);
                }
            }

            return GenerateResult(equation, result.ToString());
        }

        private Result GenerateResult(Equation equation, string result)
        {
            return new Result{Value = equation.Value + "=" + result};
        }
    }
}