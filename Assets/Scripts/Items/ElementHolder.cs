using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ElementHolder
{
    [SerializeField] private ElementId _id;
    [SerializeField] private GameObject _element;

    public ElementId getId()
    {
        return _id;
    }

    public GameObject getElement()
    {
        return _element;
    }
}
