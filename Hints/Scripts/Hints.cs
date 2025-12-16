using UnityEngine;

namespace GamedevForge.Hints
{
    public static class Hints
    {
        private static readonly HintsAdapter _adapter = new HintsAdapter();

        public static void SetTarget(Transform target) => _adapter.SetTarget(target);

        public static void Clear() => _adapter.Clear();
    }
}