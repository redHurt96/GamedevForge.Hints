using TMPro;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace GamedevForge.Hints
{
    internal class HintUi : MonoBehaviour
    {
        [SerializeField] private RectTransform _image;
        [SerializeField] private RectTransform _direction;
        [SerializeField] private TextMeshProUGUI _distance;
        [SerializeField] private float _screenMargin = 10f;
        [SerializeField] private float _showDistanceThreshold = 20f;
        
        private Camera _camera;
        private Transform _target;

        private void Awake() => 
            _camera = Camera.main;

        private void Update()
        {
            if (_target == null)
            {
                if (_image.gameObject.activeSelf)
                    Clear();
                
                return;
            }
            
            Vector3 screenPosition = _camera.WorldToScreenPoint(_target.position);
            
            if (screenPosition.z < 0f)
            {
                screenPosition.x = Screen.width / 2f - screenPosition.x;
                screenPosition.y = Screen.height;
            }

            bool onEdge = IsPointOnEdge(screenPosition);
            
            _direction.gameObject.SetActive(onEdge);
            
            if (onEdge)
            {
                UpdateRotateDirection(screenPosition);
                _distance.enabled = false;
            }
            else
            {
                float distance = Vector3.Distance(_camera.transform.position, _target.position);
                
                if (distance > _showDistanceThreshold)
                {
                    _distance.enabled = true;
                    _distance.text = distance.ToString("F0") + "m";
                }
                else
                {
                    _distance.enabled = false;
                }
            }
                
            screenPosition = new Vector3(
                Mathf.Clamp(screenPosition.x, _screenMargin, Screen.width - _screenMargin), 
                Mathf.Clamp(screenPosition.y, _screenMargin, Screen.height - _screenMargin), 
                0);
            
            _image.transform.position = screenPosition;
        }

        public void Setup(Transform target)
        {
            _target = target;
            _image.gameObject.SetActive(true);
        }

        public void Clear()
        {
            _image.gameObject.SetActive(false);
            _target = null;
        }

        private bool IsPointOnEdge(Vector3 screenPosition) =>
            screenPosition.x <= 0f || screenPosition.x >= Screen.width ||
            screenPosition.y <= 0f || screenPosition.y >= Screen.height;

        private void UpdateRotateDirection(Vector3 screenPosition)
        {
            Vector3 direction = (screenPosition - new Vector3(Screen.width / 2f, Screen.height / 2f, 0f)).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _direction.rotation = Quaternion.Euler(0f, 0f, angle - 45f);
        }
    }
}