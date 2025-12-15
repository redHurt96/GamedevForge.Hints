using UnityEngine;

namespace GamedevForge.Hints
{
    public class HintAdapter
    {
        private HintUi _hintUi;

        public void SetTarget(Transform target)
        {
            TryCreateCanvas();
            _hintUi.Setup(target);
        }
        
        public void Clear() => 
            _hintUi.Clear();

        private void TryCreateCanvas()
        {
            if (_hintUi != null)
                return;
            
            _hintUi = Object
                .Instantiate(Resources.Load<GameObject>("HintUi"))
                .GetComponent<HintUi>();
            
            Object.DontDestroyOnLoad(_hintUi.gameObject);
        }
    }
}