using UnityEngine;

namespace GamedevForge.Hints
{
    public class HintsAdapter
    {
        private HintUi _hintUi;

        public void SetTarget(Transform target)
        {
            TryCreateInfrastructure();
            _hintUi.Setup(target);
        }
        
        public void Clear() => 
            _hintUi.Clear();

        private void TryCreateInfrastructure()
        {
            if (_hintUi != null)
                return;
            
            _hintUi = Object
                .Instantiate(Resources.Load<GameObject>("HintUi"))
                .GetComponent<HintUi>();
            
            Object.DontDestroyOnLoad(_hintUi.gameObject);
            
            var settings = Resources.Load<HintsSettings>("HintsSettings");
            _hintUi.Setup(settings);
        }
    }
}