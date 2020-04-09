using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour
{
    private AudioSource audioS;
    [SerializeField] private string tagName;
    [SerializeField] private AudioClip audioClip;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(tagName))
        {
            audioS.PlayOneShot(audioClip);
        }
    }
}
