using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllegalHitException : Exception
{
    public IllegalHitException() : base("Tried to hit unattackable object")
    {

    }
}
