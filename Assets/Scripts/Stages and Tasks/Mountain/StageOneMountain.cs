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
    [SerializeField] private GameObject regionalCollider;
    public static bool superWiseHasFound;
    public static bool chestHasFound;
    public static bool labHasFound;
    public static bool playerJoinedToRegion = false;
    private bool mobsHasKilled;
    private bool fourBoxesHasDestroyed = false;
    private bool keyHasFound;
    private bool playerInRegion = false;
    
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

    private bool destroyBoxesCompleted = false;
    private bool collect15BrownMushroomsCompleted = false;
    private bool collectFourRedMushroomsCompleted = false;
    private bool findTheLabCompleted = false;
    private bool findTheSuperWiseCompleted = false;
    private bool killOneBigAndThreePigsCompleted = false;
    private bool findTheHiddenChestCompleted = false;
    private bool answerTenQuestionsCompleted = false;
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
            fences.SetActive(false);
            Destroy(theWholeStageWithObjects);
        }
    }
    
    void Update()
    {
        if (playerJoinedToRegion && !playerInRegion)
        {
            playerInRegion = true;
        }
        if (firstNPC.activeSelf && !destroyBoxesCompleted)
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
                destroyBoxesCompleted = true;
            }
        }
        if (InventoryItems.ItemsQuantities[3] >= 15 && InventoryItems.ItemsQuantities[1] >= 4 && fourBoxesHasDestroyed && !collect15BrownMushroomsCompleted && !collectFourRedMushroomsCompleted)
        {
            firstNPC.SetActive(false);
            secondNPC.SetActive(true);
            wises.SetActive(true);
            SavePlayer.taskOneCompleted = true;
            collectFourRedMushroomsCompleted = true;
            collect15BrownMushroomsCompleted = true;
        }
        if ((SavePlayer.correctAnswers + SavePlayer.wrongAnswers) >= 10 && superWiseHasFound && !findTheSuperWiseCompleted && !answerTenQuestionsCompleted)
        {
            if (!keyHasFound)
            {
                key.SetActive(true);
                secondNPC.SetActive(false);
                thirdNPC.SetActive(true);
                chest.SetActive(true);
                boxColliderOfLab.SetActive(true);
                keyHasFound = true;
                findTheSuperWiseCompleted = true;
                answerTenQuestionsCompleted = true;
                SavePlayer.taskTwoCompleted = true;
            }
        }

        if (chestHasFound && labHasFound && !findTheLabCompleted && !findTheHiddenChestCompleted)
        {
            thirdNPC.SetActive(false);
            findTheLabCompleted = true;
            findTheHiddenChestCompleted = true;
            SavePlayer.taskThreeCompleted = true;
        }

        if (SavePlayer.bigSkeletonKills >= 1 && SavePlayer.pigKills >= 3 && !killOneBigAndThreePigsCompleted)
        {
            mobsHasKilled = true;
            killOneBigAndThreePigsCompleted = true;
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

        if ((SavePlayer.correctAnswers + SavePlayer.wrongAnswers) >= 10 && playerInRegion)
        {
            answerTenQuestions.GetComponentInChildren<Text>().color = Color.green;
        }

        if ((destroyBoxesCompleted && collect15BrownMushroomsCompleted && collectFourRedMushroomsCompleted && findTheLabCompleted && findTheSuperWiseCompleted && killOneBigAndThreePigsCompleted && findTheHiddenChestCompleted && answerTenQuestionsCompleted) || Input.GetKeyDown(KeyCode.H))
        {
            fences.SetActive(false);
            SavePlayer.mountainAllCompleted = true;
            allCompleted.SetActive(true);
            destroyBoxes.SetActive(false);
            collect15BrownMushrooms.SetActive(false);
            collectFourRedMushrooms.SetActive(false);
            findTheLab.SetActive(false);
            findTheSuperWise.SetActive(false);
            answerTenQuestions.SetActive(false);
            killOneBigAndThreePigs.SetActive(false);
            findTheHiddenChest.SetActive(false);
            Destroy(theWholeStageWithObjects);
        }
        
    }
}
