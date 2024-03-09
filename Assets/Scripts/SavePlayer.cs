using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour
{
    public static int characterPositionData = 0;
    public static string playerName = "Player";
    public static GameObject spawnPoint;
    public static GameObject theTarget;
    public static float manaAmount = 1.0f;
    public static bool invisible = false;
    
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
}
