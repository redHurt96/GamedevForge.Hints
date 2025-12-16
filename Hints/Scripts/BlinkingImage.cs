using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GamedevForge.Hints
{
    [RequireComponent(typeof(Image))]
    internal class BlinkingImage : MonoBehaviour
    {
        [SerializeField] private float _maxSize = 2f;
        [SerializeField] private float _blinkTime = 2f;
        [SerializeField] private float _delayTime = 2f;
        
        private Image _image;
        private Color _originalColor;
        private Color _targetColor;
        private WaitForSeconds _delay;
        private Vector2 _maxSizeVector;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _originalColor = _image.color;
            _targetColor = new Color(_originalColor.r, _originalColor.g, _originalColor.b, 0f);
            _maxSizeVector = Vector2.one * _maxSize;
        }

        private IEnumerator Start()
        {
            float lerp;
            _delay = new WaitForSeconds(_delayTime);
            
            while (true)
            {
                _image.rectTransform.sizeDelta = Vector2.zero;
                lerp = 0f;
                
                while (_image.rectTransform.sizeDelta.y < _maxSize)
                {
                    lerp = Mathf.Clamp01(lerp + Time.deltaTime / _blinkTime);

                    _image.rectTransform.sizeDelta = Vector2.Lerp(Vector2.zero, _maxSizeVector, lerp);
                    _image.color = Color.Lerp(_originalColor, _targetColor, lerp);

                    yield return null;
                }
                
                yield return _delay;
            }
        }
    }
}