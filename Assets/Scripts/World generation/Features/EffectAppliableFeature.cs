using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAppliableFeature : MonoBehaviour
{
    private List<Effect> _effects;
    // Update is called once per frame
    void Update()
    {
        foreach (Effect effect in _effects)
            effect.ApplyOn(gameObject);
    }

    public void ApplyEffect(Effect effect)
    {
        _effects.Add(effect);
    }

    public void RemoveEffect(Effect effect)
    {
        _effects.Remove(effect);
    }

    public List<Effect> GetEffects()
    {
        return _effects;
    }
}
