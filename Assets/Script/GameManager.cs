using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManager instance;
    public float timeCounter = 30f;
    public ItemData targetItem;
    public int targetAmount = 5;
    public TMP_Text timeCountText;
    public Image TargetItemIcon;
    public TMP_Text TargetCurrentAmountText;
    public bool isPlayerWin = false;
    public TMP_Text endText;
    public void Start()
    {
        TargetItemIcon.sprite = targetItem.itemIcon;
        endText.gameObject.SetActive(false);
    }
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
    public InventoryPanel inventoryPanel;
    public void OpenInventoryPanel()
    {
        inventoryPanel.gameObject.SetActive(true);
        inventoryPanel.OnOpen();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }
    public void CloseInventoryPanel()
    {
        inventoryPanel.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
    

    public void Update()
    {
        if (isPlayerWin)
        {
            endText.text = "You Win!!";
            endText.gameObject.SetActive(true);
            Invoke("MenuLevel", 5f);
            return;
        }
        if(timeCounter > 0f)
        {
            timeCounter -= Time.deltaTime;
            timeCountText.text = timeCounter.ToString();
            TargetCurrentAmountText.text = "x "+(targetAmount - inventoryManager.instance.getItemAmount(targetItem)).ToString();

            if (inventoryManager.instance.getItemAmount(targetItem) >= targetAmount)
            {
                isPlayerWin = true;
            }
        }
        else //player lose
        {
            endText.text = "You Lose!!";
            endText.gameObject.SetActive(true);
            Invoke("MenuLevel", 5f);
        }
    }
    public void MenuLevel()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}
