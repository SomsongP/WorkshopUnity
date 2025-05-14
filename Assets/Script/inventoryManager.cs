using System.Collections.Generic;
using UnityEngine;

public class inventoryManager : MonoBehaviour
{
    public static inventoryManager Instance;
    public List<ItemData> inventoryList = new List<ItemData>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void addItem(ItemData item)
    {
        inventoryList.Add(item);
    }
}
