using System;

using UnityEngine;

namespace Extensions
{
    public static class DebugExtended
    {
        public static void AssertNull(object target, Type type)
        {
#if DEBUG
            Debug.Assert(target != null, $"The {type.Name} isn't setted");
#endif
        }
    }
}