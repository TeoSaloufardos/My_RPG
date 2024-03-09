using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] private bool followPlayer = false;
    private GameObject playerObject;
    [SerializeField] private float manaCost = 0.05f;
    [SerializeField] private bool invisibility = false;
    
    void Start()
    {
        targetSave = SavePlayer.theTarget;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        if (invisibility)
        {
            SavePlayer.invisible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position =
                Vector3.LerpUnclamped(transform.position, target.transform.position, speed * Time.deltaTime);
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

        if (followPlayer)
        {
            transform.position = playerObject.transform.position;
            lifeTime = 100;
            if (SavePlayer.manaAmount <= 0.03)//katastrofh tou antikeimenou molis teleiwsei to mana
            {
                Destroy(obj);
            }
        }

        SavePlayer.manaAmount -= manaCost * Time.deltaTime;//afairei to mana oso xrhsimopoieitai
        Destroy(obj, lifeTime);
    }
}
