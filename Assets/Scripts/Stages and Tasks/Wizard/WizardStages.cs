using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WizardStages : MonoBehaviour
{
    [SerializeField] private GameObject firstNPC;
    [SerializeField] private GameObject secondNPC;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject chest;
    [SerializeField] private GameObject fence;
    [SerializeField] private GameObject bookParticle;

    [SerializeField] private GameObject collectBlueFlowers;
    [SerializeField] private GameObject killTwoBigSkeletons;
    [SerializeField] private GameObject killFiveSmallSkeletons;
    [SerializeField] private GameObject killThreePigMen;
    [SerializeField] private GameObject findAndCollectTheBook;
    [SerializeField] private GameObject craftTwoPotions;
    [SerializeField] private GameObject findTheLostkey;
    [SerializeField] private GameObject allCompleted;

    private bool collectBlueFlowersCompleted = false;
    private bool killTwoBigSkeletonsCompleted = false;
    private bool killFiveSmallSkeletonsCompleted = false;
    private bool killThreePigMenCompleted = false;
    private bool findAndCollectTheBookCompleted = false;
    private bool craftTwoPotionsCompleted = false;
    private bool findTheLostkeyCompleted = false;
    void Start()
    {
        if (SavePlayer.witchAllCompleted)
        {
            firstNPC.SetActive(false);
            secondNPC.SetActive(false);
            key.SetActive(false);
            chest.SetActive(false);
            fence.SetActive(false);
            allCompleted.SetActive(true);
            Destroy(this);
        }
        if (SavePlayer.firstStagePickUpBookCompleted)
        {
            firstNPC.SetActive(false);
            secondNPC.SetActive(true);
            key.SetActive(true);
            chest.SetActive(false);
            fence.SetActive(true);
            return;
        }
        firstNPC.SetActive(true);
        secondNPC.SetActive(false);
        key.SetActive(true);
        chest.SetActive(false);
        fence.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if ((InventoryItems.ItemsQuantities[7] + InventoryItems.ItemsQuantities[8] + InventoryItems.ItemsQuantities[9] + InventoryItems.ItemsQuantities[10]) >=2 && !craftTwoPotionsCompleted)
        {
            craftTwoPotions.gameObject.GetComponentInChildren<Text>().color = Color.green;
            craftTwoPotionsCompleted = true;
        }

        if (bookParticle == null && !findAndCollectTheBookCompleted)
        {
            findAndCollectTheBook.gameObject.GetComponentInChildren<Text>().color = Color.green;
            firstNPC.SetActive(false);
            secondNPC.SetActive(true);
            findAndCollectTheBookCompleted = true;
        }
        if (key == null && !findTheLostkeyCompleted)
        {
            findTheLostkey.gameObject.GetComponentInChildren<Text>().color = Color.green;
            findTheLostkeyCompleted = true;
            chest.SetActive(true);
        }

        if (SavePlayer.smallSkeletonKills >= 5 && !killFiveSmallSkeletonsCompleted)
        {
            killFiveSmallSkeletons.gameObject.GetComponentInChildren<Text>().color = Color.green;
            killFiveSmallSkeletonsCompleted = true;
        }

        if (SavePlayer.bigSkeletonKills >= 2 && !killTwoBigSkeletonsCompleted)
        {
            killTwoBigSkeletons.gameObject.GetComponentInChildren<Text>().color = Color.green;
            killTwoBigSkeletonsCompleted = true;
        }

        if (SavePlayer.pigKills >= 3 && !killThreePigMenCompleted)
        {
            killThreePigMen.gameObject.GetComponentInChildren<Text>().color = Color.green;
            killThreePigMenCompleted = true;
        }

        if (InventoryItems.ItemsQuantities[5] >= 15 && !collectBlueFlowersCompleted)
        {
            collectBlueFlowers.gameObject.GetComponentInChildren<Text>().color = Color.green;
            collectBlueFlowersCompleted = true;
        }

        if ((collectBlueFlowersCompleted && killTwoBigSkeletonsCompleted && killFiveSmallSkeletonsCompleted && killThreePigMenCompleted && findAndCollectTheBookCompleted && craftTwoPotionsCompleted && findTheLostkeyCompleted) || Input.GetKeyDown(KeyCode.O))
        {
            SavePlayer.witchAllCompleted = true;
            collectBlueFlowers.SetActive(false);
            killTwoBigSkeletons.SetActive(false);
            killFiveSmallSkeletons.SetActive(false);
            killThreePigMen.SetActive(false);
            findAndCollectTheBook.SetActive(false);
            craftTwoPotions.SetActive(false);
            findTheLostkey.SetActive(false);
            allCompleted.SetActive(true);
            Destroy(fence);
            Destroy(this);
        }
        
    }
}
