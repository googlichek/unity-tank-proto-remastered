using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    public class StaticMethods : MonoBehaviour
    {
        public static bool EnumEquals<TEnum>(TEnum first, TEnum second) where TEnum : struct
        {
            var firstValueType = first as TEnum?;
            var secondValueType = second as TEnum?;

            return EqualityComparer<TEnum>.Default.Equals(firstValueType.Value, secondValueType.Value);
        }
    }
}
