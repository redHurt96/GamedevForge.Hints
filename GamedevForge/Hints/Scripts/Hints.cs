using UnityEngine;

namespace _Rkn.Common.Hints
{
    public static class Hints
    {
        private static HintAdapter _adapter;

        public static void SetTarget(Transform target) => _adapter.SetTarget(target);

        public static void Clear() => _adapter.Clear();
    }
}