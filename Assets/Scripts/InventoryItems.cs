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
    [SerializeField] private List<String> transferItemNames;

    public static List<String> itemNames = new List<string>(); /*Αυτο το χρησιμοποιω για να μπορω να γραψω μεσω του unity τα ονοματα
    των αντικειμενων ετσι ωστε με πινακα μετα να μπορω να εμφανιζω τα ονοματα τους μεσω μιας for*/
    [SerializeField] private Sprite theEmptySlot; //Οριζω ποιο ειναι το empty slot (πως μοιαζει)
    
    public static bool iconUpdate = false; //Το χρησιμοποιω για να ξερω ποτε θα πρεπει να ενημερωσω το icon
    private int maxSizeOfEmptySlots; //Κραταει το maxSize των διαθεσιμων slots
    public static int newIconID = 0; //Δεχεται το Item Id για να καταχωρηθει στον πινακα και να εμφανιστει στο Inventory

    public static int desertMushrooms = 0;
    public static int roots = 0;
    
    void Start()
    {
        //desertMushrooms = 0;
        //roots = 0;
        
        itemNames.Clear();
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        ui.SetActive(true);
        maxSizeOfEmptySlots = emptySlots.Count;

        for (int i = 0; i < transferItemNames.Count; i++)
        {
            itemNames.Add(transferItemNames[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (iconUpdate == true)
        {
            for (int i = 0; i < maxSizeOfEmptySlots; i++)
            {
                if (emptySlots[i].sprite == theEmptySlot)
                {
                    maxSizeOfEmptySlots = i; /*Βαζοντας εδω την τωρινη θεση δεν ξανα εφαρμοζει αλλη λουπα γιατι δεν το χρειαζομαστε απο την στιγμη
                    που βρηκαμε την κενη θεση.*/
                    emptySlots[i].sprite = icons[newIconID]; /*Μεσα απο τα δεδομενα στο πινακα icons μπορουμε με το id που λαμβανεται απο το itempickup script
                    να καταγραφει και εμφανιστει το νεο αντικειμενο που μαζεψε ο παικτης.*/

                    emptySlots[i].transform.gameObject.GetComponent<PopUpMessageHandler>().objectID = newIconID;
                }
            }
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
        iconUpdate = false; //Γυρναει σε κατασταση false το update μετα απο 1sec.
        maxSizeOfEmptySlots = emptySlots.Count; /*Ξανα λαμβανει το maxSize του πινακα ετσι ωστε να μπορει να ξανα αρχισει η λουπα στο επομενο
        true που θα δεχτει το iconUpdate*/
    }
    
    
}
