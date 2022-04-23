using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBiome
{
    public ElementId AccessBiomeElement(float x, float y, float height);
}
