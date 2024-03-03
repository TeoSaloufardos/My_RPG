using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WizardShop : MonoBehaviour
{
    [SerializeField] private GameObject wizardShop;
    
    //αρχικοποιηση των κουμπιων που θα μπορει ο παικτης να παταει ειτε για να πουλησει κατι ειτε να αγορασει
    [Header("Down bellow define the buttons that represents the buy/sell actions")]
    [SerializeField] private Button buyRedPotionButton;
    [SerializeField] private Button buyPurplePotionButton;
    [SerializeField] private Button buyBluePotionButton;
    [SerializeField] private Button buyGreenPotionButton;
    [SerializeField] private Button sellRootsButton;
    [SerializeField] private Button sellPinkEggButton;
    [SerializeField] private Button sellLeafButton;
    [SerializeField] private Button closeButton;
    [Header("Down bellow define the texts that represents the prices and amounts of items.")]
    [SerializeField] private Text currency;
    [SerializeField] private Text redPriceText;
    [SerializeField] private Text purplePriceText;
    [SerializeField] private Text bluePriceText;
    [SerializeField] private Text greenPriceText;
    [SerializeField] private Text pinkEggPriceText;
    [SerializeField] private Text rootsPriceText;
    [SerializeField] private Text leafPriceText;
    [SerializeField] private Text redAmountText;
    [SerializeField] private Text blueAmountText;
    [SerializeField] private Text purpleAmountText;
    [SerializeField] private Text greenAmountText;
    [SerializeField] private Text pinkEggAmountText;
    [SerializeField] private Text rootsAmountText;
    [SerializeField] private Text leafAmountText;
    
    [SerializeField] private GameObject inventory;
    [SerializeField] private AudioSource audioPlayer;

    [Header("Define the prices and amounts down below.")]
    private int redPrice = 45;
    private int purplePrice = 68;
    private int bluePrice = 89;
    private int greenPrice = 120;
    private int pinkEggPrice = 35;
    private int rootsPrice = 8;
    private int leafPrice = 8;
    private int redAmount = 17;
    private int purpleAmount = 14;
    private int blueAmount = 11;
    private int greenAmount = 8;
    private int pinkEggAmount = 18;
    private int rootsAmount = 34;
    private int leafAmount = 39;
    private int[] ingredientsIDs = { 15, 14, 6 };
    private bool hasInitialised = false;
    
    public void closeShop()
    {
        wizardShop.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasInitialised)//Αυτο γινεται με αυτο τον τροπο ετσι ωστε να μην επαναρχικοποιουνται τα κουμπια καθε φορα που ο παικτης εισερχεται μεσα στην περιοχη διοτι αυτο δημιουργει πολλαπλες ενεργειες στα κουμπια σαν onClick actions.
            {
                buyRedPotionButton.onClick.AddListener(buyRed);
                buyPurplePotionButton.onClick.AddListener(buyPurple);
                buyBluePotionButton.onClick.AddListener(buyBlue);
                buyGreenPotionButton.onClick.AddListener(buyGreen);
                closeButton.onClick.AddListener(closeShop);
                sellPinkEggButton.onClick.AddListener(sellPinkEgg);
                sellRootsButton.onClick.AddListener(sellRoots);
                sellLeafButton.onClick.AddListener(sellLeaf);
                hasInitialised = true;
            }
            initialise();//ενημερωση των τιμων, χρηματων και αλλων παιδιων που πρεπει για να εμφανιστουν σωστα στον παικτη
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wizardShop.SetActive(false);
        }
    }
    
    public void buyRed()
    {
        if (InventoryItems.hasFreeSpace == false)
        {
            UiMessageHandler.passedMessage = "To inventory σου είναι γεμάτο !!!";
            UiMessageHandler.desiredDelay = 3f;
            return;
        }
        if ((InventoryItems.totalCoins - redPrice) >= 0 && (redAmount - 1) >= 0)
        {
            InventoryItems.totalCoins -= redPrice;
            redPrice = (int)Math.Round(redPrice * 1.17);
            redAmount = redAmount - 1;
            currency.text = (InventoryItems.totalCoins).ToString();
            redAmountText.text = redAmount.ToString();
            redPriceText.text = redPrice.ToString();
            addItemToInventory(10);
        }
        else
        {
            if ((redAmount - 1) <= 0)
            {
                UiMessageHandler.passedMessage = "Δεν υπάρχουν διαθέσιμα αντικείμενα !!!";
                UiMessageHandler.desiredDelay = 2.5f;
                return;
            }
            UiMessageHandler.passedMessage = "Δεν έχεις αρκετά χρήματα !!!";
            UiMessageHandler.desiredDelay = 2.5f;
        }
    }
    
    public void buyPurple()
    {
        if (InventoryItems.hasFreeSpace == false)
        {
            UiMessageHandler.passedMessage = "To inventory σου είναι γεμάτο !!!";
            UiMessageHandler.desiredDelay = 3f;
            return;
        }
        if ((InventoryItems.totalCoins - purplePrice) >= 0 && (purpleAmount - 1) >= 0)
        {
            InventoryItems.totalCoins -= purplePrice;
            purplePrice = (int) Math.Round(purplePrice * 1.17);
            purpleAmount -= 1;
            currency.text = (InventoryItems.totalCoins).ToString(); 
            purpleAmountText.text = purpleAmount.ToString();
            purplePriceText.text = purplePrice.ToString();
            addItemToInventory(9);
            consumeIngredient(1);
        }
        else
        {
            if ((purpleAmount - 1) <= 0)
            {
                UiMessageHandler.passedMessage = "Δεν υπάρχουν διαθέσιμα αντικείμενα !!!";
                UiMessageHandler.desiredDelay = 2.5f;
                return;
            }
            UiMessageHandler.passedMessage = "Δεν έχεις αρκετά χρήματα !!!";
            UiMessageHandler.desiredDelay = 2.5f;
        }
    }
    
    public void buyBlue()
    {
        if (InventoryItems.hasFreeSpace == false)
        {
            UiMessageHandler.passedMessage = "To inventory σου είναι γεμάτο !!!";
            UiMessageHandler.desiredDelay = 3f;
            return;
        }
        if ((InventoryItems.totalCoins - bluePrice) >= 0 && (blueAmount - 1) >= 0)
        {
            InventoryItems.totalCoins -= bluePrice;
            bluePrice = (int) Math.Round(bluePrice * 1.17);
            blueAmount -= 1;
            currency.text = (InventoryItems.totalCoins).ToString(); 
            blueAmountText.text = blueAmount.ToString();
            bluePriceText.text = bluePrice.ToString();
            addItemToInventory(7);
            consumeIngredient(2);
        }
        else
        {
            if ((blueAmount - 1) <= 0)
            {
                UiMessageHandler.passedMessage = "Δεν υπάρχουν διαθέσιμα αντικείμενα !!!";
                UiMessageHandler.desiredDelay = 2.5f;
                return;
            }
            UiMessageHandler.passedMessage = "Δεν έχεις αρκετά χρήματα !!!";
            UiMessageHandler.desiredDelay = 2.5f;
        }
    }
    
    public void buyGreen()
    {
        if (InventoryItems.hasFreeSpace == false)
        {
            UiMessageHandler.passedMessage = "To inventory σου είναι γεμάτο !!!";
            UiMessageHandler.desiredDelay = 3f;
            return;
        }
        if ((InventoryItems.totalCoins - greenPrice) >= 0 && (greenAmount - 1) >= 0)
        {
            InventoryItems.totalCoins -= greenPrice;
            greenPrice = (int) Math.Round(greenPrice * 1.17);
            greenAmount -= 1;
            currency.text = (InventoryItems.totalCoins).ToString(); 
            greenAmountText.text = greenAmount.ToString();
            greenPriceText.text = greenPrice.ToString();
            addItemToInventory(8);
            consumeIngredient(3);
        }
        else
        {
            if ((greenAmount - 1) <= 0)
            {
                UiMessageHandler.passedMessage = "Δεν υπάρχουν διαθέσιμα αντικείμενα !!!";
                UiMessageHandler.desiredDelay = 2.5f;
                return;
            }
            UiMessageHandler.passedMessage = "Δεν έχεις αρκετά χρήματα !!!";
            UiMessageHandler.desiredDelay = 2.5f;
        }
    }
    
    public void sellPinkEgg()
    {
        if (InventoryItems.ItemsQuantities[15] >= 1)
        {
            InventoryItems.totalCoins += (int) Math.Round(pinkEggPrice * 0.65);
            pinkEggPrice = (int) Math.Round(pinkEggPrice / 1.13);
            pinkEggAmount += 1;
            currency.text = (InventoryItems.totalCoins).ToString(); 
            pinkEggAmountText.text = pinkEggAmount.ToString();
            pinkEggPriceText.text = pinkEggPrice.ToString();
            removeItemFromInventory(15);
        }
        else
        {
            UiMessageHandler.passedMessage = "Δεν έχεις διαθέσιμα Ρόζ αυγά στο inventory σου.";
            UiMessageHandler.desiredDelay = 1f;
        }
    }
    
    public void sellRoots()
    {
        if (InventoryItems.ItemsQuantities[6] >= 1)
        {
            InventoryItems.totalCoins += (int) Math.Round(rootsPrice * 0.65);
            rootsPrice = (int) Math.Round(rootsPrice / 1.13);
            rootsAmount += 1;
            currency.text = (InventoryItems.totalCoins).ToString(); 
            rootsAmountText.text = rootsAmount.ToString();
            rootsPriceText.text = rootsPrice.ToString();
            removeItemFromInventory(6);
        }
        else
        {
            UiMessageHandler.passedMessage = "Δεν έχεις διαθέσιμες ρίζες στο inventory σου.";
            UiMessageHandler.desiredDelay = 1f;
        }
    }
    
    public void sellLeaf()
    {
        if (InventoryItems.ItemsQuantities[14] >= 1)
        {
            InventoryItems.totalCoins += (int) Math.Round(leafPrice * 0.65);
            leafPrice = (int) Math.Round(leafPrice / 1.13);
            leafAmount += 1;
            currency.text = (InventoryItems.totalCoins).ToString(); 
            leafAmountText.text = leafAmount.ToString();
            leafPriceText.text = leafPrice.ToString();
            removeItemFromInventory(14);
        }
        else
        {
            UiMessageHandler.passedMessage = "Δεν έχεις διαθέσιμα φύλλα στο inventory σου.";
            UiMessageHandler.desiredDelay = 1f;
        }
    }
    
    public void initialise()
    {
        currency.text = (InventoryItems.totalCoins).ToString();
        redPriceText.text = redPrice.ToString();
        purplePriceText.text = purplePrice.ToString();
        bluePriceText.text = bluePrice.ToString();
        greenPriceText.text = greenPrice.ToString();
        pinkEggPriceText.text = pinkEggPrice.ToString();
        rootsPriceText.text = rootsPrice.ToString();
        leafPriceText.text = leafPrice.ToString();
        blueAmountText.text = blueAmount.ToString();
        purpleAmountText.text = purpleAmount.ToString();
        greenAmountText.text = greenAmount.ToString();
        pinkEggAmountText.text = pinkEggAmount.ToString();
        rootsAmountText.text = rootsAmount.ToString();
        leafAmountText.text = leafAmount.ToString();
    }
    
    public void addItemToInventory(int itemID)
    {
        if (InventoryItems.ItemsQuantities[itemID] == 0)//Ιδια διαδικασια και με το itemPickUp
        {
            InventoryItems.newIconID = itemID; 
            InventoryItems.iconUpdate = true;
        }
        audioPlayer.clip = inventory.GetComponent<InventoryItems>().buySound;
        audioPlayer.Play();
        InventoryItems.ItemsQuantities[itemID] += 1;
    }

    public void removeItemFromInventory(int itemID)//TavernShop
    {
        if (InventoryItems.ItemsQuantities[itemID] == 1)
        {
            InventoryItems.removeItem = true;
            InventoryItems.removeItemWithID = itemID;
        }
        audioPlayer.clip = inventory.GetComponent<InventoryItems>().buySound;
        audioPlayer.Play();
        InventoryItems.ItemsQuantities[itemID] -= 1;
    }

    public void consumeIngredient(int consumeAmount)/*Οταν ο παικτης αγοραζει ενα φιλτρο τοτε αυτο που γινεται 
    ειναι αναλογα με το φιλτρο που αγοραζει να μειωνονεται ενα ποσο απο τα υλικα. Για παραδειγμα
    στην περιπτωση του green potion θα μειωθει τυχαια 3 φορες ενα τυχαιο υλικο. Στην περιπτωση που 
    δεν υπαρχει καποιο υλικο δεν υπαρχει καποιος περιορισμος.*/
    {
        int index = UnityEngine.Random.Range(0, ingredientsIDs.Length);
        int selectedNumber = ingredientsIDs[index];
        if (selectedNumber == 15 && pinkEggAmount - consumeAmount > 0)
        {
            pinkEggAmount -= consumeAmount;
            pinkEggPrice = (int) Math.Round(pinkEggPrice * 1.13);
            pinkEggAmountText.text = pinkEggAmount.ToString();
            pinkEggPriceText.text = pinkEggPrice.ToString();
        }else if (selectedNumber == 14 && leafAmount - consumeAmount > 0)
        {
            leafAmount -= consumeAmount;
            leafPrice = (int) Math.Round(leafPrice * 1.13);
            leafAmountText.text = leafAmount.ToString();
            leafPriceText.text = leafPrice.ToString();
        }else if (selectedNumber == 6 && rootsAmount - consumeAmount > 0)
        {
            rootsAmount -= consumeAmount;
            rootsPrice = (int) Math.Round(rootsPrice * 1.13);
            rootsAmountText.text = rootsAmount.ToString();
            rootsPriceText.text = rootsPrice.ToString();
        }
    }
    
    void Start()
    {
        audioPlayer = inventory.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
