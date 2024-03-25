using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(findPlayer());
    }

    // Update is called once per frame
    void LateUpdate()// kanei update molis oloklhrothoun ola ta alla updates pou trexoun.
    {
        //enhmerwnetai h topothesia ths cameras sumfwna me thn topothesia tou paikth.
        if (player != null)
        {
            Vector3 pos = player.transform.position;
            pos.y = transform.position.y;
            transform.position = pos;
        }
    }

    IEnumerator findPlayer()
    {
        yield return new WaitForSeconds(1);
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
