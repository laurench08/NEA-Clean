using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Tile[,] tileArray = new Tile[100,100];

    //-----------assets--------
    public TileBase dirtTile;
    public TileBase grassTile;
    //-------------------------

    public Tilemap tilemap;

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

        Tile currentTile = tileArray[tileArrayX,tileArrayY];
        currentTile.realX = x;
        currentTile.realY = y;
        Debug.Log($"getting tile array X:{x}, Y:{y}");

        return currentTile;
    }
    public void Dig(Vector3Int location, Tile tile)
    {
        if (tile.isDiggable)
        {
            Debug.Log("preparing to dig....."); // YAY IT SAYS UP TO HERE
            tilemap.SetTile(location, dirtTile);
            Debug.Log("CHANGED TILE!!!!");
            tile.isDiggable = false; // you can only dig it once
        }
    }

    void Update()
    {
        
    }

    public void SetTileSprite(Vector3Int location)
    {

       // tilemap.SetTile(location, tileBase);

    }

}
