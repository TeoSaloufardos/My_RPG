using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Ray ray;
    private RaycastHit mouseHit;
    
    private Animator characterAnimator;
    private float velocity;
    private float xAxisVelocity;
    private float zAxisVelocity;
    [SerializeField] private LayerMask moveArea;

    public GameObject spawnPoint;
    private WaitForSeconds approachEnemy = new WaitForSeconds(0.3f);

    [SerializeField] private GameObject[] playerObjs; // krataei ta kommati tou xarakthra head, legs etc.
    
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); 
        characterAnimator = GetComponent<Animator>();
        SavePlayer.spawnPoint = spawnPoint;
    }

    // Update is called once per frame
    void Update()
    {
        /*Για παραδειγμα το Ray ειναι σαν εναν φακο που στοχευει σε ενα σκωτεινο μερος, η πηγη ειναι ο φακος, η κατευθυνση που καταληγει
         η ακτινα ειναι η περιοχη που μας ενδιαφερει, ετσι και εδω η καμερα ειναι η πηγη και το ποντικη δειχνει την 
         κατευθυνση.*/
        if (Input.GetMouseButtonDown(1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);//λαμβανει το position που στοχευει το ποντικι συμφωνα με την οπτικη της main καμερας
            if (Physics.Raycast(ray, out mouseHit,300, moveArea))
            {
                if (mouseHit.transform.gameObject.CompareTag("enemy"))
                {
                    navMeshAgent.isStopped = false;
                    SavePlayer.theTarget = mouseHit.transform.gameObject;
                    navMeshAgent.destination = mouseHit.point;//Το παιρναει στο Destination του Character με το NavMeshAgent.
                    StartCoroutine(MoveTo());
                }
                else
                {
                    SavePlayer.theTarget = null;
                    navMeshAgent.destination = mouseHit.point;//Το παιρναει στο Destination του Character με το NavMeshAgent.
                    navMeshAgent.isStopped = false;
                }
            }

            if (playerObjs[0].activeSelf)// elegxei ean einai anoixto to prwto object px legs.
            {
                if (SavePlayer.invisible)
                {
                    for (int i = 0; i < playerObjs.Length; i++)
                    {
                        playerObjs[i].SetActive(false); //kanei ton paikth aorato otan exei to invsisibility
                    }
                }
            }
            if (playerObjs[0].activeSelf == false)// elegxei ean einai anoixto to prwto object px legs.
            {
                if (SavePlayer.invisible == false)
                {
                    for (int i = 0; i < playerObjs.Length; i++)
                    {
                        playerObjs[i].SetActive(true); //kanei ton paikth ksana orato
                    }
                }
            }
        }
        

        /*Αποθηκευει στις μεταβλητες x-zAxisVelocity το αριθμο που λαμβανει σαν x-z velocity το navigation του χαρακτηρα,
         εαν αυτα δυο προστεθουν μεταξυ τους και το συνολικο τους velocity ειναι 0 τοτε το running μπαινει σαν false που 
         σημαινει οτι δεν θα γινει το animation του running και αντιστροφα εαν δεν ειναι 0.*/
        xAxisVelocity = navMeshAgent.velocity.x;
        zAxisVelocity = navMeshAgent.velocity.y;
        velocity = zAxisVelocity + xAxisVelocity;
        
        if(velocity != 0)
        {
            characterAnimator.SetBool("running", true);
        }else if (velocity == 0)
        {
            characterAnimator.SetBool("running", false);    
        }
    }

    IEnumerator MoveTo()
    {
        yield return approachEnemy;
        navMeshAgent.isStopped = true;
    }
}
