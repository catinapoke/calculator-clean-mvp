using Domain;
using TMPro;
using UnityEngine;
using Zenject;

namespace Presentation
{
    public class InputPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        
        [Inject] private RestoreInputUseCase _restoreInput;
        [Inject] private ChangeEquationUseCase _changeEquation;

        private void Awake()
        {
            _inputField.text = _restoreInput.Get();
        }

        private void OnEnable()
        {
            _inputField.onValueChanged.AddListener(OnTextChanged);
        }

        private void OnDisable()
        {
            _inputField.onValueChanged.RemoveListener(OnTextChanged);
        }

        private void OnTextChanged(string text)
        {
            _changeEquation.Set(text);
        }
    }
}