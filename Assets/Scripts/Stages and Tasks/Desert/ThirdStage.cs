using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdStage : MonoBehaviour
{
    [SerializeField] private GameObject answerQuestionsNPC;
    [SerializeField] private GameObject taskToCompleteAllDeeds;
    [SerializeField] private GameObject fenceToRemove;
    [SerializeField] private List<GameObject> wiseMen;
    
    void Start()
    {
        if (SavePlayer.thirdStageCompleted == false && SavePlayer.secondStageCompleted)
        {
            answerQuestionsNPC.SetActive(true);
            taskToCompleteAllDeeds.SetActive(false);
            fenceToRemove.SetActive(true);
            foreach (var wise in wiseMen)
            {
                wise.SetActive(true);
            }
        }
        else
        {
            foreach (var wise in wiseMen)
            {
                wise.SetActive(false);
            }
            answerQuestionsNPC.SetActive(false);
            taskToCompleteAllDeeds.SetActive(true);
            fenceToRemove.SetActive(false);
            Destroy(this);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((SavePlayer.correctAnswers + SavePlayer.wrongAnswers) >= 10)
        {
            answerQuestionsNPC.SetActive(false);
            taskToCompleteAllDeeds.SetActive(true);
            fenceToRemove.SetActive(false);
            SavePlayer.thirdStageCompleted = true;
            addItemToInventory(15);
            Destroy(this);
        }
    }
    
    public void addItemToInventory(int itemID)
    {
        if (InventoryItems.ItemsQuantities[itemID] == 0)//Ιδια διαδικασια και με το itemPickUp
        {
            InventoryItems.newIconID = itemID; 
            InventoryItems.iconUpdate = true;
        }
        InventoryItems.ItemsQuantities[itemID] += 1;
    }
}
