using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{

    //-----item data-----
    public Item Item;
    public string itemName;
    public Sprite itemSprite;
    public int quantity;
    public string itemDescription;
    public Sprite emptySprite;

    // ----item desc---
    public Image itemDescImage;
    public TMP_Text itemDescNameText;
    public TMP_Text itemDescText;


    //--- what slot will display ----
    [SerializeField]
    private TMP_Text quantityText;
    [SerializeField]
    private Image slotImage;

    public GameObject selectedItem;
    public bool thisItemSelected;

    public bool isSlotFull;
    private InventoryManager inventoryManager;

    public Button dropItemButton;
    public bool isDroppingItem;



    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        dropItemButton.onClick.AddListener(TaskOnClick);
    }


    void Update()
    {

    }

    public void AddItem(string name, int quantity, Sprite sprite, string description)
    {
        //assign variables
        this.itemName = name;
        this.quantity = quantity;
        this.itemSprite = sprite;
        this.itemDescription = description;
        isSlotFull = true;

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        slotImage.sprite = sprite;


    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) // left mouse is clicked
        {
            OnLeftClick();
        }
    }

    public void OnLeftClick() // when clicking on an item in inventory
    {
        inventoryManager.DeselectAllSlots();
        selectedItem.SetActive(true);
        thisItemSelected = true;


        itemDescNameText.text = itemName;
        itemDescText.text = itemDescription;
        itemDescImage.sprite = itemSprite;
    }

    public void TaskOnClick()
    {
        //check if slot is empty
        if (this.isSlotFull && this.thisItemSelected)
        {
           // Debug.Log(selectedItem.GetComponent<Item>().Name);

            //create a new item, copy the script into temproary one
            GameObject itemToDrop = new GameObject(itemName);
            Item newItem = itemToDrop.AddComponent<Item>();
            newItem.Quantity = 1;
            newItem.Name = itemName;
            newItem.itemSprite = itemSprite;
            newItem.Description = itemDescription;

            //copy sprite renderer
            SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
            sr.sprite = itemSprite;
            sr.sortingOrder = 0;

            //add collider
            itemToDrop.AddComponent<BoxCollider2D>();

            //spawn item to the left of the player
            itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(-1.5f, 0, 0);

            // then remove it from inventory
            this.quantity -= 1;
            quantityText.text = this.quantity.ToString();

            if (this.quantity <= 0)
            {
                EmptySlot();
            }
        }
        else
        {
            Debug.Log("slot is empty");
        }




    }
    private void EmptySlot()
    {
        quantityText.enabled = false;
        slotImage.sprite = emptySprite;
        isSlotFull = false;

        itemDescNameText.text = "";
        itemDescText.text = "";
        itemDescImage.sprite = emptySprite;
    }


    public Item GetItem()
    {

        return null;
    }



















}
