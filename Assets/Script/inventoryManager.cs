using System.Collections.Generic;
using UnityEngine;

public class inventoryManager : MonoBehaviour
{
    public static inventoryManager instance;
    public List<ItemData> inventoryList = new List<ItemData>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
    public int getItemAmount(ItemData data)
    {
        int amount = 0;
        foreach (ItemData item in inventoryList)
        {
            if(item == data)
                amount++;
        }
        return amount;
    }
}
