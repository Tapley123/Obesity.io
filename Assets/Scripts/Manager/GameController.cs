using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject chicken;

    private AudioSource audioS;
    [SerializeField] private AudioClip buttonSound;

    public GameObject winScreen, loseScreen;
    public static bool lostGame = false; //use this to prevent the start screen from coming up after the player dies and presses restart

    public static bool allNuggs = false, caughtByEnemy = false;
    public int amountOfNuggsToWin = 8;
    public TextMeshProUGUI winTimeText;

    private void Awake()
    {
        audioS = GetComponent<AudioSource>();
        Time.timeScale = 1;
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    void Update()
    {
        //if the player has collected all the nuggets
        if(UIManager.nuggetAmount >= amountOfNuggsToWin)
        {
            allNuggs = true;

            winTimeText.text = TimerController.winTime;

            //Time.timeScale = 0;

            winScreen.SetActive(true);
            Cursor.visible = true;
            chicken.transform.position = new Vector3(1000, 1000, 1000);
        }

        if(caughtByEnemy)
        {
            Time.timeScale = 0;
            loseScreen.SetActive(true);
            lostGame = true;

            caughtByEnemy = false;
        }
    }

    public void ReplayButton()
    {
        Cursor.visible = false;
        audioS.PlayOneShot(buttonSound);
        UIManager.nuggetAmount = 0;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
