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
    private void Start()
    {
        thisImage = GetComponent<Image>();
    }

    private void Update()
    {
        if (theCanvas.GetComponent<CreateMagic>().thisValue == itemID)
        {
            thisImage.color = endColor;
        }
        if (theCanvas.GetComponent<CreateMagic>().thisValue == 0)
        {
            thisImage.color = startColor;
        }
        
    }
}
