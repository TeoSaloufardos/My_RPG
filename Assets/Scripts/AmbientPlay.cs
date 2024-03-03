using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientPlay : MonoBehaviour
{
    private AudioSource audioPlayer;
    [HideInInspector] private WaitForSeconds waitTime = new WaitForSeconds(5);
    
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        StartCoroutine(AnimalsSound());
    }

    IEnumerator AnimalsSound()
    {
        yield return waitTime;
        audioPlayer.Play();
        StartCoroutine(AnimalsSound());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
