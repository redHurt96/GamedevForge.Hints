using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

namespace _Rkn.Common.Hints
{
    internal class HintUi : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        private Camera _camera;
        private Transform _target;

        private void Awake() => 
            _camera = Camera.main;

        private void Update()
        {
            if (_target == null)
            {
                if (_image.enabled)
                    Clear();
                
                return;
            }
            
            Vector3 screenPosition = _camera.WorldToScreenPoint(_target.position);
            
            if (screenPosition.z < 0f)
            {
                screenPosition.x = Screen.width / 2f - screenPosition.x;
                screenPosition.y = Screen.height;
            }
            
            screenPosition = new Vector3(
                Mathf.Clamp(screenPosition.x, 0, Screen.width), 
                Mathf.Clamp(screenPosition.y, 0, Screen.height), 
                0);
            _image.transform.position = screenPosition;
        }

        public void Setup(Transform target)
        {
            _target = target;
            _image.enabled = true;
        }

        public void Clear()
        {
            _image.enabled = false;
            _target = null;
        }
    }
}