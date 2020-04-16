using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject winScreen, loseScreen;
    public static bool loseScreenActive = false;

    public static bool allNuggs = false, caughtByEnemy = false;
    public int amountOfNuggsToWin = 8;
    public TextMeshProUGUI winTimeText;

    private void Awake()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    void Start()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }
        

    void Update()
    {
        //Debug.Log("Lose Screen ASctive = " + loseScreenActive);

        if (!loseScreenActive)
            loseScreen.SetActive(false);
        else
            loseScreen.SetActive(true);

        //if the player has collected all the nuggets
        if(UIManager.nuggetAmount >= amountOfNuggsToWin)
        {
            allNuggs = true;

            winTimeText.text = TimerController.winTime;

            Time.timeScale = 0;

            winScreen.SetActive(true);
        }

        if(caughtByEnemy)
        {
            Time.timeScale = 0;
            loseScreen.SetActive(true);
        }
    }

    public void ReplayButton()
    {
        loseScreenActive = false;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        
        Time.timeScale = 1;
    }
}
