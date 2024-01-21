using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private int itemID;

    /*Ειναι αρκετα πρωχειρος τροπος αλλα ουσιαστικα με αυτον τον τροπο δηλωνω ποια items ειναι stackable και τι item συγκεκριμενο ειναι
     ετσι ωστε να το προσθετει σαν stack και οχι unique item. Αυτο δεν ειναι καλη μεθοδος που εφαρμοζω αλλα λογω ελειψης χρονου χρησιμοποιω
     αυτην τον τροπο οπου παρουσιαζει και το tutorial για να γλιτωσω χρονο. Το κανω γιατι σχεδιαζω τα stackable items να ειναι λιγα.*/
    //[SerializeField] private bool containsRoot = false; 
    //[FormerlySerializedAs("isDesertMushroom")] [SerializeField] private bool isPurpleMushroom = false; //Το εχω αλλαξει ονομα με το reflactor, γι αυτο εμφανιζεται ετσι πλεον
    //NEW ΕΧΩ ΑΛΛΑΞΕΙ ΤΟΝ ΤΡΟΠΟ ΠΛΕΟΝ ΣΕ ΚΑΤΙ ΠΙΟ ΑΠΟΔΟΤΙΚΟ ΚΑΙ ΕΠΕΚΤΑΣΙΜΟ
    
    [SerializeField] private bool isStackable = true;
    
    public void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            /*if (InventoryItems.roots == 0)
                {
                    displayItem();
                }
                InventoryItems.roots++;
                Destroy(gameObject);
            }else if (isPurpleMushroom == true)
            {
                if (InventoryItems.desertMushrooms == 0)
                {
                    displayItem();
                }
                InventoryItems.desertMushrooms++;
                Destroy(gameObject);*/
            /*Ελεγχει εαν το inventory ειναι γεματο και ειναι τοτε περναει
             ενα μηνυμα στο uimessagehandler για να ειδοποιησει τον παικτη.*/
            if (InventoryItems.hasFreeSpace == false)
            {
                UiMessageHandler.passedMessage = "To inventory σου είναι γεμάτο !!!";
                UiMessageHandler.desiredDelay = 3f;
                return;
            }
            if (isStackable) //εαν το αντικειμενο που ακουμπαει ο παικτης ειναι stackable
            {
                for (int i = 0; i < InventoryItems.ItemsQuantities.Count; i++)
                {
                    if (itemID == i)
                    {
                        if (InventoryItems.ItemsQuantities[i] == 0)
                        {
                            displayItem();
                        }
                        InventoryItems.ItemsQuantities[i] = InventoryItems.ItemsQuantities[i] + 1;
                        Destroy(gameObject);
                    }
                }
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
