using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PlayMenuButton : MonoBehaviour
{
    public Button playButton;
    public GameObject titleParent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      playButton.onClick.AddListener(TaskOnClick);
    }

  public void TaskOnClick()
  {
    Debug.Log("playButton was clicked");
    titleParent.SetActive(false);
     
  }
   
}
