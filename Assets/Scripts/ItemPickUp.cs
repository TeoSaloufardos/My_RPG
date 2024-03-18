using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private int itemID;
    [SerializeField] private bool isStackable = true;
    [SerializeField] private GameObject inventory;
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private bool areCoins;

    private void Start()
    {
        inventory = GameObject.Find("InventoryCanvas");
        audioPlayer = inventory.GetComponent<AudioSource>();
        if (areCoins)
        {
            Destroy(gameObject, 5);
        }
    }

    public void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            if (InventoryItems.hasFreeSpace == false && areCoins == false)
            {
                UiMessageHandler.passedMessage = "To inventory σου είναι γεμάτο !!!";
                UiMessageHandler.desiredDelay = 3f;
                return;
            }
            if (isStackable && areCoins == false) //εαν το αντικειμενο που ακουμπαει ο παικτης ειναι stackable 
            {
                if (InventoryItems.ItemsQuantities[itemID] == 0)
                {
                    displayItem();
                }
                InventoryItems.ItemsQuantities[itemID] = InventoryItems.ItemsQuantities[itemID] + 1;
                Destroy(gameObject);
            }
            if (areCoins)
            {
                InventoryItems.totalCoins += Random.Range(5, 40);
                Destroy(gameObject);
            }
            audioPlayer.clip = inventory.GetComponent<InventoryItems>().pickUpSound;
            audioPlayer.Play();
            Destroy(gameObject); //(ΑΦΟΡΑ ΤΟ Destroy σαν μεθοδο) Μετα απο τις παραπανω ενεργειες γινεται καταστροφη του αντικειμενου. +Βαζωντας Destroy(this) Καταστρεφεται το Script ΟΧΙ ΤΟ OBJECT.
        }
    }
    
    public void displayItem()
    {
        InventoryItems.newIconID = itemID; //Λαμβανωντας το Id του αντικειμενου το περναω στο Script IntentoryItems οπου εκει θα αναλαβει την καταχωρηση του.
        InventoryItems.iconUpdate = true; //Εδω δηλωνεται πως θα πρεπει να γινει ενημερωση του πινακα με τα items/
    }
}
