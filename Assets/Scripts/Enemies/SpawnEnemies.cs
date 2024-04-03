using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject myCamera;
    [HideInInspector] public bool canSpawn = true;
    [SerializeField] private bool respawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (canSpawn)
            {
                canSpawn = false;
                for (int i = 0; i < enemies.Length; i++)
                {
                    Instantiate(enemies[i], spawnPoints[i].position, spawnPoints[i].rotation);// kanei spawn ta enemies stis topothesies pou einai ta spawnpoints.
                    SavePlayer.enemiesOnScreen++;
                    myCamera.GetComponent<AudioHandler>().musicState = 3;// epilegei na paiksei thn mousikh polemou
                    myCamera.GetComponent<AudioHandler>().canPlay = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SavePlayer.enemiesOnScreen <= 0)
        {
            if (canSpawn == false)
            {
                if (respawn)
                {
                    canSpawn = true;
                }
                myCamera.GetComponent<AudioHandler>().musicState = 1;// epilegei na paiksei thn mousikh polemou
                myCamera.GetComponent<AudioHandler>().canPlay = true;
            }
        }
    }
}
