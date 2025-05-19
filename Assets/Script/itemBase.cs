using UnityEngine;

public class itemBase : MonoBehaviour, IInteractable
{
    public ItemData itemData;

    public void Interact()
    {
        Debug.Log("Pick item" + itemData.name);
        inventoryManager.instance.addItem(itemData);
        Destroy(gameObject);
    }
}
