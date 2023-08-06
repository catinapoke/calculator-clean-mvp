using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation
{
    [RequireComponent(typeof(ScrollRect))]
    public class ScrollTextAppender : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textPrefab;
        [SerializeField] private int _maxItems;

        private ScrollRect _rect;

        private RectTransform _scrollTransform;
        private RectTransform _containerTransform;
        private float _deltaHeight;

        private int _count = 0;

        private void Awake()
        {
            _rect = GetComponent<ScrollRect>();

            _scrollTransform = (_rect.transform as RectTransform);
            _containerTransform = _rect.transform.parent as RectTransform;
            _deltaHeight = _textPrefab.rectTransform.rect.height;
        }

        public void Append(string text)
        {
            var item = Instantiate(_textPrefab, _rect.content);
            item.transform.SetSiblingIndex(0);
            item.text = text;

            _count++;
            if (_count > _maxItems)
            {
                return;
            }

            AddDeltaHeight(_scrollTransform, _deltaHeight);
            AddDeltaHeight(_containerTransform, _deltaHeight);
        }

        private void AddDeltaHeight(RectTransform rect, float height)
        {
            Vector2 size = rect.sizeDelta;
            size.y += height;
            rect.sizeDelta = size;
        }
    }
}