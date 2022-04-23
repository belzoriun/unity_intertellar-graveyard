using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DestroyableFeature : MonoBehaviour
{
    [SerializeField] private float _maxLifePoints;
    [SerializeField] private LootSpecifier _lootSpecifier;

    private float _lifePoints;

    // Start is called before the first frame update
    void Start()
    {
        _lifePoints = _maxLifePoints;
    }

    // Update is called once per frame
    void Update()
    {
        if(_lifePoints <= 0)
        {
            OnObjectDestroy();
            Destroy(gameObject);
        }
    }

    public void Hit(float damage)
    {
        _lifePoints -= damage;
    }

    public abstract void OnObjectDestroy();
}
