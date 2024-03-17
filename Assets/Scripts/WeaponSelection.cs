using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    [SerializeField] private int weaponNumber;//einai script pou topotheteitai se kathe weapon entos tou ui
    //opote kai ean ginei click panw sto eikonidio tou weapon autou ekteleitai h parakatw methodos (chooseWeapon).
    [SerializeField] private AudioSource soundPlayer;
    [SerializeField] private AudioClip selection;

    public void chooseWeapon() 
    {
        SavePlayer.weaponChoice = weaponNumber;
        SavePlayer.weaponChange = true;
        SavePlayer.carringWeapon = true;
        soundPlayer.clip = selection;
        soundPlayer.Play();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
