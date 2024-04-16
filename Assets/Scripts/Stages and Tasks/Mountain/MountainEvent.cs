using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainEvent : MonoBehaviour
{
    [SerializeField] private GameObject chest;
    [SerializeField] private GameObject key;
    private bool startCountEnemies = false;
    [SerializeField] private GameObject npcForEvent;
    
    void Start()
    {
        if (SavePlayer.MountainEventHasCompleted)
        {
            npcForEvent.SetActive(false);
            Destroy(gameObject);
        }
        chest.SetActive(false);
        key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (startCountEnemies)
        {
            if (GetComponent<SpawnEnemies>().enemies.Length == 0)
            {
                npcForEvent.SetActive(false);
                chest.SetActive(true);
                key.SetActive(true);
                Destroy(this);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !startCountEnemies)
        {
            startCountEnemies = true;
            SavePlayer.MountainEventHasCompleted = true;
        }
    }
}
