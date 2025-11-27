using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour, IPointerClickHandler
{
    //-----item data-----
    public Item Item;
    public string itemName;
    public Sprite itemSprite;
    public int quantity;
    public string itemDescription;
    public Sprite emptySprite;


    //--- what slot will display ----
    [SerializeField]
    private TMP_Text costText;
    [SerializeField]
    private Image slotImage;

    public GameObject selectedItem;
    public bool thisItemSelected;
    public bool isSlotFull;

    private InventoryManager inventoryManager;
    private ShopManager shopManager;
    private Player player;

    // when clicked on a shop slot, copy all data of item into inventory and put item into inventory
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        shopManager = GameObject.Find("ShopCanvas").GetComponent<ShopManager>();
        Debug.Log("Shop manager found!");
        player = GameObject.Find("Player").GetComponent<Player>();

    }


    void Update()
    {

    }

    public void BuyItem(Item item)
    {
        //copy item into inventory
        //remove from shop inventory

        if (player.Coins >= item.Price  && item.Price != 0  )
        {
            Debug.Log($"about to buy {itemName} from shop");
            inventoryManager.AddItem(item.name, item.Quantity, item.itemSprite, item.Description);
            Debug.Log($"player coin amount: {player.Coins}");
            player.Coins = player.Coins - item.Price;
            Debug.Log($"player coin amount: {player.Coins}");
        }
        else
        {
            Debug.Log("you dont have enough !");
        }


    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) // left mouse is clicked
        {
            OnLeftClick();
        }
    }

    public void OnLeftClick()
    {
        shopManager.DeselectAllSlots();
        selectedItem.SetActive(true);
        thisItemSelected = true;
        Debug.Log("shop item is selected");
        if (inventoryManager.isInvFull() == false && thisItemSelected == true)
        {
            Debug.Log($"about to buy item");
            BuyItem(Item);
        }
        else
        {
            Debug.Log("CANNOT BUY ");
        }

    }





}
