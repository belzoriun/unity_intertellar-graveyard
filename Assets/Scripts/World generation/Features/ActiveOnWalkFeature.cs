using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveOnWalkFeature : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnWalkOn(collision.gameObject);
    }

    protected abstract void OnWalkOn(GameObject walker);
}
