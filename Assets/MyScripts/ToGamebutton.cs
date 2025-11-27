using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VisualScripting;

public class ToGamebutton : MonoBehaviour
{
    public Button ToGameButton;
    public GameObject loadingScreenUI;
    public GameObject titleScreenUI;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ToGameButton.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        Debug.Log("to game button was clicked");
        titleScreenUI.SetActive(false);
        loadingScreenUI.SetActive(false);
        
    }

    
}
