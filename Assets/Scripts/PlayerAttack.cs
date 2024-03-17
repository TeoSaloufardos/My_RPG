using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject objtodestroy;
    [SerializeField] private int damageAmount;
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
    }

    // IEnumerator WaitForDestroy()
    // {
    //     yield return new WaitForSeconds(3);
    //     Destroy(objtodestroy);
    // }
}
