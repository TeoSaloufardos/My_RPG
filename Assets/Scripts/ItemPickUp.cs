using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private int itemID;

    /*Ειναι αρκετα πρωχειρος τροπος αλλα ουσιαστικα με αυτον τον τροπο δηλωνω ποια items ειναι stackable και τι item συγκεκριμενο ειναι
     ετσι ωστε να το προσθετει σαν stack και οχι unique item. Αυτο δεν ειναι καλη μεθοδος που εφαρμοζω αλλα λογω ελειψης χρονου χρησιμοποιω
     αυτην τον τροπο οπου παρουσιαζει και το tutorial για να γλιτωσω χρονο. Το κανω γιατι σχεδιαζω τα stackable items να ειναι λιγα.*/
    [SerializeField] private bool containsRoot = false; 
    [SerializeField] private bool isDesertMushroom = false;

    public void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            if (containsRoot == true) //τροπος ελεγχος των μη unique αντικειμενων (κακος αλλα αυτον εχω για την ωρα)
            {
                if (InventoryItems.roots == 0)
                {
                    displayItem();
                }
                InventoryItems.roots++;
                Destroy(gameObject);
            }else if (isDesertMushroom == true)
            {
                if (InventoryItems.desertMushrooms == 0)
                {
                    displayItem();
                }
                InventoryItems.desertMushrooms++;
                Destroy(gameObject);
            }
            Destroy(gameObject); //(ΑΦΟΡΑ ΤΟ Destroy σαν μεθοδο) Μετα απο τις παραπανω ενεργειες γινεται καταστροφη του αντικειμενου. +Βαζωντας Destroy(this) Καταστρεφεται το Script ΟΧΙ ΤΟ OBJECT.
        }
    }

    public void displayItem()
    {
        InventoryItems.newIconID = itemID; //Λαμβανωντας το Id του αντικειμενου το περναω στο Script IntentoryItems οπου εκει θα αναλαβει την καταχωρηση του.
        InventoryItems.iconUpdate = true; //Εδω δηλωνεται πως θα πρεπει να γινει ενημερωση του πινακα με τα items/
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
