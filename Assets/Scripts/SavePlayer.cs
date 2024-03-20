using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour
{
    public static int characterPositionData = 3;
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
    private int checkAmount = 1;
    public static float playerLevel = 0.1f;
    public static int weaponIncrease;
    public static float playerHleath = 1.0f;
    public static int encouragmentIncrease = 0;
    
    void Start()
    {
        DontDestroyOnLoad(this); 
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
            checkAmount = killsAmount + 2;
            strenghtAmountDisplay = playerLevel;
            manaAmountDisplay = playerLevel;
            staminaAmountDisplay = playerLevel;
            weaponIncrease = System.Convert.ToInt32(strenghtAmountDisplay * 90);
        }
    }
}
