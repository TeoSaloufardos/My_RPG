using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofHandler : MonoBehaviour
{
    [SerializeField] private GameObject roof;
    [SerializeField] private GameObject furniture;
    [SerializeField] private GameObject myCamera;
    [SerializeField] private bool tavern = true;
    [SerializeField] private bool wizzard = false;
    [SerializeField] private bool weaponSmith = false;
    
    void Start()
    {
        roof.SetActive(true);
        furniture.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            roof.SetActive(false);
            if (tavern)
            {
                myCamera.GetComponent<AudioHandler>().musicState = 2;
                myCamera.GetComponent<AudioHandler>().canPlay = true;
            }
            if (weaponSmith)
            {
                myCamera.GetComponent<AudioHandler>().musicState = 4;
                myCamera.GetComponent<AudioHandler>().canPlay = true;
            }
            if (wizzard)
            {
                myCamera.GetComponent<AudioHandler>().musicState = 5;
                myCamera.GetComponent<AudioHandler>().canPlay = true;
            }
            furniture.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            roof.SetActive(true);
            furniture.SetActive(false);
            myCamera.GetComponent<AudioHandler>().musicState = 1;
            myCamera.GetComponent<AudioHandler>().canPlay = true; 
        }
    }

    void Update()
    {
        
    }
}
