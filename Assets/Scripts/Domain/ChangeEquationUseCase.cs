using Data;
using Zenject;

namespace Domain
{
    public class ChangeEquationUseCase
    {
        [Inject] private IInputStorage _inputStorage;
        
        public void Set(string text)
        {
            _inputStorage.Set(new Equation{Value = text});
        }
    }
}