using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour
{
    public static int characterPositionData = 0;
    public static string playerName = "Player";
    public static GameObject spawnPoint;
    
    void Start()
    {
        DontDestroyOnLoad(this); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
