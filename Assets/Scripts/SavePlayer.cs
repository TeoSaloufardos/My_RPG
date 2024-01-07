using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour
{
    public static int characterPositionData = 0;
    public static string playerName = "Player";
    
    void Start()
    {
        DontDestroyOnLoad(this); //Με αυτο δηλωνω οτι ακόμα και σε μια αλλαγη σε ενα scene δεν θα καταστραφει το object αυτο. Με αυτόν τον τρόπο μπορώ και κρατάω δεδομένα και τα περνάω μεσα σε αλλα scenes.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
