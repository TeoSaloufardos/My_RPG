using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillageAllStages : MonoBehaviour
{
    [SerializeField] private GameObject firstNPC;
    [SerializeField] private GameObject secondNPCFields;
    [SerializeField] private GameObject thirdNPCBoss;
    [SerializeField] private GameObject fields;
    [SerializeField] private List<GameObject> keys;
    [SerializeField] private GameObject singleSpawnSpawners;
    [SerializeField] private GameObject multiSpawnSpawners;

    //deeds ui
    [SerializeField] private GameObject killAllMobsUI;
    [SerializeField] private GameObject collectWheats;
    [SerializeField] private GameObject collectFiveKeys;
    [SerializeField] private GameObject openTheDungeonGate;
    [SerializeField] private GameObject killTheSpider;
    [SerializeField] private GameObject allCompleted;
    
    [SerializeField] private GameObject inventory;
    [SerializeField] private AudioClip victorySound;
    public static bool keysCollected = false;
    
    private bool killAllMobsCompleted = false;
    private bool collectWheatsCompleted = false;
    private bool collectFiveKeysCompleted = false;
    private bool openTheDungeonGateCompleted = false; 
    private bool killTheSpiderCompleted = false;
    void Start()
    {
        if (SavePlayer.villageAllCompleted)
        {
            firstNPC.SetActive(false);
            secondNPCFields.SetActive(false);
            thirdNPCBoss.SetActive(false);
            fields.SetActive(false);
            singleSpawnSpawners.SetActive(false);
            multiSpawnSpawners.SetActive(true);
            foreach (var key in keys)
            {
                key.SetActive(false);
            }
            Destroy(this);
        }   
        firstNPC.SetActive(true);
        multiSpawnSpawners.SetActive(false);
        singleSpawnSpawners.SetActive(true);
        killTheSpider.SetActive(false);
        secondNPCFields.SetActive(false);
        thirdNPCBoss.SetActive(false);
        foreach (var key in keys)
        {
            key.SetActive(false);
        }
        fields.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!killAllMobsCompleted && SavePlayer.smallSkeletonKills >= 10 && SavePlayer.bigSkeletonKills >= 4 && SavePlayer.pigKills >= 4)
        {
            killAllMobsCompleted = true;
            firstNPC.SetActive(false);
            secondNPCFields.SetActive(true);
            killAllMobsUI.gameObject.GetComponentInChildren<Text>().color = Color.green;
            fields.SetActive(true);
        }

        if (!collectWheatsCompleted && InventoryItems.ItemsQuantities[17] >= 20)
        {
            secondNPCFields.SetActive(false);
            thirdNPCBoss.SetActive(true);
            collectWheats.GetComponentInChildren<Text>().color = Color.green;
            collectWheatsCompleted = true;
            multiSpawnSpawners.SetActive(true);
            singleSpawnSpawners.SetActive(false);
            foreach (var key in keys)
            {
                key.SetActive(true);
            }
        }

        if (!collectFiveKeysCompleted)
        {
            int collectedKeys = 0;
            foreach (var key in keys)
            {
                if (key == null)
                {
                    collectedKeys++;
                }
            }

            if (collectedKeys >= 5)
            {
                collectFiveKeysCompleted = true;
                keysCollected = true;
                collectFiveKeys.GetComponentInChildren<Text>().color = Color.green;
            }
            else
            {
                collectedKeys = 0;
            }
        }

        if (!openTheDungeonGateCompleted && !openTheDungeonGate.activeSelf)
        {
            openTheDungeonGate.GetComponentInChildren<Text>().color = Color.green;
            openTheDungeonGateCompleted = true;
            thirdNPCBoss.SetActive(false);
        }

        if (openTheDungeonGateCompleted && killAllMobsCompleted && collectWheatsCompleted && collectWheatsCompleted)
        {
            killTheSpider.SetActive(true);
            collectWheats.SetActive(false);
            collectFiveKeys.SetActive(false);
            killAllMobsUI.SetActive(false);
        }

        if (SavePlayer.spiderKilled >= 1)
        {
            SavePlayer.villageAllCompleted = true;
            allCompleted.SetActive(true);
            killTheSpider.SetActive(false);
            inventory.GetComponent<AudioSource>().clip = victorySound;
            inventory.GetComponent<AudioSource>().Play();
            Destroy(this);
        }
    }
}
