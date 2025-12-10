using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Tile[,] tileArray = new Tile[100, 100];

    //-----------assets--------
    public TileBase dirtTile;
    public TileBase grassTile;
    public TileBase seedTile;
    public TileBase plantTile;
    //-------------------------
    //public TileBase

    public Tilemap tilemap;

    //---plant----
    float timer = 0f;
    bool timerActive = true;
    bool hasGrown = false;
    //--------------

    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                Tile t = new Tile();

                tileArray[i, j] = t;
            }
        }
    }
    


    public Tile getTile(int x, int y)
    {
        //  Normaliza x,y to not be negative, starting at the ss
        int tileArrayX = x + 30;
        int tileArrayY = y + 14;

        Tile currentTile = tileArray[tileArrayX, tileArrayY];
        currentTile.realX = x;
        currentTile.realY = y;
        Debug.Log($"getting tile array X:{x}, Y:{y}");

        return currentTile;
    }
    public void Dig(Vector3Int location, Tile tile)
    {
        if (tile.isDiggable)
        {
            Debug.Log("preparing to dig.....");
            tile.tileBase = dirtTile;
            tilemap.SetTile(location, dirtTile);
            Debug.Log("CHANGED TILE!!!! to dirt");
            tile.isDiggable = false; // you can only dig it once
            tile.isPlantable = true;

            tile.currentPlant = new Vegetable("testveg");
        }
    }

    public void Plant(Vector3Int location, Tile tile)
    {
        if (tile.isPlantable)
        {
            Debug.Log("preparing to plant....");
            tile.tileBase = seedTile;
            tilemap.SetTile(location, seedTile);
            Debug.Log("CHANGED TILE!!!! to seed");
            tile.isPlantable = false;
            tile.currentPlant = new Vegetable("testveg");
            //Debug.Log("Time1: " + Time.deltaTime);
            //float timeOfPlant = Time.deltaTime;

            Debug.Log("5 SECONDS");
            //make a timer for it to grow/change tile
            


        }



    }
    public void Grow(Vector3Int location)
    {
       
        tilemap.SetTile(location, plantTile);
        Debug.Log("CHANGED TILE!!!! to plant");
    }

    void Update()
    {
//        Debug.Log("Called tilemgr update()");
        for (int i = 0; i < 100; i++)
            for (int j = 0; j < 100; j++)
                tileArray[i, j].Update();
    }

    public void SetTileSprite(Vector3Int location)
    {

        // tilemap.SetTile(location, tileBase);

    }

}
