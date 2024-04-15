using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageOneMountain : MonoBehaviour
{
    [SerializeField] private GameObject theWholeStageWithObjects;
    [SerializeField] private GameObject firstNPC;
    [SerializeField] private GameObject secondNPC;
    [SerializeField] private GameObject thirdNPC;
    [SerializeField] private GameObject boxColliderOfLab;
    [SerializeField] private GameObject chest;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject fences;
    [SerializeField] private List<GameObject> boxes;
    [SerializeField] private GameObject wises;
    public static bool superWiseHasFound;
    public static bool chestHasFound;
    public static bool labHasFound;
    private bool mobsHasKilled;
    private bool fourBoxesHasDestroyed = false;
    private bool keyHasFound;
    
    //Pedia pou emfanizoun tis apostoles
    [SerializeField] private GameObject destroyBoxes;
    [SerializeField] private GameObject collect15BrownMushrooms;
    [SerializeField] private GameObject collectFourRedMushrooms;
    [SerializeField] private GameObject findTheLab;
    [SerializeField] private GameObject findTheSuperWise;
    [SerializeField] private GameObject answerTenQuestions;
    [SerializeField] private GameObject killOneBigAndThreePigs;
    [SerializeField] private GameObject findTheHiddenChest;
    [SerializeField] private GameObject allCompleted;
    
    void Start()
    {
        firstNPC.SetActive(true);
        secondNPC.SetActive(false);
        thirdNPC.SetActive(false);
        fences.SetActive(true);
        chest.SetActive(false);
        boxColliderOfLab.SetActive(false);
        wises.SetActive(false);
        key.SetActive(false);
        
        if (SavePlayer.taskOneCompleted)
        {
            firstNPC.SetActive(false);
            wises.SetActive(true);
        }
        if (SavePlayer.taskTwoCompleted)
        {
            key.SetActive(false);
            secondNPC.SetActive(false);
            thirdNPC.SetActive(true);
            boxColliderOfLab.SetActive(true);
        }
        if (SavePlayer.taskThreeCompleted)
        {
            thirdNPC.SetActive(false);
        }

        if (SavePlayer.mountainAllCompleted)
        {
            Destroy(theWholeStageWithObjects);
        }
    }
    
    void Update()
    {
        if (firstNPC.activeSelf)
        {
            int destroyedBoxes = 0;
            foreach (var box in boxes)
            {
                if (!box.activeSelf)
                {
                    destroyedBoxes++;
                }
            }

            if (destroyedBoxes >= 4)
            {
                fourBoxesHasDestroyed = true;
            }
        }
        if (InventoryItems.ItemsQuantities[3] >= 15 && InventoryItems.ItemsQuantities[1] >= 4 && fourBoxesHasDestroyed)
        {
            firstNPC.SetActive(false);
            secondNPC.SetActive(true);
            wises.SetActive(true);
            SavePlayer.taskOneCompleted = true;
        }
        if ((SavePlayer.correctAnswers + SavePlayer.wrongAnswers) >= 10 && superWiseHasFound)
        {
            if (!keyHasFound)
            {
                key.SetActive(true);
                secondNPC.SetActive(false);
                thirdNPC.SetActive(true);
                chest.SetActive(true);
                boxColliderOfLab.SetActive(true);
                keyHasFound = true;
                SavePlayer.taskTwoCompleted = true;
            }
        }

        if (chestHasFound && labHasFound)
        {
            thirdNPC.SetActive(false);
            SavePlayer.taskThreeCompleted = true;
        }

        if (SavePlayer.bigSkeletonKills >= 1 && SavePlayer.pigKills >= 3)
        {
            mobsHasKilled = true;
            killOneBigAndThreePigs.GetComponentInChildren<Text>().color = Color.green;
        }

        if (chestHasFound)
        {
            findTheHiddenChest.GetComponentInChildren<Text>().color = Color.green;
        }

        if (labHasFound)
        {
            findTheLab.GetComponentInChildren<Text>().color = Color.green;
        }

        if (InventoryItems.ItemsQuantities[3] >= 15)
        {
            collect15BrownMushrooms.GetComponentInChildren<Text>().color = Color.green;
        }

        if (InventoryItems.ItemsQuantities[1] >= 4)
        {
            collectFourRedMushrooms.GetComponentInChildren<Text>().color = Color.green;
        }

        if (fourBoxesHasDestroyed)
        {
            destroyBoxes.GetComponentInChildren<Text>().color = Color.green;
        }

        if (superWiseHasFound)
        {
            findTheSuperWise.GetComponentInChildren<Text>().color = Color.green;
        }

        if ((SavePlayer.correctAnswers + SavePlayer.wrongAnswers) >= 10)
        {
            answerTenQuestions.GetComponentInChildren<Text>().color = Color.green;
        }

        if ((SavePlayer.correctAnswers + SavePlayer.wrongAnswers) >= 10 && superWiseHasFound && fourBoxesHasDestroyed && InventoryItems.ItemsQuantities[1] >= 4 && InventoryItems.ItemsQuantities[3] >= 15 && labHasFound && chestHasFound && SavePlayer.bigSkeletonKills >= 1 && SavePlayer.pigKills >= 3)
        {
            SavePlayer.mountainAllCompleted = true;
            Destroy(theWholeStageWithObjects);
        }
        
    }
}
