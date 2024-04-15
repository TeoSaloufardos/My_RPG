using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class labHasFound : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StageOneMountain.labHasFound = true;
            Destroy(this);
        }
    }
}
