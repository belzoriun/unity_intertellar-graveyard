using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    private Dictionary<ElementId, GameObject> _factories;
    private IBiomeGenerator _biomeGenerator;
    private INoise _heightNoise;

    public static float CELL_SIZE { get=>30; }

    public void Init(IBiomeGenerator biomeGenerator, INoise heightNoise, Dictionary<ElementId, GameObject> factories)
    {
        _factories = factories;
        _biomeGenerator = biomeGenerator;
        _heightNoise = heightNoise; 
    }

    public GameObject Create(float x, float y)
    {
        if(_factories is null || _biomeGenerator is null || _heightNoise is null)
        {
            throw new Exception("Generator has not been initialised yet");
        }
        ElementId id = _biomeGenerator.AccessBiome(x, y).AccessBiomeElement(x, y, _heightNoise.Evaluate(x, y));
        if (_factories.ContainsKey(id) && _factories[id] != null)
        {
            GameObject o = Instantiate(_factories[id], new Vector2(x * CELL_SIZE, y * CELL_SIZE), Quaternion.identity);
            SpriteRenderer renderer = o.GetComponent<SpriteRenderer>();
            if (renderer == null)
            {
                Debug.LogError("Element " + o + " generated from id " + id + " does not have a sprite renderer");
                return null;
            }
            float xScale = 1;
            float yScale = 1;
            if(renderer.bounds.size.x != CELL_SIZE)
            {
                xScale = CELL_SIZE / renderer.bounds.size.x;
            }
            if (renderer.bounds.size.y != CELL_SIZE)
            {
                yScale = CELL_SIZE / renderer.bounds.size.y;
            }
            o.transform.localScale = new Vector3(xScale, yScale, 1);
            return o;
        }
        return null;
    }
}
