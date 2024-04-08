using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStage : MonoBehaviour
{
    [SerializeField] private GameObject buyWeaponTaskNPC;
    [SerializeField] private GameObject useWeaponTaskNPC;
    [SerializeField] private GameObject lastGuidanceTaskNPC;
    [SerializeField] private GameObject dropTheKey;
    [SerializeField] private GameObject woodenBox;
    [SerializeField] private GameObject fenceOnlyTheExit;
    void Start()
    {
        if (SavePlayer.firstStageCompleted == false)
        {
            lastGuidanceTaskNPC.SetActive(false);
            buyWeaponTaskNPC.SetActive(true);
            useWeaponTaskNPC.SetActive(false);
            dropTheKey.SetActive(false);
            fenceOnlyTheExit.SetActive(true);
        }
        else
        {
            lastGuidanceTaskNPC.SetActive(true);
            buyWeaponTaskNPC.SetActive(false);
            useWeaponTaskNPC.SetActive(false);
            dropTheKey.SetActive(false);
            fenceOnlyTheExit.SetActive(false);
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InventoryItems.totalCoins < 250)
        {
            lastGuidanceTaskNPC.SetActive(false);
            buyWeaponTaskNPC.SetActive(false);
            useWeaponTaskNPC.SetActive(true);
        }
        if (!woodenBox.activeSelf)
        {
            SavePlayer.firstStageCompleted = true;
            lastGuidanceTaskNPC.SetActive(true);
            buyWeaponTaskNPC.SetActive(false);
            useWeaponTaskNPC.SetActive(false);
            dropTheKey.SetActive(true);
            fenceOnlyTheExit.SetActive(false);
            Destroy(this);
        }
    }
}
