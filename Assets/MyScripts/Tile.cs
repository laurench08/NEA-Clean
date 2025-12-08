using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile : TileBase
{
    public bool isDiggable = true;
    public bool isPlantable;
    public Transform tilePos;
    public Tilemap tilemap;

    public TileBase tileBase;
    public Sprite tileSprite;

    public int realX;
    public int realY;

   

    void Start()
    {
        //isDiggable = true;
    }

    void Update()
    {

    }

   

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        tileData.sprite = tileSprite;
        

    }



}


