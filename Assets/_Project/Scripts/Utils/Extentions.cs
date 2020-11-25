using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    public static class Extentions
    {
        private const float EqualityThreshold = 0.0000001f;

        public static bool IsEqual(this Vector3 a, Vector3 b)
        {
            return (a - b).sqrMagnitude <= EqualityThreshold;
        }
    }
}
