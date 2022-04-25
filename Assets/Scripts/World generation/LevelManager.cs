using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _registryHolder;

    private WorldGenerator _generator;

    // Start is called before the first frame update
    void Start()
    {
        Registry reg = _registryHolder.GetComponent<Registry>();
        if(reg == null)
        {
            throw new System.Exception("Can't initialise registry !");
        }
        _generator = ScriptableObject.CreateInstance<WorldGenerator>();
        _generator.Init(null, new OpenSimplexNoise(Random.Range(0, 1)*10000000000000L), reg);
    }
}
