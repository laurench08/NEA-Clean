using UnityEngine;
using UnityEngine.EventSystems;

public class ShopKeeper : MonoBehaviour, IPointerClickHandler
{
    
    public GameObject shopKeeper;
    public GameObject shopUI;

    Rigidbody2D rigidbody2d;
    private bool menuIsOpen;

    void Start()
    {
        
    }

 
    void Update()
    {
        
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
       
        shopUI.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shopUI.SetActive(true);
        }
    }

    private void OnCollisionExit2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shopUI.SetActive(false);
        }
    }

}
