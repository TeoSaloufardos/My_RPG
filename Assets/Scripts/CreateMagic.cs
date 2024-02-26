using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMagic : MonoBehaviour
{
    [SerializeField] private List<int> values;
    [HideInInspector] public int expectedValue;
    [HideInInspector] public int value;
    [SerializeField] private List<Image> emptySlots;
    [SerializeField] private List<Sprite> icons;
    [SerializeField] private Sprite emptyIcon;
    [HideInInspector] public int itemID;
    private int max;
    [HideInInspector] public int thisValue; 
    
    
    void Start()
    {
        expectedValue = values[0];
        max = emptySlots.Count;
        create();
    }

    public void create()
    {
        if (expectedValue == value)
        {
            for (int i = 0; i < max; i++)
            {
                if (emptySlots[i].sprite == emptyIcon)
                {
                    max = i;
                    emptySlots[i].sprite = icons[itemID];
                    value = 0;
                    thisValue = 0;
                }
            }
        }
        max = emptySlots.Count;
    }

    public void updateValues()
    {
        value += thisValue;
        expectedValue = values[itemID];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (InventoryItems.ItemsQuantities[1] == 0) //Ιδια διαδικασια και με το itemPickUp
            {
                InventoryItems.newIconID = 1;
                InventoryItems.iconUpdate = true;
            }
            InventoryItems.ItemsQuantities[6] += 1;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (InventoryItems.ItemsQuantities[6] == 0) //Ιδια διαδικασια και με το itemPickUp
            {
                InventoryItems.newIconID = 6;
                InventoryItems.iconUpdate = true;
            }
            InventoryItems.ItemsQuantities[6] += 1;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (InventoryItems.ItemsQuantities[10] == 0) //Ιδια διαδικασια και με το itemPickUp
            {
                InventoryItems.newIconID = 10;
                InventoryItems.iconUpdate = true;
            }
            InventoryItems.ItemsQuantities[10] += 1;
        }
    }
}

