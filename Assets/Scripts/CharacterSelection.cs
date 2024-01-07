using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{

    [SerializeField] private List<GameObject> characters = new List<GameObject>(); //Πινακας που θα αποθηκευονται οι διαθεσιμοι χαρακτηρες
    private int characterPosistionOnList = 0; //index για τον πινακα με αρχικοποιηση στο 0
    [SerializeField] private Text inputPlayerName;
    void Start()
    {
        foreach (var character in characters)//απενεργοποιω ολοα τα characters πριν κανει οποιαδηποτε αλλη ενεργεια, θα μπορουσα να τα ειχα απενεργοποιησει εγω απο πριν αλλα επιλεγω να το κανει script.
        {
            character.SetActive(false);
        }
        
        characters[characterPosistionOnList].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void nextCharacter(){
        if (characterPosistionOnList < characters.Count - 1)
        {
            characters[characterPosistionOnList].SetActive(false); //απενεργοποιει τον τωρινο χαρακτηρα για να μην φαινεται
            characterPosistionOnList++; //παει στον επομενο χαρακτηρα με αυξηση του index
            characters[characterPosistionOnList].SetActive(true); //ενεργοποιει τον επομενο χαρακτηρα
        }
    }

    public void previousCharacter()
    {
        if (characterPosistionOnList > 0)
        {
         characters[characterPosistionOnList].SetActive(false);
         characterPosistionOnList--;
         characters[characterPosistionOnList].SetActive(true);
        }
    }

    public void savePlayerNameAndCharacter()
    {
        SavePlayer.playerName = inputPlayerName.text;  //δεν ειναι σωστο το inputPlayerName.ToString(); που είχα δοκιμάσει στην αρχή
        SavePlayer.characterPositionData = characterPosistionOnList;
        SceneManager.LoadScene(1); //βαζω κατευθειαν το 1 χωρις να λαμβανω ποιο ειναι το current scene κτλ γιατι παντα απο το selection θα πηγαινει στο terrain.
    }
}
