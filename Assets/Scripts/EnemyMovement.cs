using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject thisEnemy;
    private bool outLineOn = false;
    
    //fields pou einai xrhsima gia to movement tou enemy
    private NavMeshAgent nav;
    private Animator anim;
    private AnimatorStateInfo enemyInfo;
    private float x;
    private float z;
    private float velocitySpeed;
    [SerializeField] private GameObject player;
    private float distance;
    private bool isAttacking = false;
    [SerializeField] private float attackRange = 2.0f;
    [SerializeField] private float runRange = 12.0f;
    public int enemyHp = 100;
    private int currectHp;
    private bool isAlive = true; 
    
    void Start()
    {
        thisEnemy.GetComponent<Outline>().enabled = false;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        nav.avoidancePriority = Random.Range(5, 60);//dhmioyrgei random priority gia na 
        //mhn uparxei thema otan mazeuontai polla enemies mazi.
        currectHp = enemyHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
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

            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }

            x = nav.velocity.x;
            z = nav.velocity.z;
            velocitySpeed = x + z;
            if (velocitySpeed == 0)
            {
                anim.SetBool("running", false);
            }
            else
            {
                anim.SetBool("running", true);
                isAttacking = false;
            }

            enemyInfo = anim.GetCurrentAnimatorStateInfo(0);
            distance = Vector3.Distance(transform.position,
                player.transform.position); //upologizei thn apostash metaksu twn duo objects kai epistrefei float
            if (distance < attackRange || distance > runRange)
            {
                nav.isStopped = true;
                if (distance < attackRange && enemyInfo.IsTag("nonAttack"))
                {
                    if (isAttacking == false)
                    {
                        isAttacking = true;
                        anim.SetTrigger("attack");
                        transform.LookAt(player.transform);
                    }
                }

                if (distance < attackRange && enemyInfo.IsTag("attack"))
                {
                    if (isAttacking)
                    {
                        isAttacking = false;
                    }
                }
            }
            else
            {
                nav.isStopped = false;
                nav.destination = player.transform.position;
            }

            if (currectHp > enemyHp)
            {
                anim.SetTrigger("hit");
                currectHp = enemyHp;
            }
        }

        if (enemyHp <= 1 && isAlive)
        {
            isAlive = false;
            nav.isStopped = true;
            anim.SetTrigger("death");
            thisEnemy.GetComponent<Outline>().enabled = false;
            outLineOn = false;
            nav.avoidancePriority = 0; //na mhn mporei na skountiksei to death enemy o player.
        }
    }
}
