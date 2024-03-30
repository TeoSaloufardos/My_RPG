using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SavePlayer : MonoBehaviour
{
    public static int characterPositionData = 3; //0-2 female -- 3-5 male
    public static string playerName = "Player";
    public static GameObject spawnPoint;
    public static GameObject theTarget;
    public static float manaAmount = 1.0f;
    public static bool invisible = false;
    public static bool invulnarable = false; //ean einai h oxi active to super shield
    public static float strenghtAmountDisplay = 0.1f;
    public static float manaAmountDisplay = 0.1f;
    public static float staminaAmountDisplay = 0.1f;
    public static int killsAmount = 0;
    public static int weaponChoice = 0;
    public static bool weaponChange = false;
    public static bool carringWeapon = false;
    public static int armour = 0;
    public static bool changeArmour = false;
    public static float staminaAmount = 1.0f;
    private int checkAmount = 8;
    public static float playerLevel = 0.1f;
    public static int weaponIncrease;
    public static float playerHleath = 1.0f;
    public static int encouragmentIncrease = 0;
    public static float armourValue = 0;
    public static int enemiesOnScreen;

    public static bool saving = false;
    public static bool continueData = false;
    private bool checkForLoad = false;
    private GameObject inventoryObj;
    
    //Save fields
    public int pcharS;
    public string pnameS;
    public float strengthAmtS;
    public float manaPowerAmtS;
    public float staminaPowerAmtS;
    public int killAmtS;
    public int weaponChoiceS;
    public bool carryingWeaponS;
    public int armorS;
    public float playerLevelS;
    public int weaponIncreaseS;
    public float playerHealthS;
    public int strengthIncreaseS;
    public float armorValueS;
    public int goldS;
    public List<int> itemsQuantitiesS;
    
    public bool magicCollectedS;
    public bool spellsCollectedS;
    public List<bool> weaponS;
    public int[] objectTypeS;
    
    void Start()
    {
        DontDestroyOnLoad(this);
        if (continueData)
        {
            string fileLocation = Application.persistentDataPath + "/saveDataFile.dat";
            StreamReader reader = new StreamReader(fileLocation);
            string saveData = reader.ReadToEnd();
            reader.Close();
            JsonUtility.FromJsonOverwrite(saveData, this);

            characterPositionData = pcharS;
            continueData = false;
            checkForLoad = true;
        }
    }

    // Update is called once per frame
    
    // void Update()
    // {
    //     Debug.Log("Ok edw");
    //     if (manaAmount < 1.0)
    //     {
    //         Debug.Log("mana: " + manaAmount);
    //         manaAmount += 0.05f * Time.deltaTime; //gemizei ton eauto tou otan paei katw apo to 100% san regen.
    //     }
    //     if (manaAmount <= 0)
    //     {
    //         manaAmount = 0;
    //     }
    // }

    public void Update()
    {
        if (manaAmount < 1.0)
        {
            manaAmount += ( manaAmountDisplay/10 + 0.040f ) * Time.deltaTime; //gemizei ton eauto tou otan paei katw apo to 100% san regen.
        }
        if (manaAmount <= 0)
        {
            manaAmount = 0;
        }
        if (staminaAmount < 1.0)
        {
            staminaAmount += (staminaAmountDisplay/10 + 0.040f) * Time.deltaTime;
        }
        if (staminaAmount <= 0)
        {
            staminaAmount = 0;
        }
        if (SavePlayer.manaAmount < 0.03)
        {
            SavePlayer.invisible = false;
            invulnarable = false;
            encouragmentIncrease = 0;
        }

        if (killsAmount == checkAmount)
        {
            playerLevel += 0.1f;
            checkAmount = killsAmount + 8;
            strenghtAmountDisplay = playerLevel;
            manaAmountDisplay = playerLevel;
            staminaAmountDisplay = playerLevel;
            weaponIncrease = System.Convert.ToInt32(strenghtAmountDisplay * 90);
        }

        if (armourValue == 1)
        {
            armourValue = 0.002f;
        }
        if (armourValue == 2)
        {
            armourValue = 0.004f;
        }

        if (saving)
        {
            saving = false;
            if (inventoryObj == null)
            {
                inventoryObj = GameObject.Find("InventoryCanvas");
            }
            pcharS = characterPositionData;
            pnameS = playerName;
            strengthAmtS = strenghtAmountDisplay;
            manaPowerAmtS = manaAmount;
            staminaPowerAmtS = staminaAmount;
            killAmtS = killsAmount;
            weaponChoiceS = weaponChoice;
            carryingWeaponS = carringWeapon;
            armorS = armour;
            playerLevelS = playerLevel;
            weaponIncreaseS = weaponIncrease;
            playerHealthS = playerHleath;
            strengthIncreaseS = encouragmentIncrease;
            armorValueS = armourValue;
            goldS = InventoryItems.totalCoins;
            for (int i = 0; i < InventoryItems.ItemsQuantities.Count; i++)
            {
                itemsQuantitiesS[i] = InventoryItems.ItemsQuantities[i];
            }
            magicCollectedS = BookCollect.magicHasCollected;
            spellsCollectedS = BookCollect.spellsHasCollected;
            weaponS = inventoryObj.GetComponent<InventoryItems>().weapons;
            for (int i = 0; i < 16; i++)
            {
                objectTypeS[i] = inventoryObj.GetComponent<InventoryItems>().emptySlots[i].transform.gameObject
                    .GetComponent<PopUpMessageHandler>().objectID;
            }

            string saveData = JsonUtility.ToJson(this);
            string fileLocation = Application.persistentDataPath + "/saveDataFile.dat";
            Debug.Log(fileLocation);
            StreamWriter writer = new StreamWriter(fileLocation);
            writer.WriteLine(saveData);
            writer.Close();
        }

        if (checkForLoad)
        {
            int sceneID = SceneManager.GetActiveScene().buildIndex;
            if (sceneID == 2)
            {
                if (inventoryObj == null)
                {
                    inventoryObj = GameObject.Find("InventoryCanvas");
                }

                if (inventoryObj != null)
                {
                    playerName = pnameS;
                    staminaAmountDisplay = strengthIncreaseS;
                    manaAmount = manaPowerAmtS;
                    staminaAmount = staminaPowerAmtS;
                    killsAmount = killAmtS;
                    weaponChoice = weaponChoiceS;
                    carringWeapon = carryingWeaponS;
                    armour = armorS;
                    playerLevel = playerLevelS;
                    weaponIncrease = weaponIncreaseS;
                    playerHleath = playerHealthS;
                    encouragmentIncrease = strengthIncreaseS;
                    armourValue = armorValueS;
                    InventoryItems.totalCoins = goldS;
                    for (int i = 0; i < InventoryItems.ItemsQuantities.Count; i++)
                    {
                        InventoryItems.ItemsQuantities[i] = itemsQuantitiesS[i];
                    }

                    BookCollect.magicHasCollected = magicCollectedS;
                    BookCollect.spellsHasCollected = spellsCollectedS;
                    if (magicCollectedS)
                    {
                        inventoryObj.GetComponent<InventoryItems>().magicUI.SetActive(true);
                    }
                    if (spellsCollectedS)
                    {
                        inventoryObj.GetComponent<InventoryItems>().spellsUI.SetActive(true);
                    }
                    inventoryObj.GetComponent<InventoryItems>().weapons = weaponS;
                    if (carringWeapon)
                    {
                        weaponChange = true;
                    }

                    if (armour > 0)
                    {
                        changeArmour = true;
                    }
                    for (int i = 0; i < 16; i++)
                    {
                        inventoryObj.GetComponent<InventoryItems>().emptySlots[i].sprite =
                            inventoryObj.GetComponent<InventoryItems>().icons[objectTypeS[i]];
                        inventoryObj.GetComponent<InventoryItems>().emptySlots[i].transform.gameObject
                            .GetComponent<PopUpMessageHandler>().objectID = objectTypeS[i];
                    }

                    checkForLoad = false;
                }
            }
        }
    }
}
