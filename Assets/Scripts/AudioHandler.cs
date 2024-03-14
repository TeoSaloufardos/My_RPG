using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    private AudioSource audioPlayer;
    [SerializeField] private AudioClip mainLoop;
    [SerializeField] private AudioClip tavernLoop;
    [SerializeField] private AudioClip battleLoop;
    [SerializeField] private AudioClip weaponSmithLoop;
    [SerializeField] private AudioClip wizzardLoop;
    [HideInInspector] public int musicState = 1;
    [HideInInspector] public bool canPlay = true;
    
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (canPlay)
        {
            canPlay = false;
            if (musicState == 1)
            {
                audioPlayer.clip = mainLoop;
                audioPlayer.Play();
            }else if(musicState == 2)
            {
                audioPlayer.clip = tavernLoop;
                audioPlayer.Play();
            }else if (musicState == 3)
            {
                audioPlayer.clip = battleLoop;
                audioPlayer.Play();
            }else if (musicState == 4)
            {
                audioPlayer.clip = weaponSmithLoop;
                audioPlayer.Play();
            }else if (musicState == 5)
            {
                audioPlayer.clip = wizzardLoop;
                audioPlayer.Play();
            }
        }
    }
}
