using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject shopUI;
    public ShopSlot[] shopSlots;
    private InventoryManager inventoryManager;

    public TMP_Text shopkeeperSpeech;
    public Button sellItemButton;
    public GameObject SellItemBackground;
    public Slot[] inventory;

    void Start()
    {
        shopUI.SetActive(false);
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        sellItemButton.onClick.AddListener(TaskOnClick);
        
    }

    
    void Update()
    {
        
    }



    public void DeselectAllSlots()
    {
        for (int i = 0; i < shopSlots.Length; i++)
        {
            //Debug.Log($"item slot: {itemSlots[i]}");
            Debug.Log($"shop item selected: {shopSlots[i].selectedItem}");
            shopSlots[i].selectedItem.SetActive(false);
            shopSlots[i].thisItemSelected = false;
        }
    }

    public void TaskOnClick()
    {
        shopkeeperSpeech.text = "Pick an item from your inventory you wish to sell: ";// show a list of your items 
        SellItemBackground.SetActive(true);
        inventory = inventoryManager.itemSlots;
        

    }


}
