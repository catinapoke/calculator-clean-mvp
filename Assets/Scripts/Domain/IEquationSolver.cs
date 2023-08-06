using Data;

namespace Domain
{
    public interface IEquationSolver
    {
        Result Solve(Equation equation);
    }
}