using System.Data.SqlClient;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;


public class Player : MonoBehaviour
{
    public GameObject player;
    public string PlayerName;
    public int Health = 100;
    public int playerNum;
    public int Coins = 100;

    public TileManager tilemgr;
    public Tile currentTile;
    public Tilemap tilemap;

    private int Level;
    private InventoryManager inventoryManager;



    //----movement----
    public InputAction moveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public float speed = 3.0f;
    public Transform playerTransform; // determines player position


    // ----------connection-----------

    private const string CONNECT = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\laure\\OneDrive\\Desktop\\Documents\\bloomdb.mdf\";Integrated Security = True; Connect Timeout=30";
    public SqlConnection sqlConnection = new SqlConnection((CONNECT));

    //--------------------------------

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        moveAction.Enable();
        tilemgr = GameObject.Find("Grid").GetComponent<TileManager>();

        rigidbody2d = GetComponent<Rigidbody2D>();
        move = new Vector2();
        Vector3Int location = tilemap.WorldToCell(playerTransform.position);
        Debug.Log($"Tried to dig at cell X:{location.x} Y:{location.y} Z:{location.z}");
    }

    // Update is called once per frame
    void Update()
    {
        move = moveAction.ReadValue<Vector2>();
        Debug.Log($"Player position: {move.x} {move.y}");

        // dig action

        if (Input.GetKeyDown(KeyCode.P))
        {
            tryToDig();

        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            TryToPlant();

        }
        Vector3Int location = tilemap.WorldToCell(playerTransform.position);
        //Debug.Log($"Tried to dig at cell X:{location.x} Y:{location.y} Z:{location.z}");
    }

    private void tryToDig()
    {
        Vector3Int location = tilemap.WorldToCell(playerTransform.position);

        if (tilemap.HasTile(location))
        {
            Debug.Log($"Tried to dig at cell X:{location.x} Y:{location.y} Z:{location.z}");
            // get the image of the tilemap at position

            currentTile = tilemgr.getTile(location.x, location.y);
           
            if (currentTile.isDiggable)
            {
                Debug.Log($"I can dig here");
                tilemgr.Dig(location, currentTile);
                currentTile.tileBase = tilemgr.dirtTile;
            }
            else
            {
                Debug.Log($"Can't dig here");

            }
        }
    }

    private void TryToPlant()
    {
        // check sprite of tile 
        Vector3Int location = tilemap.WorldToCell(playerTransform.position);
        if (tilemap.HasTile(location))
        {
            Debug.Log($"Tried to plant  at cell X:{location.x} Y:{location.y} Z:{location.z}");
            if (currentTile.tileBase == tilemgr.dirtTile)
            {
                Debug.Log("YOU CAN PLANT HERE!!");
             //   tilemgr.Plant(location, currentTile);// WHY CANT I WALK ON THE TILE WHEN I MAKE A SEED TILE
                currentTile.tileBase = tilemgr.seedTile;

            }
            else
            {
                Debug.Log("cant plant here....");
            }
        }

    }



    private void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }
    public void PlayerSetup(string name)
    {

        Debug.Log(name);
        if (IsPlayerNew(name) == true)
        {
            PlayerName = name;
            Debug.Log("player is called " + name);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO Player VALUES (@playerid, @name, @health, @level, @money)", sqlConnection);
            SqlParameter playeridParam = new SqlParameter();
            playeridParam.ParameterName = "@playerid";
            playeridParam.Value = playerNum;
            command.Parameters.Add(playeridParam);

            SqlParameter nameParam = new SqlParameter();

            nameParam.ParameterName = "@name";
            nameParam.Value = name;
            command.Parameters.Add(nameParam);
            //command.Parameters.Add(nameParam.ParameterName, SqlDbType.NVarChar);
            //command.Parameters[nameParam.ParameterName].Value = name;

            SqlParameter healthParam = new SqlParameter();
            healthParam.ParameterName = "@health";
            healthParam.Value = Health;
            command.Parameters.Add(healthParam);

            SqlParameter levelParam = new SqlParameter();
            levelParam.ParameterName = "@level";
            levelParam.Value = 1;
            command.Parameters.Add(levelParam);

            SqlParameter moneyParam = new SqlParameter();
            moneyParam.ParameterName = "@money";
            moneyParam.Value = 20;
            command.Parameters.Add(moneyParam);


            Debug.Log($"player number is {playerNum}");

            Debug.Log($"{name} was added to database");
            command.ExecuteNonQuery(); //!!!!!!!!!!!!!!!!!!!!!!!
            sqlConnection.Close();
        }
        else
        {
            //load player
            sqlConnection.Open();
            SqlCommand commandTwo = new SqlCommand("SELECT * FROM Player WHERE Name=@name", sqlConnection);
            SqlParameter nameParam = new SqlParameter();
            nameParam.ParameterName = "@name";
            nameParam.Value = name;
            commandTwo.Parameters.Add(nameParam);
            using (SqlDataReader reader = commandTwo.ExecuteReader())
            {
                reader.Read();
                this.PlayerName = reader["Name"].ToString();
                this.Health = int.Parse(reader["Health"].ToString());
                this.Level = int.Parse(reader["Level"].ToString());
                this.playerNum = int.Parse(reader["PlayerID"].ToString());
                this.Coins = int.Parse(reader["Money"].ToString());
                Debug.Log($"player {PlayerName} set");
            }
            sqlConnection.Close();
        }





    }


    public bool IsPlayerNew(string name)
    {
        bool newPlayer = false;
        sqlConnection.Open();
        SqlCommand command = new SqlCommand("SELECT * FROM Player", sqlConnection);
        using (SqlDataReader reader = command.ExecuteReader())
        {
            reader.Read();
            Debug.Log(reader.HasRows);
            if (reader.HasRows && reader["Name"].ToString() != name) // for new players
            {
                newPlayer = true;
                Debug.Log("L1: setting player id....................");


            }
            else if (reader.HasRows && reader["Name"].ToString() == name) //for not new players
            {
                Debug.Log("player is not new");
            }
            else if (!reader.HasRows)
            {
                newPlayer = true;
                Debug.Log("L2: setting player id....................");
            }
        }
        sqlConnection.Close();
        if (newPlayer)
        {
            SetPlayerID();
            newPlayer = false;
        }

        return newPlayer;


    }



    public void SetPlayerID()
    {
        int playerID = 0;
        sqlConnection.Open();
        SqlCommand command = new SqlCommand("SELECT * FROM Player", sqlConnection);// loop through database 
        using (SqlDataReader reader = command.ExecuteReader())
        {
            reader.Read(); //reads the data from database
            Debug.Log(int.Parse(reader["PlayerID"].ToString()));
            playerID = int.Parse(reader["PlayerID"].ToString());

            while (reader.Read()) // while theres data present
            {
                playerID++;
                Debug.Log(reader["PlayerID"].ToString());

                Debug.Log("L2: player number set");
            }
            if (!reader.Read()) //if nothing found 
            {
                playerID++;
                Debug.Log("L1: player number set");

            }

        }
        sqlConnection.Close();
        playerNum = playerID;
    }

    public void Dig()
    {
        //check player position, first
        // Vector2Int currentPos = move.ConvertTo<Vector2Int>();
        //Vector3Int temp = currentPos.ConvertTo<Vector3Int>();
        //Debug.Log(tilemap.GetTile(temp));




    }










}
