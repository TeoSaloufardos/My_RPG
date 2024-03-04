using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour
{
    public static int characterPositionData = 0;
    public static string playerName = "Player";
    public static GameObject spawnPoint;
    public static GameObject theTarget;
    
    void Start()
    {
        DontDestroyOnLoad(this); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
