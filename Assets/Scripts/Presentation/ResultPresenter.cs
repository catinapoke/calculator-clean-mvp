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
        
        private void Start()
        {
            _restoreResult.Restore();
            var results = _restoreResult.Get();
            foreach (var item in results)
            {
                _appender.Append(item);
            }
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnSolutionRequest);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnSolutionRequest);
            _restoreResult.Save();
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

