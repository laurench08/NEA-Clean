using System.Data.SqlClient;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnterNameButton : MonoBehaviour
{

    public Button enterNameButton;
    public Player player;
    public GameObject PlayerScreenUI;
    public GameObject inputName;


    // ----------connection-----------

    private const string CONNECT = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\laure\\OneDrive\\Desktop\\Documents\\bloomdb.mdf\";Integrated Security = True; Connect Timeout=30";
    public SqlConnection sqlConnection = new SqlConnection((CONNECT));


    void Start()
    {
        enterNameButton.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {

        Debug.Log("name button clicked");
        string name;
        name = inputName.gameObject.GetComponent<TextMeshProUGUI>().text; //fixed
        Debug.Log($"---{name}---");
        player.PlayerSetup(name);

        Debug.Log($"player name is : {name} ");
        PlayerScreenUI.SetActive(false);

        //  Debug.Log("Player's name was entered");


    }



}
