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
            furniture.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            roof.SetActive(true);
            furniture.SetActive(false);
            if (tavern)
            {
                myCamera.GetComponent<AudioHandler>().musicState = 1;
                myCamera.GetComponent<AudioHandler>().canPlay = true; 
            }
        }
    }

    void Update()
    {
        
    }
}
