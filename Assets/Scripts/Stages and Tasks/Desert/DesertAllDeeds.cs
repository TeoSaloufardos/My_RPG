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
    [SerializeField] private List<GameObject> allMessages;
    [SerializeField] private GameObject completeMessage;
    [SerializeField] private GameObject finalDesertNPC;
    [SerializeField] private GameObject fenceForNextStage;
    [SerializeField] private List<GameObject> desertStagesCleaner;
    
    void Start()
    {
        finalDesertNPC.SetActive(false);
        completeMessage.SetActive(false);
        fenceForNextStage.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (((SavePlayer.firstStageCompleted && !collectedBookObject.activeSelf && SavePlayer.smallSkeletonKills >= 5 &&
             SavePlayer.bigSkeletonKills >= 2 && InventoryItems.totalCoins >= 260 && SavePlayer.thirdStageCompleted &&
             InventoryItems.ItemsQuantities[6] >= 15 && InventoryItems.ItemsQuantities[2] >= 5) || SavePlayer.desertAllCompleted) || Input.GetKeyDown(KeyCode.B))
        {
            finalDesertNPC.SetActive(true);
            foreach (var stage in desertStagesCleaner)
            {
                Destroy(stage);
            }

            foreach (var message in allMessages)
            {
                Destroy(message);
            }
            completeMessage.SetActive(true);
            fenceForNextStage.SetActive(false);
            finalDesertNPC.SetActive(true);
            SavePlayer.desertAllCompleted = true;
            Destroy(this);
        }

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

        if (InventoryItems.totalCoins >= 260)
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
