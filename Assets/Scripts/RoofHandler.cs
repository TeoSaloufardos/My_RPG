using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofHandler : MonoBehaviour
{
    [SerializeField] private GameObject roof;
    [SerializeField] private GameObject furniture;
    
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
            furniture.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            roof.SetActive(true);
            furniture.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
