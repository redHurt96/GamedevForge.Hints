using UnityEngine;

namespace GamedevForge.Hints
{
    [CreateAssetMenu(menuName = "GamedevForge/Create HintsSettings", fileName = "HintsSettings", order = 0)]
    internal class HintsSettings : ScriptableObject
    {
        [field: SerializeField] public float ScreenMargin { get; private set; } = 50f;
        [field: SerializeField] public float ShowDistanceThreshold { get; private set; } = 20f;
        [field: SerializeField] public bool ShowDistance { get; private set; } = true;
    }
}