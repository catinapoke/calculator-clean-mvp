using System;
using Data;
using Zenject;

namespace Domain
{
    public class RequestSolutionUseCase
    {
        [Inject] public IInputStorage _inputStorage;
        [Inject] public IEquationSolver _equationSolver;
        [Inject] public IResultStorage _resultStorage;
        
        public string Solve(string equation)
        {
            Result result = _equationSolver.Solve(new Equation{Value = equation});
            _resultStorage.AddResult(result);
            _inputStorage.Set(new Equation{Value = String.Empty});
            return result.Value;
        }
    }
}