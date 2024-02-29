using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicItems : MonoBehaviour
{
    [SerializeField] private GameObject theCanvas;
    [SerializeField] public int itemID;
    
    [HideInInspector] public Image thisImage;
    [HideInInspector] public Color32 startColor = new Color32(255,255,255,160);
    [HideInInspector] public Color32 endColor = new Color32(255,255,255,255);

    [SerializeField] private GameObject inventory;
    private bool check = true;
    private void Start()
    {
        thisImage = GetComponent<Image>();
    }

    private void Update()
    {
        if (theCanvas.GetComponent<CreateMagic>().thisValue == itemID)
        {
            thisImage.color = endColor;
            if (check)
            {
                check = false;
                inventory.GetComponent<InventoryItems>().currentID = itemID;
                inventory.GetComponent<InventoryItems>().changeItemQuantities();
            }
        }
        if (theCanvas.GetComponent<CreateMagic>().thisValue == 0)
        {
            check = true;
            thisImage.color = startColor;
        }
        
    }
}
