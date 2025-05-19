using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image selectIcon;
    public TMP_Text desText;
    public Transform rightPanelTransform;
    public GameObject itemBtnPrefabs;
    public void OnOpen()
    {
        for (int i = rightPanelTransform.childCount - 1; i >= 0; i--)
        {
            Destroy(rightPanelTransform.GetChild(i).gameObject);
        }

        for (int i = 0; i <inventoryManager.instance.inventoryList.Count; i++)
        {
            GameObject itemButtonObj = Instantiate(itemBtnPrefabs, rightPanelTransform);
            ItemBtn itemButtonComp = itemButtonObj.GetComponent<ItemBtn>();
            itemButtonComp.data = inventoryManager.instance.inventoryList[i];
            itemButtonComp.icon.sprite = itemButtonComp.data.itemIcon;
            Button button = itemButtonObj.GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                selectIcon.sprite = itemButtonComp.data.itemIcon;
                desText.text = itemButtonComp.data.itemDescription;
            });

        }
    }
}
