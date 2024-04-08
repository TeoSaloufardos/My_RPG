using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthStage : MonoBehaviour
{
    [SerializeField] private GameObject fourthStageNPC;
    [SerializeField] private GameObject bookCollectedGameObject;
    [SerializeField] private GameObject enableSpawnEnemiesTrigger;
    void Start()
    {
        if (SavePlayer.fourthStageCompleted)
        {
            Destroy(enableSpawnEnemiesTrigger);
            fourthStageNPC.SetActive(false);
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!bookCollectedGameObject.activeSelf)
        {
            enableSpawnEnemiesTrigger.SetActive(true);
            fourthStageNPC.SetActive(true);
            Destroy(this);
        }
    }
}
