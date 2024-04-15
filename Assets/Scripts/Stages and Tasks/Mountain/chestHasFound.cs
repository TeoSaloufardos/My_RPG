using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestHasFound : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StageOneMountain.chestHasFound = true;
            Destroy(this);
        }
    }
}
