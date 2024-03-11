using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    [SerializeField] private int weaponNumber;//einai script pou topotheteitai se kathe weapon entos tou ui
    //opote kai ean ginei click panw sto eikonidio tou weapon autou ekteleitai h parakatw methodos (chooseWeapon).

    public void chooseWeapon()
    {
        SavePlayer.weaponChoice = weaponNumber;
        SavePlayer.weaponChange = true;
        SavePlayer.carringWeapon = true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
