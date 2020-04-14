using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Animator[] doorAnimators;
    public static bool door1 = false, door2 = false, door3 = false, door4 = false;
    
    void Update()
    {
        if(door1)
        {
            doorAnimators[0].SetTrigger("Open");
            door1 = false;
        }

        if (door2)
        {
            doorAnimators[1].SetTrigger("Open");
            door1 = false;
        }

        if (door3)
        {
            doorAnimators[2].SetTrigger("Open");
            door1 = false;
        }

        if (door4)
        {
            doorAnimators[3].SetTrigger("Open");
            door1 = false;
        }
    }
}
