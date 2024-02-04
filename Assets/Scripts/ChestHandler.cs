using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestHandler : MonoBehaviour
{

    private Animator objectAnimator;
    private bool notOpened = true; //Αυτο το βαζω για να μην επαναλαμβανει το animation, οταν ο παικτης εχει ηδη ανοιξει το κουτι.
    private bool hasClosed = false;
    [SerializeField] private int giveCoins = 25; //Το default θα ειναι να δινει 25 coins καθε chest, μπορει ομως να αλλαχτει αναλογα με την περιπτωση.
    
    void Start()
    {
        objectAnimator = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (notOpened)
            {
                if (InventoryItems.ItemsQuantities[16] > 0) /*Γνωριζω πως το 16 είναι το id του κλειδιου οποτε
                εδω ελεγχω εαν ο παικτης εχει κλειδι διαθεσιμο ελεγχοντας τον πινακα που κραταει τις ποσοτητες
                των αντικειμενων.*/
                {
                    InventoryItems.ItemsQuantities[16] = InventoryItems.ItemsQuantities[16] - 1; //εαν υπαρχει αφαιρει 1
                    InventoryItems.totalCoins += giveCoins;
                    
                    objectAnimator.SetTrigger("open");
                    UiMessageHandler.passedMessage = ("+" + giveCoins + " νομίσματα, νέο υπόλοιπο " +
                                                      InventoryItems.totalCoins + " νομίσματα.");
                    giveCoins = 0;
                    notOpened = false;
                }
                else
                {
                    UiMessageHandler.passedMessage =
                        "Δεν έχεις κλειδί διαθέσιμο στο inventory σου !!!"; /*Εαν δεν εχει τοτε
                        εδω γινεται χρηση του script που διαχειριζεται τα μηνυματα και του στελνω ενα μηνυμα να εμφανισει.*/
                }
            }else
            {
                UiMessageHandler.passedMessage = "Αυτό το κουτί το έχεις ανοίξει.";
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && notOpened == false && hasClosed == false)
        {
            objectAnimator.SetTrigger("close");
            hasClosed = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            InventoryItems.ItemsQuantities[16] = InventoryItems.ItemsQuantities[16] + 1; //Cheat code.
        }
    }
}
