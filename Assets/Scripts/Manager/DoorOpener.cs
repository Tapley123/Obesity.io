using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public GameObject[] doors;
    public static bool door1 = false, door2 = false, door3 = false, door4 = false;
    public AudioClip doorSound;
    private GameController gc;

    private void Start()
    {
        gc = GameObject.Find("Game Controller").GetComponent<GameController>();
    }

    void Update()
    {
        //stops the doors working when you collect the last nugget
        if (UIManager.nuggetAmount <= gc.amountOfNuggsToWin - 1)
        {
            if (door1)
            {

                doors[0].GetComponent<Animator>().SetTrigger("Open");
                doors[0].GetComponent<AudioSource>().PlayOneShot(doorSound);
                door1 = false;
            }

            if (door2)
            {
                doors[1].GetComponent<Animator>().SetTrigger("Open");
                doors[1].GetComponent<AudioSource>().PlayOneShot(doorSound);
                door2 = false;
            }

            if (door3)
            {
                doors[2].GetComponent<Animator>().SetTrigger("Open");
                doors[2].GetComponent<AudioSource>().PlayOneShot(doorSound);
                door3 = false;
            }

            if (door4)
            {
                doors[3].GetComponent<Animator>().SetTrigger("Open");
                doors[3].GetComponent<AudioSource>().PlayOneShot(doorSound);
                door4 = false;
            }
        }
    }
}
