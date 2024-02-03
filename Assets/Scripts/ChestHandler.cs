using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestHandler : MonoBehaviour
{

    private Animator objectAnimator;
    [SerializeField] private int giveCoins = 25; //Το default θα ειναι να δινει 25 coins καθε chest, μπορει ομως να αλλαχτει αναλογα με την περιπτωση.
    
    void Start()
    {
        objectAnimator = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (InventoryItems.ItemsQuantities[16] > 0) /*Γνωριζω πως το 16 είναι το id του κλειδιου οποτε
            εδω ελεγχω εαν ο παικτης εχει κλειδι διαθεσιμο ελεγχοντας τον πινακα που κραταει τις ποσοτητες
            των αντικειμενων.*/
            {
                InventoryItems.ItemsQuantities[16] = InventoryItems.ItemsQuantities[16] - 1; //εαν υπαρχει αφαιρει 1
                objectAnimator.SetTrigger("open");
            }
            else
            {
                UiMessageHandler.passedMessage = "Δεν έχεις κλειδί διαθέσιμο στο inventory σου !!!"; /*Εαν δεν εχει τοτε 
                εδω γινεται χρηση του script που διαχειριζεται τα μηνυματα και του στελνω ενα μηνυμα να εμφανισει.*/
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
