using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyWeapon : MonoBehaviour
{
    [SerializeField] private int weaponNumber = 0;
    [SerializeField] public int cost;
    [SerializeField] private Text currencyText;
    [SerializeField] private GameObject inventoryObject;
    [SerializeField] private int armourNumber;
    private AudioSource audioPlayer;
    
    void Start()
    {
        currencyText.text = InventoryItems.totalCoins.ToString();
        audioPlayer = inventoryObject.GetComponent<AudioSource>();
    }

    public void buyWeaponButtonAction()
    {
        if (InventoryItems.totalCoins >= cost)
        {
            InventoryItems.totalCoins -= cost;
            inventoryObject.GetComponent<InventoryItems>().weapons[weaponNumber] = true;
            currencyText.text = InventoryItems.totalCoins.ToString();
            audioPlayer.clip = inventoryObject.GetComponent<InventoryItems>().buySound;
            audioPlayer.Play();
        }
    }

    public void buyArmour()
    {
        if (InventoryItems.totalCoins >= cost)
        {
            InventoryItems.totalCoins -= cost;
            SavePlayer.armour = armourNumber;
            SavePlayer.changeArmour = true;
            currencyText.text = InventoryItems.totalCoins.ToString();
            audioPlayer.clip = inventoryObject.GetComponent<InventoryItems>().buySound;
            audioPlayer.Play();
        }
    }
}
