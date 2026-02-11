using UnityEngine;
using UnityEngine.Tilemaps;

public class NPC : MonoBehaviour
{

    public string npcName;
    public int health;
    public int attack;
    public Item dropitem;
    public int defence;

    public TileManager tilemgr;
    public Tilemap tilemap;

    public float speed = 0.7f;
    public Transform targetTransform;
    public Player player;


    void Start()
    {
        tilemgr = GameObject.Find("Grid").GetComponent<TileManager>();
        GetPlayerPosition();
    }

    void Update()
    {
        canNPCmove();
    }

    public void GetPlayerPosition()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        targetTransform = player.playerTransform;
    }

    public void canNPCmove()
    {
        if (tilemgr.isPlantPresent() == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);
        }
    }


}
