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
    private int maxTwo;

    [SerializeField]
    private GameObject inventory;

    [SerializeField] private AudioSource audioPlayer;
    
    void Start()
    {
        expectedValue = values[1];
        max = emptySlots.Count;
        maxTwo = emptySlots.Count;
        audioPlayer = inventory.GetComponent<AudioSource>();
        create();
    }

    public void create()
    {
        Debug.Log("Expected value: " + expectedValue + " value: " + value);
        if (expectedValue == value)
        {
            for (int i = 0; i < max; i++)
            {
                if (emptySlots[i].sprite == emptyIcon)
                {
                    max = i;
                    emptySlots[i].sprite = icons[itemID];
                    audioPlayer.clip = inventory.GetComponent<InventoryItems>().createMagicSound;
                    audioPlayer.Play();
                    emptySlots[i].transform.gameObject.GetComponent<PopUpMessageHandler>().objectID = itemID + 1;
                    value = 0;
                    thisValue = 0;
                }
            }
        }
        max = emptySlots.Count;
    }

    public void removed(int index)
    {
        for (int i = 0; i < maxTwo; i++)
        {
            if (emptySlots[i].sprite == icons[index])
            {
                maxTwo = i;
                emptySlots[i].sprite = emptyIcon;
                emptySlots[i].transform.gameObject.GetComponent<PopUpMessageHandler>().objectID = 0;
            }
        }

        maxTwo = emptySlots.Count;
    }

    public void updateValues()
    {
        value += thisValue;
        expectedValue = values[itemID];
        Debug.Log("value: " + value);
        Debug.Log("Expected Value: " + expectedValue);
        Debug.Log("ItemId: " + itemID);
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
            InventoryItems.ItemsQuantities[1] += 1;
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            value = expectedValue;
        }
    }
}

