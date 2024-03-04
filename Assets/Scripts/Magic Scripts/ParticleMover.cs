using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMover : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject obj;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifeTime = 1.4f;
    [SerializeField] private bool enemySeeker = false;
    [SerializeField] private bool nonMoving = false;
    private GameObject targetSave;
    
    void Start()
    {
        targetSave = SavePlayer.theTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.LerpUnclamped(transform.position, target.transform.position, speed * Time.deltaTime);
        }

        if (enemySeeker)
        {
            if (targetSave != null)
            {
                transform.position = Vector3.LerpUnclamped(transform.position, targetSave.transform.position,
                    speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }

        if (nonMoving)
        {
            if (targetSave != null)
            {
                transform.position = targetSave.transform.position;
            }
            else
            {
                Destroy(obj);
            }
        }
        Destroy(obj, lifeTime);
    }
}
