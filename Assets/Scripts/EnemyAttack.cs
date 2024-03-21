using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack: MonoBehaviour
{
    public float damageAmount = 0.1f;
    private WaitForSeconds delayTime = new WaitForSeconds(1);
    private bool canAttack = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (canAttack && !SavePlayer.invulnarable)
            {
                canAttack = false;
                SavePlayer.playerHleath -= damageAmount - SavePlayer.armourValue;
                StartCoroutine(ResetDamage());
            }
        }
    }

    IEnumerator ResetDamage()
    {
        yield return delayTime;
        canAttack = true;
    }

    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}