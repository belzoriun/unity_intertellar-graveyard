using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLootSpecifier : MonoBehaviour, LootSpecifier
{
    private class LootingData
    {
        public ItemIds Id;
        public int Min;
        public int Max;
    }

    [SerializeField] private List<LootingData> _data;

    private void Start()
    {
        _data = new List<LootingData>();
    }

    public RandomLootSpecifier LootsItem(ItemIds id, int min, int max)
    {
        if(min < 0 || max < min)
        {
            throw new System.Exception("Specified range is illegal");
        }
        _data.Add(new LootingData()
        {
            Id = id,
            Max = max,
            Min = min
        });
        return this;
    }

    public Dictionary<ItemIds, int> GetLoots()
    {
        Dictionary<ItemIds, int> items = new Dictionary<ItemIds, int>();
        foreach(LootingData data in _data)
        {
            int nb = Random.Range(data.Min, data.Max);
            items.Add(data.Id, nb);
        }
        return items;
    }
}
