using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTarget : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private bool rotator = false;
    [SerializeField] private bool particleTarget = true;
    [SerializeField] private int damageAmount = 30;
    [SerializeField] private GameObject lastObj;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rotator)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0); //delta time xrhsimo gia
            //na mhn yparxei thema me grhgorous h oxi upologistes. 
        }

        if (particleTarget)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy") && other.transform.gameObject != lastObj)//elegxei ektos tou oti ean einai enemy ean einai kai to idio object me prin.
        {
            other.transform.gameObject.GetComponent<EnemyMovement>().enemyHp -= damageAmount;
            lastObj = other.transform.gameObject;
        }
    }
}
