using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile : TileBase
{
    public bool isDiggable = true;
    public bool isPlantable;
    public Transform tilePos;
    private TileManager tilemgr;

    public Plant currentPlant;

    public TileBase tileBase;
    public Sprite tileSprite;

    public int realX;
    public int realY;

   

    public void Start()
    {
      
        tilemgr = GameObject.Find("Grid").GetComponent<TileManager>();
    }

    public void Update()
    {
        // Debug.Log($"Tile {realX} {realY} has had update called");
        if (currentPlant != null)
        {
            Debug.Log( currentPlant.Grow());
        }
    }

   

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        tileData.sprite = tileSprite;
        

    }



}


