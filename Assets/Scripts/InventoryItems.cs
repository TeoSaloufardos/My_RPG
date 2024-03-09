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
    
    //Hxoi / Audio
    [SerializeField] private AudioClip bookOpenSound;
    [SerializeField] public AudioClip selectSound;
    [HideInInspector] public AudioSource audioPlayer;
    [SerializeField] public AudioClip buySound;
    [SerializeField] public AudioClip createMagicSound;
    [SerializeField] public AudioClip pickUpSound;

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
    
    //Κουμπι που χρειαζεται για το ανοιγμα-κλεισιμο των magic recipes (potions)
    [SerializeField] private GameObject magicBookRecipes;
    [SerializeField] private GameObject canvas;
    [HideInInspector] public int currentID = 0;
    [HideInInspector] public int checkAmount = 0;
    private int secondMax;
    private int thirdMax;
    
    //Ui 
    [SerializeField] private List<Image> UISlots;
    [SerializeField] private List<Sprite> UIEmptySlots; 
    [SerializeField] private List<Sprite> magicIcons;
    [SerializeField] private List<KeyCode> keys;
    [HideInInspector] public bool set = false;
    [HideInInspector] public int selected = 0;
    public List<int> magicAttacks;
    [SerializeField] private List<Sprite> spellIcons;
    [HideInInspector] public bool setTwo = false;
    [SerializeField] private GameObject[] magicParticles;
    [SerializeField] private AudioClip[] magicSFX;
    [SerializeField] private Image manaBar;
    
    //attack animation
    private GameObject playerObj;
    private Animator playerAnimator;
    private float weightAmount = 1.0f; //einai to poio layer (baruthta tou layer) tha epikrathsei kai se ti pososto. Gia paradeigma by default to layer magicAttack einai 0 kai me 1 (100%) einai to kanoniko layer pou exei to sprint(walk) idle tou paikth.
    private bool changeWeight = false;
    private AnimatorStateInfo playerInfo;
    
    
    
    void Start()
    {
        //desertMushrooms = 0;
        //roots = 0;
        
        itemNames.Clear();
        magicBookRecipes.SetActive(false);
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        ui.SetActive(true);
        maxSizeOfEmptySlots = emptySlots.Count;
        constructItemsAndQuantities();
        audioPlayer = GetComponent<AudioSource>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = playerObj.GetComponent<Animator>();
        
        
        //μεταφερω τα δεδομενα απο τον πινακα στο unity σε εναν static για να ειναι κοινος σε ολα τα scripts και
        //αμεταβλητος.
        for (int i = 0; i < transferItemNames.Count; i++) 
        {
            itemNames.Add(transferItemNames[i]);
        }
        secondMax = itemNames.Count;
        thirdMax = emptySlots.Count;
    }

    public void changeItemQuantities()//auth h methodos kai h parakatw einai mia paramoia ulopoihsh apo autes pou exw kanei alla gia sigouria xrhsimopoihsa autes tis duo sthn diadikasia ths kataskeuhs magic.
    {
        for (int i = 0; i < secondMax; i++)
        {
            if (i == currentID)
            {
                secondMax = i;
                checkAmount = ItemsQuantities[i];
                checkAmount--;
                if (checkAmount == 0)
                {
                    removeIcon(i);
                }
                ItemsQuantities[i]--;
            }
        }
        secondMax = itemNames.Count;
    }

    public void removeIcon(int iconID)
    {
        for (int i = 0; i < thirdMax; i++)
        {
            if (emptySlots[i].sprite == icons[iconID])
            {
                thirdMax = i;
                emptySlots[i].sprite = icons[0];
                emptySlots[i].transform.gameObject.GetComponent<PopUpMessageHandler>().objectID = 0;
            }
        }
        thirdMax = emptySlots.Count;
    }
    
    void Update()
    {
        playerInfo = playerAnimator.GetCurrentAnimatorStateInfo(1);
        
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
            // StartCoroutine(Reset()); /*Το StartCoroutine ειναι μια μεθοδος που μου επιτρεπει να τρεξει μια μεθοδος με
            // καθυστερηση. Για παραδειγμα εδω ξεκιναει να τρεξει η μεθοδος Reset της οποιας η υλοποιηση βρισκεται παρακατω.*/
        }
        if (set && selected != 0)
        {
            for (int i = 0; i < UISlots.Count; i++)
            {
                if (Input.GetKeyDown((keys[i])))
                {
                    set = false;
                    UISlots[i].sprite = magicIcons[selected];
                    magicAttacks[i] = selected;
                    canvas.GetComponent<CreateMagic>().removed(selected - 1);
                }
            }
        }
        if (setTwo && selected != 0)
        {
            for (int i = 0; i < UISlots.Count; i++)
            {
                if (Input.GetKeyDown((keys[i])))
                {
                    setTwo = false;
                    UISlots[i].sprite = spellIcons[selected];
                    magicAttacks[i] = selected + 6;
                }
            }
        }

        if (Input.anyKey && Time.timeScale == 1)
        {
            for (int i = 0; i < UISlots.Count; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    if (magicAttacks[i] != 0)
                    {
                        if (SavePlayer.manaAmount > 0.1f)
                        {
                            Instantiate(magicParticles[magicAttacks[i]-1], SavePlayer.spawnPoint.transform.position, SavePlayer.spawnPoint.transform.rotation);
                            audioPlayer.clip = magicSFX[magicAttacks[i] - 1];//einai kai edw kai panw -1 giati hthela to 0 na einai to keno kai oxi kapoio spell/magic epishs edw ginetai to display kai to audio effect tou kathe spell/magic analoga me to koumpi pou exei pathsei o paikths. proupothetei na uparxei sto ui bar.
                            audioPlayer.Play();
                            playerAnimator.SetTrigger("magicAttack");
                            playerAnimator.SetLayerWeight(1,1);//kathorizei thn barurthta tou layer 1 pou einai to attack animation gia na ginei execute afou pio prin exei ginei katallhlh diadikasia gia na uparksei h prosbash se auta ta objects.
                            weightAmount = 1;
                        }

                        if (magicAttacks[i] < 7 && SavePlayer.manaAmount > 0.1)//ean isxuei kati apo auta katastrefei, afairei to icon giati einai magic oxi monimo spell.
                        {
                            UISlots[i].sprite = UIEmptySlots[i];
                        }
                    }
                }
            }
        }
        
        if (SavePlayer.manaAmount < 1.0)
        {
            SavePlayer.manaAmount += 0.04f * Time.deltaTime; //gemizei ton eauto tou otan paei katw apo to 100% san regen.
        }
        if (SavePlayer.manaAmount <= 0)
        {
            SavePlayer.manaAmount = 0;
        }
        if (SavePlayer.manaAmount < 0.03)
        {
            SavePlayer.invisible = false;
        }

        manaBar.fillAmount = SavePlayer.manaAmount;
        if (playerInfo.IsTag("magic"))
        {
            changeWeight = true;
        }

        if (changeWeight)
        {
            weightAmount -= 0.04f * Time.deltaTime;
            playerAnimator.SetLayerWeight(1, weightAmount);
            if (weightAmount <= 0)
            {
                changeWeight = false;
            }
        }
    }

    public void openMenu()
    {
        inventoryMenu.SetActive(true);
        openBook.SetActive(true);
        closedBook.SetActive(false);
        ui.SetActive(false);
        audioPlayer.clip = bookOpenSound;
        audioPlayer.Play();
        SavePlayer.theTarget = null;//na mhn emfanizetai to outline tou enemy otan eimaste sto inventory
        Time.timeScale = 0; //κανω pause τον χρονο για να μπει ο παικτης με την ησυχια του μεσα στο menu
    }
    
    public void closeMenu()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        ui.SetActive(true);
        audioPlayer.clip = bookOpenSound;
        audioPlayer.Play();
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
                if (ItemsQuantities[removeItemWithID] == 0)
                {
                    emptySlots[i].transform.gameObject.GetComponent<PopUpMessageHandler>().objectID = 0;
                }
                removeItem = false;
                Debug.Log("Removed item: " + removeItemWithID);
                Debug.Log("Remaing: " + ItemsQuantities[removeItemWithID]);
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

    public void closeMagicRecipesBook()
    {
        magicBookRecipes.SetActive(false);
        canvas.GetComponent<CreateMagic>().value = 0;
        canvas.GetComponent<CreateMagic>().thisValue = 0;
    }
    
    public void openMagicRecipesBook()
    {
        magicBookRecipes.SetActive(true);
    }
}
