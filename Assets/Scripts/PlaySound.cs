using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour
{
    private AudioSource audioS;
    [SerializeField] private string nuggetTagName, enemyTagName;
    [SerializeField] private AudioClip nuggetAudioClip, hurtAudioClip;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(nuggetTagName))
            audioS.PlayOneShot(nuggetAudioClip);

        if (other.CompareTag(enemyTagName))
            audioS.PlayOneShot(hurtAudioClip);
    }
}
