using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;


/*Αυτο το script αποτελει ενα εργαλειο δημιουργιας ενος καταστηματος που μπορει ο παικτης να πουλησει ή
 να αγορασει αντικειμενα. Οι τιμες ακολουθουν μια πολυ απλη γραμμικη συναρτηση η οποια ακολουθει
 το νομο της ζητησης. Δινεται η δυνατοτηα πουλησης αντικειμενων απο πλευρας παικτη ετσι ωστε να μπορει
 να κανει χωρο στο inventory του.*/
public class TavernShop : MonoBehaviour
{
    [SerializeField] private GameObject tavernShopGUI;
    
    //αρχικοποιηση των κουμπιων που θα μπορει ο παικτης να παταει ειτε για να πουλησει κατι ειτε να αγορασει
    [Header("Down bellow define the buttons that represents the buy/sell actions")]
    [SerializeField] private Button buyBreadButton;
    [SerializeField] private Button buyCheeseButton;
    [SerializeField] private Button buyMeatButton;
    [SerializeField] private Button sellBreadButton;
    [SerializeField] private Button sellCheeseButton;
    [SerializeField] private Button sellMeatButton;
    [SerializeField] private Button closeButton;
    [Header("Down bellow define the texts that represents the prices and amounts of items.")]
    [SerializeField] private Text currency;
    [SerializeField] private Text meatPriceText;
    [SerializeField] private Text cheesePriceText;
    [SerializeField] private Text breadPriceText;
    [SerializeField] private Text breadAmountText;
    [SerializeField] private Text meatAmountText;
    [SerializeField] private Text cheeseAmountText;
    [Header("Define the prices and amounts down below.")]
    [SerializeField] private int meatPrice;
    [SerializeField] private int cheesePrice;
    [SerializeField] private int breadPrice;
    [SerializeField] private int meatAmount;
    [SerializeField] private int cheeseAmount;
    [SerializeField] private int breadAmount;

