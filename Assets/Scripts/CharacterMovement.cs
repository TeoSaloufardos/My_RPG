using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Ray ray;
    private RaycastHit mouseHit;
    
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); //Παιρνει το NavMeshAgent Component του Charecter
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) //Εαν το δεξι click πατηθει τοτε θα λαβει την τοποθεσια του Click συμφωνα με την εικονα της καμερας
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);//λαμβανει το position της καμερας
            if (Physics.Raycast(ray, out mouseHit))
            {
                navMeshAgent.destination = mouseHit.point;//Το παιρναει στο Destination του Character με το NavMeshAgent.
            }
        }
    }
}
