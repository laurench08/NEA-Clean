using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VisualScripting;

public class QuitMenuButton : MonoBehaviour
{
   public Button quitButton;

    void Start()
    {
      quitButton.onClick.AddListener(QuitGame);
    }
    public void QuitGame()
    {
     Application.Quit();
      Debug.Log($"the quit button was clicked\nyou have quit the game");
    }

}
