using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondStage : MonoBehaviour
{
    [SerializeField] private List<GameObject> fencesToRemove;
    [SerializeField] private GameObject secondStageBuyFood;
    [SerializeField] private GameObject dropKey;
    [SerializeField] private GameObject fenceToTavern;
    private bool keyHasDropped = false;
    
    void Start()
    {
        if (SavePlayer.secondStageCompleted == false)
        {
            foreach (var fence in fencesToRemove)
            {
                fence.SetActive(true);
            }
            dropKey.SetActive(false);
            fenceToTavern.SetActive(true);
            secondStageBuyFood.SetActive(false);
        }
        else
        {
            foreach (var fence in fencesToRemove)
            {
                fence.SetActive(false);
            }
            fenceToTavern.SetActive(false);
            secondStageBuyFood.SetActive(true);
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SavePlayer.killsAmount >= 5)
        {
            secondStageBuyFood.SetActive(true);
            if (!keyHasDropped)
            {
                dropKey.SetActive(true);
                keyHasDropped = true;
            }
            fenceToTavern.SetActive(false);
            SavePlayer.secondStageCompleted = true;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var fence in fencesToRemove)
            {
                fence.SetActive(false);
            }
            Destroy(this);
        }
    }
}
