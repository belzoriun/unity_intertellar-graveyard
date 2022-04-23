using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect
{
    private float _effectDuration;
    private float _effectCooldown;
    private float _cooldownCounter;

    protected Effect(float effectDuration, float effectCooldown)
    {
        _effectCooldown = effectCooldown;
        _effectDuration = effectDuration;
        _cooldownCounter = _effectCooldown;
    }

    public float GetDurationLeft()
    {
        return _effectDuration;
    }

    public void ApplyOn(GameObject apply)
    {
        _cooldownCounter -= Time.deltaTime;
        if (_cooldownCounter <= 0)
        {
            Act(apply);
            _cooldownCounter = _effectCooldown;
        }
        _effectDuration -= Time.deltaTime;
        if(_effectDuration <= 0)
        {
            apply.GetComponent<EffectAppliableFeature>().RemoveEffect(this);
        }
    }

    protected abstract void Act(GameObject apply);
}
