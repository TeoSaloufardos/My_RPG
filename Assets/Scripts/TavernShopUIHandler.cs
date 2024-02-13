using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TavernShopUIHandler : MonoBehaviour
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
    [SerializeField] private Text meatPrice;
    [SerializeField] private Text cheesePrice;
    [SerializeField] private Text breadPrice;
    [SerializeField] private Text breadAmount;
    [SerializeField] private Text meatAmount;
    [SerializeField] private Text cheeseAmount;

    //Στατικα πεδια ετσι ωστε αναλογα την περιοχη να μεταβαλονται απο το script tavernParameters, υπάρχουν και default
    //values σε περιπτωση που δεν χρειαζεται να καθοριστει καποια συγκεκριμενη τιμη.
    public static int givenMeatPrice = 15;
    public static int givenCheesePrice = 10;
    public static int givenBreadPrice = 8;

    public void closeTavernShop()
    {
        tavernShopGUI.SetActive(false);
    }

    public void buyBread()
    {
        
    }
    
    public void buyChesse()
    {
        
    }
    
    public void buyMeat()
    {
        
    }

    public void sellMeat()
    {
        
    }

    public void sellBread()
    {
        
    }

    public void sellCheese()
    {
        
    }
}
