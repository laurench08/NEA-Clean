using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Slot[] itemSlots;
    public Slot[] sellItemSlots;
    public GameObject inventoryUI;
    public bool isMenuActivated;



    void Start()
    {

        isMenuActivated = false;
        inventoryUI.SetActive(false);

    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && !isMenuActivated) // if key is pressed and inventory is not open then open it
        {
            inventoryUI.SetActive(true);
            isMenuActivated = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isMenuActivated)
        {
            inventoryUI.SetActive(false);
            isMenuActivated = false;
        }
        LoadInvToShop();

    }

    public void AddItem(string name, int quantity, Sprite sprite, string description) 
    {

        Debug.Log($"added: {name}, with description: {description}");
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].isSlotFull == false)
            {
                itemSlots[i].AddItem(name, quantity, sprite, description);// add item to inventory and checking if  inventory is not full
              //  sellItemSlots[i].AddItem(name, quantity, sprite, description);
                return;
            }

        }

    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            //Debug.Log($"item slot: {itemSlots[i]}");
            Debug.Log($"item selected: {itemSlots[i].selectedItem.name}");
            itemSlots[i].selectedItem.SetActive(false);
            itemSlots[i].thisItemSelected = false;

            Debug.Log($"sell item selected: {sellItemSlots[i].selectedItem.name}");
            sellItemSlots[i].selectedItem.SetActive(false);
            sellItemSlots[i].thisItemSelected = false;
        }
    }


    public bool isInvFull()
    {
        bool fullInventory = false;
        //check if inventory full 
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].isSlotFull == true)
            {
                fullInventory = true;
            }
            else
            {
                fullInventory = false;
            }

        }
        return fullInventory;
    }

    public bool SearchFor(Item item)
    {
        bool itemFound = false;
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i] == item)
            {
                itemFound = true;
            }
        }
        if (itemFound)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

   

    public void LoadInvToShop()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            Slot currentSlot = itemSlots[i];
            sellItemSlots[i].AddItem(currentSlot.itemName, currentSlot.quantity,currentSlot.itemSprite, currentSlot.itemDescription);
        }
    }
}
