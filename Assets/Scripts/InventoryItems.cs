using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItems : MonoBehaviour
{
    //Πεδια που βοηθουν στις λειτουργιες ανοιγματος και κλεισιματος του UI
    [SerializeField] private GameObject inventoryMenu; 
    [SerializeField] private GameObject closedBook;
    [SerializeField] private GameObject openBook;
    [SerializeField] private GameObject ui;

    //Πεδια που αφορουν την καταχωρηση αντικειμενων στο inventory 
    [SerializeField] private List<Image> emptySlots; //Πινακας που περιεχει καθε emptySlot (διαθεσιμο slot)
    [SerializeField] private List<Sprite> icons; //Το συνολογο των αντικειμενων με τα εικονιδια τους
    [SerializeField] private Sprite theEmptySlot; //Οριζω ποιο ειναι το empty slot (πως μοιαζει)
    
    //Βασεις δεδομενων που με βοηθουν στην διαχειρηση των αντικειμενων.
    public static List<String> itemNames = new List<string>(); /*Αυτο το χρησιμοποιω για να μπορω να γραψω μεσω του unity τα ονοματα, τα κανω transfer απο
    τον πινακα transferItemNames. Αυτο το κανω για να εχω προσβαση στα ονοματα των αντικειμενων.*/
    [SerializeField] private List<String> transferItemNames; //Πινακα που δηλωνω τα ονοματα των αντικειμενων, συμφωνα με την σειρα που εχουν
    public static List<int> ItemsQuantities = new List<int>();
    
    //Μεταβλητες που με βοηθουν στην διαχειρηση των αλλαγων στο ui.
    public static bool iconUpdate = false; //Το χρησιμοποιω για να ξερω ποτε θα πρεπει να ενημερωσω το icon
    private int maxSizeOfEmptySlots; //Κραταει το maxSize των διαθεσιμων slots
    public static int newIconID = 0; //Δεχεται το Item Id για να καταχωρηθει στον πινακα και να εμφανιστει στο Inventory
    public static bool hasFreeSpace = true;
    public static int totalCoins = 0; //Συνολο κερματων που εχει ο παικτης
    
    public static int removeItemWithID; //Στην περιπτωση πωλησης ενος αντικειμενου θα ερθει απο ενα αλλο script
    // το id του ιτεμ το οποιο επιθυμει ο παικτης να πουλησει.
    public static bool removeItem = false; //αυτη η μεταβλητη μπορει να αλλαξει απο αλλα script οπως ειναι τα 
    //μαγαζια ετσι ωστε να γινει η διαδικασια αφαιρεσης του αντικειμενου απο το inventory του παικτη.
    
    void Start()
    {
        //desertMushrooms = 0;
        //roots = 0;
        
        itemNames.Clear();
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        ui.SetActive(true);
        maxSizeOfEmptySlots = emptySlots.Count;
        constructItemsAndQuantities();
        
        //μεταφερω τα δεδομενα απο τον πινακα στο unity σε εναν static για να ειναι κοινος σε ολα τα scripts και
        //αμεταβλητος.
        for (int i = 0; i < transferItemNames.Count; i++) 
        {
            itemNames.Add(transferItemNames[i]);
        }
    }
    void Update()
    {
        if (removeItem)
        {
            removeItemIconFromInventory();
        }
        if (iconUpdate)
        {
            for (int i = 0; i < maxSizeOfEmptySlots; i++)
            {
                if (i == emptySlots.Count + 1)
                {
                    hasFreeSpace = false;
                }
                if (emptySlots[i].sprite == theEmptySlot)
                {
                    maxSizeOfEmptySlots = i; /*Βαζοντας εδω την τωρινη θεση δεν ξανα εφαρμοζει αλλη λουπα γιατι δεν το χρειαζομαστε απο την στιγμη
                    που βρηκαμε την κενη θεση.*/
                    emptySlots[i].sprite = icons[newIconID]; /*Μεσα απο τα δεδομενα στο πινακα icons μπορουμε με το id που λαμβανεται απο το itempickup script
                    να καταγραφει και εμφανιστει το νεο αντικειμενο που μαζεψε ο παικτης.*/
                    emptySlots[i].transform.gameObject.GetComponent<PopUpMessageHandler>().objectID = newIconID;
                }
            }
            iconUpdate = false; //Γυρναει σε κατασταση false το update μετα απο 1sec.
            maxSizeOfEmptySlots = emptySlots.Count; /*Ξανα λαμβανει το maxSize του πινακα ετσι ωστε να μπορει να ξανα αρχισει η λουπα στο επομενο
            true που θα δεχτει το iconUpdate*/
            StartCoroutine(Reset()); /*Το StartCoroutine ειναι μια μεθοδος που μου επιτρεπει να τρεξει μια μεθοδος με
            καθυστερηση. Για παραδειγμα εδω ξεκιναει να τρεξει η μεθοδος Reset της οποιας η υλοποιηση βρισκεται παρακατω.*/
        }
    }

    public void openMenu()
    {
        inventoryMenu.SetActive(true);
        openBook.SetActive(true);
        closedBook.SetActive(false);
        ui.SetActive(false);
        Time.timeScale = 0; //κανω pause τον χρονο για να μπει ο παικτης με την ησυχια του μεσα στο menu
    }
    
    public void closeMenu()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        ui.SetActive(true);
        Time.timeScale = 1; //συνεχιζω το παιχνιδι
    }

    /*Εδω ειναι η μεθοδος Reset που χρησιμοποιειται για να δημιουργησει delay μεταξυ των λειτουργιων της.
     Για παραδειγμα εδω θα κανει μια παυση 0.1 δευτερολεπτου και στην συνεχεια θα συνεχισει. Αυτο επιτρεπει να μην διακοπτονται
     αλλες λειτουργιες αλλα μονο αυτην που θελω εκεινη την στιγμη.*/
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.1f);
        
    }

    //οταν θα δεχεται το itemRemove = true τοτε θα εκτελειται αυτη εδω η μεθοδος. Αυτη εδω η μεθοδος
    // επιτρεπει την αφαιρεση ενος αντικειμενου απο το inventory του παικτη. Εαν για παραδειγμα το πουλησει.
    public void removeItemIconFromInventory() 
    {
        for (int i = 0; i < maxSizeOfEmptySlots; i++)
        {
            if (emptySlots[i].sprite == icons[removeItemWithID])
            {
                emptySlots[i].sprite = theEmptySlot;
                removeItem = false;
                break;
            }
        }
    }
    
    public void constructItemsAndQuantities()
    {
        for (int i = 0; i < icons.Count; i++)
        {
            ItemsQuantities.Add(0);
        }
    }
    
}
