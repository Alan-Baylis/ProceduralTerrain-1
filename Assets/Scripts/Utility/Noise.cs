using UnityEngine;
using System.Collections;

namespace ProjectUtility
{
    public abstract class Noise : MonoBehaviour
    {
        public abstract void Init();
        public abstract float Get(float x, float y);
    }
}
