using UnityEngine;
using ProjectUtility;

public class NaiveNoise : Noise {
    public override float Get(float x, float y)
    {
        return Random.Range(-0.3f, 0.3f);
    }

    public override void Init()
    {
        // nothing to do...
    }

}
