using System;
using Domain;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Presentation
{
    public class ResultPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _button;
        
        [SerializeField] private ScrollTextAppender _appender;
        
        [Inject] private RestoreResultUseCase _restoreResult;
        [Inject] public RequestSolutionUseCase _requestSolution;

        private ScrollRect _rect;
        
        private void Awake()
        {
            var results = _restoreResult.Get();
            foreach (var item in results)
            {
                _appender.Append(_requestSolution.Solve(item));
            }
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnSolutionRequest);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnSolutionRequest);
        }

        private void OnSolutionRequest()
        {
            if (_inputField.text.Equals(String.Empty))
            {
                return;
            }
            
            string text = _inputField.text;
            _appender.Append(_requestSolution.Solve(text));
            _inputField.text = String.Empty;
        }
    }
}

