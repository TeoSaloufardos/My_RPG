using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TavernShopUIHandler : MonoBehaviour
{
    // [SerializeField] private GameObject tavernShopGUI;
    // private ItemPickUp addItemToInventory;
    //
    // //αρχικοποιηση των κουμπιων που θα μπορει ο παικτης να παταει ειτε για να πουλησει κατι ειτε να αγορασει
    // [Header("Down bellow define the buttons that represents the buy/sell actions")]
    // [SerializeField] private Button buyBreadButton;
    // [SerializeField] private Button buyCheeseButton;
    // [SerializeField] private Button buyMeatButton;
    // [SerializeField] private Button sellBreadButton;
    // [SerializeField] private Button sellCheeseButton;
    // [SerializeField] private Button sellMeatButton;
    // [SerializeField] private Button closeButton;
    //
    // [Header("Down bellow define the texts that represents the prices and amounts of items.")]
    // [SerializeField] private Text currency;
    // [SerializeField] private Text meatPrice;
    // [SerializeField] private Text cheesePrice;
    // [SerializeField] private Text breadPrice;
    // [SerializeField] private Text breadAmount;
    // [SerializeField] private Text meatAmount;
    // [SerializeField] private Text cheeseAmount;
    //
    // //Στατικα πεδια ετσι ωστε αναλογα την περιοχη να μεταβαλονται απο το script tavernParameters, υπάρχουν και default
    // //values σε περιπτωση που δεν χρειαζεται να καθοριστει καποια συγκεκριμενη τιμη.
    // public static int givenMeatPrice;
    // public static int givenCheesePrice;
    // public static int givenBreadPrice;
    // public static int givenBreadAmount;
    // public static int givenMeatAmount;
    // public static int givenCheeseAmount;
    //
    // private int localMeatPrice;
    // private int localCheesePrice;
    // private int localBreadPrice;
    // private int localBreadAmount;
    // private int localMeatAmount;
    // private int localCheeseAmount;
    //
    // public void closeTavernShop()
    // {
    //     tavernShopGUI.SetActive(false);
    // }
    //
    // // public void initiateTavernShop()
    // // {
    // //     localMeatPrice = givenMeatAmount;
    // //     localCheesePrice =
    // //     localBreadPrice =
    // //     localBreadAmount =
    // //     localMeatAmount = givenMeatAmount;
    // //     localCheeseAmount =
    // //     currency.text = InventoryItems.
    // //     meatPrice.text =
    // //     cheesePrice.text =
    // //     breadPrice.text =
    // //     breadAmount.text =
    // //     meatAmount.text =
    // //     cheeseAmount.text =
    // // }
    //
    // public void buy(int itemID)
    // {
    //     if ((InventoryItems.totalCoins - givenBreadPrice) >= 0)
    //     {
    //         InventoryItems.totalCoins -= givenBreadPrice;
    //         if (itemID == 11)
    //         {
    //             givenBreadPrice += (int) Math.Round(givenBreadPrice * 1.05);
    //             givenBreadAmount -= 1;
    //             breadAmount.text = givenBreadAmount.ToString();
    //             currency.text = InventoryItems.totalCoins.ToString(); 
    //             breadPrice.text = givenBreadPrice.ToString();
    //         }
    //         else if (itemID == 12)
    //         {
    //             givenCheesePrice += (int) Math.Round(givenCheesePrice * 1.05);
    //             givenCheeseAmount -= 1;
    //             cheeseAmount.text = givenCheeseAmount.ToString();
    //             currency.text = InventoryItems.totalCoins.ToString(); 
    //             cheesePrice.text = cheesePrice.ToString();
    //         }
    //         else
    //         {
    //             givenMeatPrice += (int) Math.Round(givenMeatPrice * 1.05);
    //             givenMeatAmount -= 1;
    //             meatAmount.text = givenMeatAmount.ToString();
    //             currency.text = InventoryItems.totalCoins.ToString();
    //             meatPrice.text = givenMeatPrice.ToString();
    //         }
    //     }
    //     else
    //     {
    //         if (!addItemToInventory.addPurchasedItem(itemID, true))
    //         {
    //             UiMessageHandler.passedMessage = "Δεν έχεις χώρο στο inventory σου !!!";
    //             return;
    //         }
    //         UiMessageHandler.passedMessage = "Δεν έχεις αρκετά χρήματα !!!";
    //         UiMessageHandler.desiredDelay = 2.5f;
    //     }
    // }
    //
    // public void sell(int itemID)
    // {
    //     if ((InventoryItems.totalCoins - givenBreadPrice) >= 0 && addItemToInventory.addPurchasedItem(itemID,true))
    //     {
    //         InventoryItems.totalCoins -= givenBreadPrice;
    //         givenBreadPrice += (int) Math.Round(givenBreadPrice * 1.05);
    //         givenBreadAmount -= 1;
    //         breadAmount.text = givenBreadAmount.ToString();
    //         currency.text = InventoryItems.totalCoins.ToString();
    //     }
    //     else
    //     {
    //         if (!addItemToInventory.addPurchasedItem(11, true))
    //         {
    //             UiMessageHandler.passedMessage = "Δεν έχεις χώρο στο inventory σου !!!";
    //             return;
    //         }
    //         UiMessageHandler.passedMessage = "Δεν έχεις αρκετά χρήματα !!!";
    //         UiMessageHandler.desiredDelay = 2.5f;
    //     }
    // }
}
