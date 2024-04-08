using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesertAllDeeds : MonoBehaviour
{
    [SerializeField] private GameObject buyWeapon;
    [SerializeField] private GameObject findSpellsBook;
    [SerializeField] private GameObject killFiveSkeletons;
    [SerializeField] private GameObject killTwoBigSkeleton;
    [SerializeField] private GameObject collectFiveHundredCoins;
    [SerializeField] private GameObject answerTenQuestions;
    [SerializeField] private GameObject collectFifteenRoots;
    [SerializeField] private GameObject collectFivePurpleMushr;
    [SerializeField] private GameObject collectedBookObject;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SavePlayer.firstStageCompleted)
        {
            buyWeapon.GetComponentInChildren<Text>().color = Color.green;
        }
        if (!collectedBookObject.activeSelf)
        {
            findSpellsBook.GetComponentInChildren<Text>().color = Color.green;
        }

        if (SavePlayer.smallSkeletonKills >= 5)
        {
            killFiveSkeletons.GetComponentInChildren<Text>().color = Color.green;
        }

        if (SavePlayer.bigSkeletonKills >= 2)
        {
            killTwoBigSkeleton.GetComponentInChildren<Text>().color = Color.green;
        }

        if (InventoryItems.totalCoins >= 500)
        {
            collectFiveHundredCoins.GetComponentInChildren<Text>().color = Color.green;
        }

        if (SavePlayer.thirdStageCompleted)
        {
            answerTenQuestions.GetComponentInChildren<Text>().color = Color.green;
        }

        if (InventoryItems.ItemsQuantities[6] >= 15)
        {
            collectFifteenRoots.GetComponentInChildren<Text>().color = Color.green;
        }

        if (InventoryItems.ItemsQuantities[2] >= 5)
        {
            collectFivePurpleMushr.GetComponentInChildren<Text>().color = Color.green;
        }
    }
}
