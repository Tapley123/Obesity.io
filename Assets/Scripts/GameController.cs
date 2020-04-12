using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject winScreen;

    public static bool allNuggs = false;
    public int amountOfNuggsToWin = 8;
    public TextMeshProUGUI winTimeText;

    void Start()
    {
        winScreen.SetActive(false);
    }
        

    void Update()
    {
        //if the player has collected all the nuggets
        if(UIManager.nuggetAmount >= amountOfNuggsToWin)
        {
            allNuggs = true;

            winTimeText.text = TimerController.winTime;

            winScreen.SetActive(true);

            Time.timeScale = 0;
        }
    }
}
