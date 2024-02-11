using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DialogHandler: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Range(1,5)] [SerializeField] private  int buttonId = 5; //Εδω δινεται η επιλογη να μπει το id του καθε button ετσι ωστε να γνωριζει το 
    //script ποιο button εχει πατηθει. Μπορει να παρει τιμες 1,2,3,4 που αντιπροσωπευουν τα κουμπια των ερωτησεων και το 5 που ειναι τα 
    //απλα κουμπια αλληλεπιδρασης με το npc.
    [SerializeField] private Text buttonText;
    [SerializeField] private Text greetingsAndQuestion;
    [SerializeField] private Color32 messageOff;
    [SerializeField] private Color32 messageOn;

    [SerializeField] private List<Button> allButtons; //εδω δηλωνονται ολα τα γειτονικα κουμπια που υπαρχουν.

    public static int correctAnswerId; //εδω θα στελνω απο το speechbox το id της σωστης απαντησης οταν προκειται για ερωτηση και για επικοινωνια.
    public static int rewardInCoins; //εδω θα στελνω παλι απο το speechbox το ποσα coins θα πρεπει να λαβει ο παικτης απο την σωστη του απαντηση.
    public static string correctAnswer; //εδω θα ερχεται η σωστη απαντηση και θα δινεται στον παικτη οταν δεν μπορει να απαντησει σωστα.

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = messageOn;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = messageOff;
    }

    public void checkAnswer()
    {
        if (buttonId == correctAnswerId) // Ελεγχει εαν το κουμπι που πατηθηκε ειναι το 
        //σωστο κουμπι και εαν ειναι τοτε δινει στον παικτη την ανταμοιβη του που οριζεται απο το σκριπτ speechbox.
        {
            greetingsAndQuestion.text = ("Μπράβο σου απάντησες σωστά και ως ανταμοιβή έλαβες " + rewardInCoins + " νομίσματα.");
            InventoryItems.totalCoins += rewardInCoins;
            foreach (var button in allButtons)//μολις απαντησει σωστα κλεινω ολα τα μηνυματα και κουμπια.
            {
                button.gameObject.SetActive(false);
            }
            
        }else if (buttonId != correctAnswerId)
        {
            greetingsAndQuestion.text = ("Η σωστή απάντηση είναι: " + correctAnswer);
            gameObject.SetActive(false);
            foreach (var button in allButtons)
            {
                button.gameObject.SetActive(false);
            }
        }
        Time.timeScale = 1;
    }
    
    void Update()
    {
        
    }
}
