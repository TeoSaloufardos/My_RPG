using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisplay : MonoBehaviour
{
    [SerializeField] private List<GameObject> playersDisplay;//einai script pou kathorizei me vash thn epilogh character poio character tha emfanizetai mesa sto stats section sto inventory.
    void Start()
    {
        for (int i = 0; i < playersDisplay.Count; i++)
        {
            playersDisplay[i].SetActive(false);
        }
        playersDisplay[SavePlayer.characterPositionData].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
