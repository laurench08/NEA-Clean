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
    public TileBase tomatoTile;

    public Sprite tomatoSprite;
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
        //  Normalize x,y to not be negative, starting at the ss
        int tileArrayX = x + 30;
        int tileArrayY = y + 14;

        Tile currentTile = tileArray[tileArrayX, tileArrayY];
        currentTile.realX = x;
        currentTile.realY = y;
        Debug.Log($"getting tile array X:{x}, Y:{y}");

        return currentTile;
    }


    void Update()
    {
        for (int i = 0; i < 100; i++)
            for (int j = 0; j < 100; j++)
                tileArray[i, j].Update(); // constantly checking each tile
    }

}
