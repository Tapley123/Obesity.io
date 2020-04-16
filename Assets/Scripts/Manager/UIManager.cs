using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject nugget1, nugget2, nugget3, nugget4, nugget5, nugget6, nugget7, nugget8;
    public static int nuggetAmount = 0;
    

    [SerializeField] private bool displayNuggetsCollected = true;
    [SerializeField] private bool canWin = true;

    public GameObject startScreen;

    private void Awake()
    {
        ///////if the player has gotten caught when they replay the start screen wont appear again
        if(GameController.lostGame)
            startScreen.SetActive(false);
        else
        {
            Time.timeScale = 0;
            startScreen.SetActive(true);
        }
    }

    void Start()
    {
        nugget1 = GameObject.Find("Nugget1");
        nugget2 = GameObject.Find("Nugget2");
        nugget3 = GameObject.Find("Nugget3");
        nugget4 = GameObject.Find("Nugget4");
        nugget5 = GameObject.Find("Nugget5");
        nugget6 = GameObject.Find("Nugget6");
        nugget7 = GameObject.Find("Nugget7");
        nugget8 = GameObject.Find("Nugget8");

        nugget1.SetActive(false);
        nugget2.SetActive(false);
        nugget3.SetActive(false);
        nugget4.SetActive(false);
        nugget5.SetActive(false);
        nugget6.SetActive(false);
        nugget7.SetActive(false);
        nugget8.SetActive(false);
    }

    
    void Update()
    {
        if(displayNuggetsCollected)
        {
            if (nuggetAmount < 1)
            {
                nugget1.SetActive(false);
                nugget2.SetActive(false);
                nugget3.SetActive(false);
                nugget4.SetActive(false);
                nugget5.SetActive(false);
                nugget6.SetActive(false);
                nugget7.SetActive(false);
                nugget8.SetActive(false);
            }
            if (nuggetAmount == 1)
            {
                nugget1.SetActive(true);
                nugget2.SetActive(false);
                nugget3.SetActive(false);
                nugget4.SetActive(false);
                nugget5.SetActive(false);
                nugget6.SetActive(false);
                nugget7.SetActive(false);
                nugget8.SetActive(false);
            }
            if (nuggetAmount == 2)
            {
                nugget1.SetActive(true);
                nugget2.SetActive(true);
                nugget3.SetActive(false);
                nugget4.SetActive(false);
                nugget5.SetActive(false);
                nugget6.SetActive(false);
                nugget7.SetActive(false);
                nugget8.SetActive(false);
            }
            if (nuggetAmount == 3)
            {
                nugget1.SetActive(true);
                nugget2.SetActive(true);
                nugget3.SetActive(true);
                nugget4.SetActive(false);
                nugget5.SetActive(false);
                nugget6.SetActive(false);
                nugget7.SetActive(false);
                nugget8.SetActive(false);
            }
            if (nuggetAmount == 4)
            {
                nugget1.SetActive(true);
                nugget2.SetActive(true);
                nugget3.SetActive(true);
                nugget4.SetActive(true);
                nugget5.SetActive(false);
                nugget6.SetActive(false);
                nugget7.SetActive(false);
                nugget8.SetActive(false);
            }
            if (nuggetAmount == 5)
            {
                nugget1.SetActive(true);
                nugget2.SetActive(true);
                nugget3.SetActive(true);
                nugget4.SetActive(true);
                nugget5.SetActive(true);
                nugget6.SetActive(false);
                nugget7.SetActive(false);
                nugget8.SetActive(false);
            }
            if (nuggetAmount == 6)
            {
                nugget1.SetActive(true);
                nugget2.SetActive(true);
                nugget3.SetActive(true);
                nugget4.SetActive(true);
                nugget5.SetActive(true);
                nugget6.SetActive(true);
                nugget7.SetActive(false);
                nugget8.SetActive(false);
            }
            if (nuggetAmount == 7)
            {
                nugget1.SetActive(true);
                nugget2.SetActive(true);
                nugget3.SetActive(true);
                nugget4.SetActive(true);
                nugget5.SetActive(true);
                nugget6.SetActive(true);
                nugget7.SetActive(true);
                nugget8.SetActive(false);
            }
            if (nuggetAmount == 8)
            {
                nugget1.SetActive(true);
                nugget2.SetActive(true);
                nugget3.SetActive(true);
                nugget4.SetActive(true);
                nugget5.SetActive(true);
                nugget6.SetActive(true);
                nugget7.SetActive(true);
                nugget8.SetActive(true);
            }
        }
    }

    public void PlayButton()
    {
        Time.timeScale = 1;
        startScreen.SetActive(false);
    }
    
}
