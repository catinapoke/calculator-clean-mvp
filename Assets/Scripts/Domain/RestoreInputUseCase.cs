using Data;
using Zenject;

namespace Domain
{
    public class RestoreInputUseCase
    {
        [Inject] public IInputStorage _storage;
        
        public string Get()
        {
            return _storage.Get().Value;
        }
    }
}