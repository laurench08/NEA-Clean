using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile : TileBase
{
    public bool isDiggable;
    public bool isPlantable;

    public Vector3Int locationOnTileMap;
    private TileManager tilemgr;

    public Plant currentPlant;

    public TileBase tileBase;

    public int realX;
    public int realY;

    //---plant----
    float timer = 5f;




    public void Update()
    {
        tilemgr = GameObject.Find("Grid").GetComponent<TileManager>();
        // Debug.Log($"Tile {realX} {realY} has had update called");
        if (currentPlant != null && !currentPlant.canHarvest)
        {
            if (timer > 0)  //make a timer for plant to grow/change tile
            {
                Debug.Log(timer);
                timer -= Time.deltaTime;
            }
            else
            {
                // call grow function
                currentPlant.Grow();
                ChangeGrowthSprite(locationOnTileMap);

            }
        }
        else if (currentPlant == null)
        {
            isDiggable = true;
        }
    }

    public void ChangeGrowthSprite(Vector3Int location) // to change sprite based on growth stage of plant
    {
        int currentGS = currentPlant.GetGrowthStage();
        switch (currentGS)
        {
            case 2:
                tilemgr.tilemap.SetTile(location, tilemgr.plantTile); // same for all plants
                RestTimer(); // so it can grow another stage
                break;
            case 3:
                tilemgr.tilemap.SetTile(location, tilemgr.tomatoTile); // stage 3 is final stage
                break;
            default:
                Debug.Log($"growth stage: {currentGS} // should be 1 or 3");
                break;
        }


        Debug.Log("CHANGED TILE!!!! to plant");
    }

    public string Dig(Vector3Int location)
    {
        if (isDiggable)
        {
            locationOnTileMap = location;
            Debug.Log("preparing to dig.....");
            tileBase = tilemgr.dirtTile;
            tilemgr.tilemap.SetTile(location, tilemgr.dirtTile);
            Debug.Log("CHANGED TILE!!!! to dirt");
            isDiggable = false; // you can only dig it once
            isPlantable = true;
        }

        return $"tilebase: {tileBase}";
    }


    public void Plant(Vector3Int location)
    {
        if (isPlantable)
        {
            Debug.Log("preparing to plant....");
            tileBase = tilemgr.seedTile;
            tilemgr.tilemap.SetTile(location, tilemgr.seedTile);
            Debug.Log("CHANGED TILE!!!! to seed");
            isPlantable = false;
            currentPlant = new Vegetable("test", "description descritption");
            Debug.Log("5 SECONDS");
        }
    }

    public void RestTimer()
    {
        timer = 5;
    }



}


