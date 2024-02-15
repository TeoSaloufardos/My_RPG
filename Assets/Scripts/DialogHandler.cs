using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DialogHandler: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Range(1,6)] [SerializeField] private  int buttonId = 5; //Εδω δινεται η επιλογη να μπει το id του καθε button ετσι ωστε να γνωριζει το 
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
    public static string alternativeMessage;
    public static GameObject shopToOpen;
    //το προβλημα με αυτην την λογικη ειναι πως σε περιπτωση επεκτασης του παιχνιδιου δεν δινεται η δυνατοτητα απλης προσθηκης νεου action το οποιο θα
    //ενημερωσει ταυτοχρονα και το switch statement αλλα χρειαζεται παρεμβαση καποιου που μπορει να γραψει κωδικα.

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

    public void doTheAction()
    {
        //Ειναι ενας ελεγχος που γινεται σε καθε περιπτωση action και ουσιαστικα εαν ο παικτης επιλεξει για παραδειγμα αντι στην αρχη να πατησει το open....
        //για να ανοιξει το καταστημα, πατησει το να μιλησει με τον npc τοτε σε αυτην την περιπτωση θα εμφανιστει το μηνυμα που εχει προκαθωριστει. Εδω ο ελεγχος ελεγχει εαν
        //πατηθει το κουμπι με το id 6 που αντιστοιχει στο κουμπι αυτο της επικοινωνιας.
        if (buttonId == 6)
        {
            greetingsAndQuestion.text = alternativeMessage;
            return;
        }
        shopToOpen.SetActive(true);
    }
    
    
    void Update()
    {
        
    }
}
