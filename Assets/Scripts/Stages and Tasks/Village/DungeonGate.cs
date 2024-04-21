using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGate : MonoBehaviour
{
    [SerializeField] private GameObject closedGate;
    [SerializeField] private GameObject openGate;
    
    void Start()
    {
        closedGate.SetActive(true);
        openGate.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (InventoryItems.ItemsQuantities[16] >= 5 && VillageAllStages.keysCollected)
            {
                closedGate.SetActive(false);
                openGate.SetActive(true);
                Destroy(this);
            }

            UiMessageHandler.passedMessage =
                "Χρειάζεται να βρεις τα 5 κρυμμένα κλειδιά, ψάξε στην περιοχή να τα βρεις.";
            UiMessageHandler.desiredDelay = 2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
