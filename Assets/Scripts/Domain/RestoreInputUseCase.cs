using System;
using Data;
using UnityEngine;
using Zenject;

namespace Domain
{
    public class RestoreInputUseCase
    {
        [Inject] public IInputStorage _storage;

        private const string PrefsKey = "CalculatorInput";
        
        public void Save()
        {
            string text = _storage.Get().Value;
            
            PlayerPrefs.SetString(PrefsKey, text); 
            PlayerPrefs.Save();
        }
        
        public void Restore()
        {
            string text = PlayerPrefs.GetString(PrefsKey, String.Empty);
            _storage.Set(new Equation(){Value = text});
        }

        public string Get()
        {
            return _storage.Get().Value;
        }
    }
}