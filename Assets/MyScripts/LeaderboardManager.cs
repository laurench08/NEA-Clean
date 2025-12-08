using System.Data.SqlClient;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    // ----------connection-----------

    private const string CONNECT = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\laure\\OneDrive\\Desktop\\Documents\\bloomdb.mdf\";Integrated Security = True; Connect Timeout=30";
    public SqlConnection sqlConnection = new SqlConnection((CONNECT));

    //--------------------------------

    public Button showLB;
    public GameObject LeaderboardUI;


    void Start()
    {


        displayLeaderBoard();
        LeaderboardUI.SetActive(false);
        showLB.onClick.AddListener(ShowLeaderBoardUI);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowLeaderBoardUI()
    {
        LeaderboardUI.SetActive(true);
    }

    public void displayLeaderBoard()
    {
        sqlConnection.Open();

        // get all player's name and coin amount only
        SqlCommand command = new SqlCommand("SELECT Name, Money FROM Player ORDER BY Money DESC", sqlConnection);
        using (SqlDataReader reader = command.ExecuteReader())
        {
           
            string name = "";
            string money = "0";
            int counter = 0;
            int maxLBEntry = 5;
            while (reader.Read() && counter <= maxLBEntry) 
            {
              
                name = reader["Name"].ToString();
                money = reader["Money"].ToString();
                Debug.Log(name);
                Debug.Log(money);
                GameObject temp = GameObject.Find($"LBNameCoins{counter}");
                Debug.Log(temp.name);
                var nametxt = temp.transform.Find("LBNameText");
                Debug.Log(nametxt.name);
                nametxt.GetComponent<TextMeshProUGUI>().text = name;

                temp.transform.Find("LBCoinText").GetComponent<TextMeshProUGUI>().text = money;
                temp.SetActive(true);
                counter++;

            }


        }
        sqlConnection.Close();




    }


}
