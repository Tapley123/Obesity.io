using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject nugget1, nugget2, nugget3, nugget4, nugget5, nugget6, nugget7, nugget8;

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
        
    }
}
