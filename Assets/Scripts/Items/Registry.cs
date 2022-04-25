using System.Collections.Generic;
using UnityEngine;

public class Registry : MonoBehaviour
{

    [SerializeField] private ElementHolder[] _elementsHolder;

    private Dictionary<ElementId, GameObject> _gameElementsFactories;

    private void Awake()
    {
        _gameElementsFactories = new Dictionary<ElementId, GameObject>();
        foreach(ElementHolder holder in _elementsHolder)
        {
            if (holder.getElement() == null)
            {
                Debug.Log("Skipped " + holder.getId() + " : null element");
                continue;
            }
            if (_gameElementsFactories.ContainsKey(holder.getId()))
            {
                Debug.Log("Skipped " + holder.getId() + " : already registered");
                continue;
            }
            _gameElementsFactories.Add(holder.getId(), holder.getElement());
        }
    }

    public GameObject GetElement(ElementId key)
    {
        return _gameElementsFactories[key];
    }
}
