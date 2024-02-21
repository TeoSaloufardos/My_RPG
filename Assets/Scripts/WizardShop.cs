using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField] private Text leaddAmountText;

    [Header("Define the prices and amounts down below.")]
    private int redPrice;
    private int purplePrice;
    private int bluePrice;
    private int greenPrice;
    private int pinkEggPrice;
    private int rootsPrice;
    private int leafPrice;
    private int redAmount;
    private int purpleAmount;
    private int blueAmount;
    private int greenAmount;
    private int pinkEggAmount;
    private int rootsAmount;
    private int leafAmount;

    private bool hasInitialised = false;
    
    public void closeShop()
    {
        wizardShop.SetActive(false);
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
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
