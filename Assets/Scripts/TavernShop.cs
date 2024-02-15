using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class TavernShop : MonoBehaviour
{
    [SerializeField] private GameObject tavernShopGUI;
    private ItemPickUp addItemToInventory;
    
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            initialise();
            buyBreadButton.onClick.AddListener(buyBread);
            buyCheeseButton.onClick.AddListener(buyCheese);
            buyMeatButton.onClick.AddListener(buyMeat);
            closeButton.onClick.AddListener(closeShop);
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
    public void buyBread()
    {
        Debug.Log("1 bread price " + breadPrice);
        Debug.Log("1 bread amount " + breadAmount);
        Debug.Log("1 Coins " + InventoryItems.totalCoins);
        if ((InventoryItems.totalCoins - breadPrice) >= 0 && (breadAmount - 1) >= 0) //&& addItemToInventory.addPurchasedItem(itemID,true))
        {
            Debug.Log("2 bread amount " + breadAmount);
            Debug.Log("2 Bread price " + breadPrice);
            Debug.Log("2 Coins " + InventoryItems.totalCoins);
            InventoryItems.totalCoins -= breadPrice;
            Debug.Log("3 Bread price " + breadPrice);
            Debug.Log("3 Coins " + InventoryItems.totalCoins);
            breadPrice = (int)Math.Round(breadPrice * 1.17);
            Debug.Log("4 Bread price " + breadPrice);
            breadAmount = breadAmount - 1;
            Debug.Log("3 bread amount " + breadAmount);
            currency.text = (InventoryItems.totalCoins).ToString();
            breadAmountText.text = breadAmount.ToString();
            breadPriceText.text = breadPrice.ToString();
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
        if ((InventoryItems.totalCoins - cheesePrice) >= 0 && (cheeseAmount - 1) >= 0) //&& addItemToInventory.addPurchasedItem(itemID,true))
        {
            InventoryItems.totalCoins -= cheesePrice;
            cheesePrice = (int) Math.Round(cheesePrice * 1.17);
            cheeseAmount -= 1;
            currency.text = (InventoryItems.totalCoins).ToString(); 
            cheeseAmountText.text = cheeseAmount.ToString();
            cheesePriceText.text = cheesePrice.ToString();
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
        if ((InventoryItems.totalCoins - meatPrice) >= 0 && (meatAmount - 1) >= 0) //&& addItemToInventory.addPurchasedItem(itemID,true))
        {
            InventoryItems.totalCoins -= meatPrice;
            meatPrice = (int) Math.Round(meatPrice * 1.17);
            meatAmount -= 1;
            currency.text = (InventoryItems.totalCoins).ToString(); 
            meatAmountText.text = meatAmount.ToString();
            meatPriceText.text = meatPrice.ToString();
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
    
    void Start()
    {
        
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
