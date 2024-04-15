using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperWiseHasFound : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StageOneMountain.superWiseHasFound = true;
            Destroy(this);
        }
    }
}
