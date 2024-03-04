using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject thisEnemy;
    private bool outLineOn = false;
    void Start()
    {
        thisEnemy.GetComponent<Outline>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!outLineOn)
        {
            outLineOn = true;
            if (SavePlayer.theTarget == thisEnemy)
            {
                thisEnemy.GetComponent<Outline>().enabled = true;
            }
        }
        if (outLineOn)
        {
            outLineOn = true;
            if (SavePlayer.theTarget != thisEnemy)
            {
                thisEnemy.GetComponent<Outline>().enabled = false;
                outLineOn = false;
            }
        }
    }
}
