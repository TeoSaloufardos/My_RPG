using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderCheckForArmour : MonoBehaviour
{
    [SerializeField] private GameObject femaleArmour;
    [SerializeField] private GameObject maleArmour;
    // Start is called before the first frame update
    void Start()
    {
        if (SavePlayer.characterPositionData >= 3)
        {
            femaleArmour.SetActive(false);
            maleArmour.SetActive(true);
        }
        else
        {
            femaleArmour.SetActive(true);
            maleArmour.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
