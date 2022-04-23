using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LootSpecifier
{
    public Dictionary<ItemIds, int> GetLoots(); 
}
