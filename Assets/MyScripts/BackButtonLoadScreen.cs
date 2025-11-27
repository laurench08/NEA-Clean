using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class BackButtonLoadScreen : MonoBehaviour
{
    public Button backButton;
    public GameObject titleScreenParent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backButton.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
      Debug.Log("back button was clicked");
      titleScreenParent.SetActive(true);

    }

}
