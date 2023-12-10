using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject cursorObject; //Εδω θα λαμβανω το cursor που θα ακολουθει το ποντικι.
    
    void Start()
    {
        Cursor.visible = false; //Οριζω το default cursor να μην εμφανιζεται.
    }

    // Update is called once per frame
    void Update()
    {
        cursorObject.transform.position = Input.mousePosition; //Εδω οριζω οτι το object αυτο θα ακολουθει την τοποθεσια του ποντικιου.
    }
}
