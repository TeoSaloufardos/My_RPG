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
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private GameObject[] armourTorso;
    [SerializeField] private GameObject[] armourLegs; //ta set pou exei o kathe xarakthras sto foler tou 7,8,9. Apo to ligotero kalo pros to kalutero.
    [SerializeField] private string[] attacks; //pinakas me ta onoma twn trigger gia na ginetai trigger to katallhlo animation.
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip[] weaponSounds;
    private GameObject trailObject;
    private WaitForSeconds trailOffTime = new WaitForSeconds(0.1f);
    public float[] staminaCost;
    
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); 
        characterAnimator = GetComponent<Animator>();
        SavePlayer.spawnPoint = spawnPoint;
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
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
                    transform.LookAt(SavePlayer.theTarget.transform);
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
            if (SavePlayer.manaAmount <= 0.1)// elegxei to mana gia na ektelesei thn energopoihsh tou inv.
            {
                if (SavePlayer.invisible == false)
                {
                    for (int i = 0; i < playerObjs.Length; i++)
                    {
                        playerObjs[i].SetActive(true); //kanei ton paikth ksana orato
                        SavePlayer.changeArmour = true; 
                    }
                }
            }

            if (SavePlayer.changeArmour)
            {
                for (int i = 0; i < armourTorso.Length; i++)
                {
                    armourTorso[i].SetActive(false);
                }
                armourTorso[SavePlayer.armour].SetActive(true);
                for (int i = 0; i < armourLegs.Length; i++)
                {
                    armourLegs[i].SetActive(false);
                }
                armourLegs[SavePlayer.armour].SetActive(true);
                SavePlayer.changeArmour = false;
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
            if (SavePlayer.carringWeapon == false)
            {
                characterAnimator.SetBool("running", true);
                characterAnimator.SetBool("carryWeapon", false);
            }
            if (SavePlayer.carringWeapon)
            {
                characterAnimator.SetBool("running", true);
                characterAnimator.SetBool("carryWeapon", true);
            }
        }else if (velocity == 0)
        {
            characterAnimator.SetBool("running", false);    
        }

        if (SavePlayer.weaponChange)
        {
            SavePlayer.weaponChange = false;
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].SetActive(false);
            }
            weapons[SavePlayer.weaponChoice].SetActive(true);
            StartCoroutine(TurnOffTrail());
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (SavePlayer.carringWeapon && SavePlayer.staminaAmount > 0.2)
            {
                characterAnimator.SetTrigger(attacks[SavePlayer.weaponChoice]);
                audioPlayer.clip = weaponSounds[SavePlayer.weaponChoice];
                audioPlayer.Play();
                SavePlayer.staminaAmount -= staminaCost[SavePlayer.weaponChoice];
            }
        }
        
    }

    public void trailOn()
    {
        trailObject.GetComponent<Renderer>().enabled = true;
        
    }
    
    public void trailOff()
    {
        trailObject.GetComponent<Renderer>().enabled = false;
        
    }

    IEnumerator TurnOffTrail()
    {
        yield return trailOffTime;
        trailObject = GameObject.Find("Trail");
        trailObject.GetComponent<Renderer>().enabled = false;
    }
    IEnumerator MoveTo()
    {
        yield return approachEnemy;
        navMeshAgent.isStopped = true;
    }
}
