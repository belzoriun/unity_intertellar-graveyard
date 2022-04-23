using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INoise
{
    public float GroundLevel { get; }
    /**
     * must send signals from 0 to 1
     * */
    public float Evaluate(float x, float y);
}
