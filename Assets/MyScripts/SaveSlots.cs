using System.Data.SqlClient;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlots : MonoBehaviour
{
    public Button SaveSlotButton;

    public GameObject loadingScreenUI;
    public GameObject titleScreenUI;
    public bool isNewSave;


    
    private InputField playerName;
    private Player player;


    //--------------- CONNECTION ------------------//
    public SqlConnection sqlConnection;
    private const string CONNECT = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\laure\\OneDrive\\Desktop\\Documents\\bloomdb.mdf;Integrated Security=True;Connect Timeout=30";


    void Start()
    {
        sqlConnection = new SqlConnection((CONNECT));
        SaveSlotButton.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {

    }


    public void TaskOnClick()
    {


        loadingScreenUI.SetActive(false);
        titleScreenUI.SetActive(false);



    }



}
