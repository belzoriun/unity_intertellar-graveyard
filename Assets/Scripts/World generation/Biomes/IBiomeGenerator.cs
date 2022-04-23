using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBiomeGenerator
{
    public IBiome AccessBiome(float x, float y);
}
