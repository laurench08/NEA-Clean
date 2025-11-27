using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name;
    public string Description;    
    public int Price;
    public Sprite itemSprite;

   // public GameObject item;
    public int Quantity;
    private InventoryManager inventoryManager;



    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        Debug.Log("inventory manager found!");
    }


    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision) // when player collides with item
    {
        Debug.Log($"Player has collided with {Name}!");
        if (collision.gameObject.tag == "Player")
        {
            inventoryManager.AddItem(Name, Quantity, itemSprite, Description);
            Debug.Log($"added {Name} to inventory manager");
            Destroy(gameObject);
        }
    }

   



}
