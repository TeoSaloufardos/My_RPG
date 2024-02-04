using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private List<GameObject> characters;
    [SerializeField] private Transform spawnPosistion;
    void Start()
    {
        Instantiate(characters[SavePlayer.characterPositionData], spawnPosistion.position, spawnPosistion.rotation); //Το Instantiate(OBJECT, POSITION) είναι μια μεθοδος που μπορει να κανει spawn
        //μεσα στον χαρτη αντικειμενα συμφωνα με τις παραμετρους που του δινουμε, παντα χρειαζεται το object και το position του.
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
