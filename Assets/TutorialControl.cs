using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialControl : MonoBehaviour
{
    public GameObject TutorialBox;

    public GameObject ExitScreen;

    private void Awake()
    {
        ExitScreen.SetActive(false);
        TutorialBox.SetActive(true);

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            TutorialBox.SetActive(!TutorialBox.activeSelf);
        } 
        
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ExitScreen.SetActive(!ExitScreen.activeSelf);
        } 
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
