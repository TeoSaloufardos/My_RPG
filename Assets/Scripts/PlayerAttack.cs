using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject objtodestroy;
    [SerializeField] private int damageAmount;
    private bool canDamage = true;
    private WaitForSeconds damagePause = new WaitForSeconds(0.5f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crate"))
        {
            Debug.Log("OK");
            other.transform.gameObject.GetComponentInParent<ChestHandler>().particles();
            // objtodestroy = other.transform.parent.gameObject;
            // Destroy(other.transform.gameObject);
            // StartCoroutine(WaitForDestroy());
        }

        if (other.CompareTag("enemy") && canDamage )
        {
            canDamage = false;
            other.transform.gameObject.GetComponent<EnemyMovement>().enemyHp -= damageAmount;
            StartCoroutine(ResetDamage());
        }
    }

    // IEnumerator WaitForDestroy()
    // {
    //     yield return new WaitForSeconds(3);
    //     Destroy(objtodestroy);
    // }
    IEnumerator ResetDamage()
    {
        yield return damagePause;
        canDamage = true;
    }
}
