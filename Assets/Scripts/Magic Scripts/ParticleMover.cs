using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMover : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject obj;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifeTime = 1.4f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.LerpUnclamped(transform.position, target.transform.position, speed * Time.deltaTime);
        } 
        Destroy(obj, lifeTime);
    }
}