    private bool hasInitialised = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasInitialised)//Αυτο γινεται με αυτο τον τροπο ετσι ωστε να μην επαναρχικοποιουνται τα κουμπια καθε φορα που ο παικτης εισερχεται μεσα στην περιοχη διοτι αυτο δημιουργει πολλαπλες ενεργειες στα κουμπια σαν onClick actions.
            {
                buyBreadButton.onClick.AddListener(buyBread);
                buyCheeseButton.onClick.AddListener(buyCheese);
                buyMeatButton.onClick.AddListener(buyMeat);
                closeButton.onClick.AddListener(closeShop);
                sellBreadButton.onClick.AddListener(sellBread);
                sellCheeseButton.onClick.AddListener(sellCheese);
                sellMeatButton.onClick.AddListener(sellMeat);
                hasInitialised = true;
            }
            initialise();//ενημερωση των τιμων, χρηματων και αλλων παιδιων που πρεπει για να εμφανιστουν σωστα στον παικτη
        }
    }
    
    public void closeShop()
    {
        tavernShopGUI.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tavernShopGUI.SetActive(false);
        }
    }
    public void buyBread() //υπαρχει η αντιστοιχη επιλογη για καθε αντικειμενο μεσα στο καταστημα. Σε καθε μεθοδο αυτο που γινεται ειναι να ελεγχεται εαν υπαρχει χωρος στο inventory, εαν υπαρχουν διαθεσιμα αντικειμενα και εαν ο παικτης εχει τα χρηματα να το αγορασει το αντικειμενο. Σε καθε περιπτωση εμφανιζεται ενα μηνυμα ετσι ωστε να ενημερωσει τον παικτη εαν κατι πηγε στραβα.
    {
        if (InventoryItems.hasFreeSpace == false)
        {
            UiMessageHandler.passedMessage = "To inventory σου είναι γεμάτο !!!";
            UiMessageHandler.desiredDelay = 3f;
            return;
        }
        if ((InventoryItems.totalCoins - breadPrice) >= 0 && (breadAmount - 1) >= 0)
        {
            InventoryItems.totalCoins -= breadPrice;
            breadPrice = (int)Math.Round(breadPrice * 1.17);
            breadAmount = breadAmount - 1;
            currency.text = (InventoryItems.totalCoins).ToString();
            breadAmountText.text = breadAmount.ToString();
            breadPriceText.text = breadPrice.ToString();
            addItemToInventory(11);
        }
        else
        {
            if ((breadAmount - 1) <= 0)
            {
                UiMessageHandler.passedMessage = "Δεν υπάρχουν διαθέσιμα αντικείμενα !!!";
                UiMessageHandler.desiredDelay = 2.5f;
                return;
            }
            UiMessageHandler.passedMessage = "Δεν έχεις αρκετά χρήματα !!!";
            UiMessageHandler.desiredDelay = 2.5f;
        }
    }
    
    public void buyCheese()
    {
        if (InventoryItems.hasFreeSpace == false)
        {
            UiMessageHandler.passedMessage = "To inventory σου είναι γεμάτο !!!";
            UiMessageHandler.desiredDelay = 3f;
            return;
        }
        if ((InventoryItems.totalCoins - cheesePrice) >= 0 && (cheeseAmount - 1) >= 0)
        {
            InventoryItems.totalCoins -= cheesePrice;
            cheesePrice = (int) Math.Round(cheesePrice * 1.17);
            cheeseAmount -= 1;
            currency.text = (InventoryItems.totalCoins).ToString(); 
            cheeseAmountText.text = cheeseAmount.ToString();
            cheesePriceText.text = cheesePrice.ToString();
            addItemToInventory(12);
        }
        else
        {
            if ((cheeseAmount - 1) <= 0)
            {
                UiMessageHandler.passedMessage = "Δεν υπάρχουν διαθέσιμα αντικείμενα !!!";
                UiMessageHandler.desiredDelay = 2.5f;
                return;
            }
            UiMessageHandler.passedMessage = "Δεν έχεις αρκετά χρήματα !!!";
            UiMessageHandler.desiredDelay = 2.5f;
        }
    }
    
    public void buyMeat()
    {
        if (InventoryItems.hasFreeSpace == false)
        {
            UiMessageHandler.passedMessage = "To inventory σου είναι γεμάτο !!!";
            UiMessageHandler.desiredDelay = 3f;
            return;
        }
        if ((InventoryItems.totalCoins - meatPrice) >= 0 && (meatAmount - 1) >= 0)
        {
            InventoryItems.totalCoins -= meatPrice;
            meatPrice = (int) Math.Round(meatPrice * 1.17);
            meatAmount -= 1;
            currency.text = (InventoryItems.totalCoins).ToString(); 
            meatAmountText.text = meatAmount.ToString();
            meatPriceText.text = meatPrice.ToString();
            addItemToInventory(13);
        }
        else
        {
            if ((meatAmount - 1) <= 0)
            {
                UiMessageHandler.passedMessage = "Δεν υπάρχουν διαθέσιμα αντικείμενα !!!";
                UiMessageHandler.desiredDelay = 2.5f;
                return;
            }
            UiMessageHandler.passedMessage = "Δεν έχεις αρκετά χρήματα !!!";
            UiMessageHandler.desiredDelay = 2.5f;
        }
    }
    public void sellBread()//Οπως και στο buy ετσι και στο sell γινεται παρομοια διαδικασια.
    {
        if (InventoryItems.ItemsQuantities[11] >= 1) //Εαν υπαρχουν αντικειμενα στο inventory του παικτη με αυτο το id τοτε μπορει να τα πουλησει, εαν οχι τοτε του εμφανιζει καταλληλο μηνυμα.
        {
            InventoryItems.totalCoins += (int) Math.Round(breadPrice * 0.65);
            breadPrice = (int) Math.Round(breadPrice / 1.17);
            breadAmount += 1;
            currency.text = (InventoryItems.totalCoins).ToString(); 
            breadAmountText.text = breadAmount.ToString();
            breadPriceText.text = breadPrice.ToString();
            removeItemFromInventory(11);
        }
        else
        {
            UiMessageHandler.passedMessage =
                "Δεν έχεις διαθέσιμο ψωμί στο inventory σου.";
            UiMessageHandler.desiredDelay = 1f;
        }
    }
    public void sellCheese()
    {
        if (InventoryItems.ItemsQuantities[12] >= 1)
        {
            InventoryItems.totalCoins += (int) Math.Round(cheesePrice * 0.65);
            cheesePrice = (int) Math.Round(cheesePrice / 1.17);
            cheeseAmount += 1;
            currency.text = (InventoryItems.totalCoins).ToString(); 
            cheeseAmountText.text = cheeseAmount.ToString();
            cheesePriceText.text = cheesePrice.ToString();
            removeItemFromInventory(12);
        }
        else
        {
            UiMessageHandler.passedMessage =
                "Δεν έχεις διαθέσιμο τυρί στο inventory σου.";
            UiMessageHandler.desiredDelay = 1f;
        }
    }
    public void sellMeat()
    {
        if (InventoryItems.ItemsQuantities[13] >= 1)
        {
            InventoryItems.totalCoins += (int) Math.Round(meatPrice * 0.65);
            meatPrice = (int) Math.Round(meatPrice / 1.17);
            meatAmount += 1;
            currency.text = (InventoryItems.totalCoins).ToString(); 
            meatAmountText.text = meatAmount.ToString();
            meatPriceText.text = meatPrice.ToString();
            removeItemFromInventory(13);
        }
        else
        {
            UiMessageHandler.passedMessage =
                "Δεν έχεις διαθέσιμο κρέας στο inventory σου.";
            UiMessageHandler.desiredDelay = 1f;
        }
    }

    public void initialise()
    {
        currency.text = (InventoryItems.totalCoins).ToString();
        meatPriceText.text = meatPrice.ToString();
        cheesePriceText.text = cheesePrice.ToString();
        breadPriceText.text = breadPrice.ToString();
        breadAmountText.text = breadAmount.ToString();
        meatAmountText.text = meatAmount.ToString();
        cheeseAmountText.text = cheeseAmount.ToString();
    }

    public void addItemToInventory(int itemID)
    {
        if (InventoryItems.ItemsQuantities[itemID] == 0)//Ιδια διαδικασια και με το itemPickUp
        {
            InventoryItems.newIconID = itemID; 
            InventoryItems.iconUpdate = true;
        }
        InventoryItems.ItemsQuantities[itemID] += 1;
    }

    public void removeItemFromInventory(int itemID)//Εδω γινεται ελεγχος εαν υπαρχει μονο 1 απο αυτο το αντικειμενο σε ποσοτητα. Εαν υπαρχει μονο ενα τοτε γινεται αφαιρεση του εικονιδιου και αντικαθυσταται με το κενο. Η διαδικασια αντικαταστασης γινεται στο InventoryItems οπου υπαρχει σχετικη μεθοδος. Εαν δεν ειναι μονο ενα τοτε αυτο που γινεται ειναι να μειωθει κατα 1 το αντικειμενο σε ποσοτητα.
    {
        if (InventoryItems.ItemsQuantities[itemID] == 1)
        {
            InventoryItems.removeItem = true;
            InventoryItems.removeItemWithID = itemID;
        }

        InventoryItems.ItemsQuantities[itemID] -= 1;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            InventoryItems.totalCoins += 1000; //Cheat code.
            UiMessageHandler.passedMessage = "1000 Coins added to your pocket.";
            UiMessageHandler.desiredDelay = 1f;
        }
    }
}
