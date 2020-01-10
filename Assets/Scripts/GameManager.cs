using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static GlobalVariables globalVariables;
    public GlobalVariables globalVariable;

    public List<ItemIDs> currentItems = new List<ItemIDs>();

    void Start()
    {
        instance = this;
        globalVariables = globalVariable;
    }

    public void AddItem (ItemIDs item)
    {
        currentItems.Add(item);
    }

    public bool HasItem (ItemIDs item)
    {
        return currentItems.Contains(item);
    }
}
