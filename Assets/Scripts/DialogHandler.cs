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
    [SerializeField] private List<GameObject> weaponsmithPriceTexts;
    [SerializeField] private List<GameObject> weaponsmithPrices;
    private List<int> prices = new List<int>();

    public static int correctAnswerId; //εδω θα στελνω απο το speechbox το id της σωστης απαντησης οταν προκειται για ερωτηση και για επικοινωνια.
    public static int rewardInCoins; //εδω θα στελνω παλι απο το speechbox το ποσα coins θα πρεπει να λαβει ο παικτης απο την σωστη του απαντηση.
    public static string correctAnswer; //εδω θα ερχεται η σωστη απαντηση και θα δινεται στον παικτη οταν δεν μπορει να απαντησει σωστα.
    public static string alternativeMessage;
    public static int overrideLevel = -1;
    public static int itemID = -1;
    public static GameObject shopToOpen;
    //το προβλημα με αυτην την λογικη ειναι πως σε περιπτωση επεκτασης του παιχνιδιου δεν δινεται η δυνατοτητα απλης προσθηκης νεου action το οποιο θα
    //ενημερωσει ταυτοχρονα και το switch statement αλλα χρειαζεται παρεμβαση καποιου που μπορει να γραψει κωδικα.

    public static List<Button> passedQuestions; // einai oi apanthseis pou tha dinontai na epileksei o xrhsths
    public static Text passedGreetingText; // pernaei to Text object gia na allaxtei h erwthsh meta ton dialogo.
    public static string passedQuestion; //to passedquestion einai to mhnuma pou kanei replace to greeting message.
    public static Button answerOneDisplay; // ston dialogo tha emfanisei sto paikth ena koumpi molis paththei tha prepei na 
    // eksafanistei to koumpi gia na efmanistoun oi apanthseis "passedQuestions". Auto to field ginei prosbash sto koumpi auto.
    public static bool dialogFirstThenQuestions = false;
    public static bool isTechQuestion = false;
    public static bool isEcoQuestion = false;

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
            if (isTechQuestion)
            {
                // foreach (var priceText in weaponsmithPriceTexts)
                // {
                //     string newPriceString = priceText.gameObject.GetComponentInChildren<Text>().ToString();
                //     print("number as string: " + newPriceString);
                //     int newPrice = int.Parse(newPriceString);
                //     print("Price as int: " + newPrice);
                //     priceText.gameObject.GetComponentInChildren<Text>().text = (newPrice - 15).ToString();
                // }

                foreach (var price in weaponsmithPrices)
                {
                    price.gameObject.GetComponentInChildren<BuyWeapon>().cost =
                        price.gameObject.GetComponentInChildren<BuyWeapon>().cost - 15;
                    print(price.gameObject.GetComponentInChildren<BuyWeapon>().cost);
                    prices.Add(price.gameObject.GetComponentInChildren<BuyWeapon>().cost);
                }

                for (int i = 0; i < prices.Count; i++)
                {
                    weaponsmithPriceTexts[i].gameObject.GetComponentInChildren<Text>().text = prices[i].ToString();
                    // string newPriceString = priceText.gameObject.GetComponentInChildren<Text>().ToString();
                    // print("number as string: " + newPriceString);
                    // int newPrice = int.Parse(newPriceString);
                    // print("Price as int: " + newPrice);
                    // priceText.gameObject.GetComponentInChildren<Text>().text = (newPrice - 15).ToString();
                }
                prices.Clear();
            }
            if (overrideLevel != -1)
            {
                rewardInCoins = rewardInCoins * (overrideLevel / 10);
            }
            else
            {
                rewardInCoins = (int) (rewardInCoins * (SavePlayer.answersLevel + 1f));
            }
            string prize = "Μπράβο σου απάντησες σωστά και ως ανταμοιβή έλαβες " + rewardInCoins + " νομίσματα.";
            if (itemID > 0)
            {
                if (InventoryItems.hasFreeSpace == false)
                {
                    prize += " Δυστυχώς όμως δεν είχες αρκετό χώρο στο inventory σου για να λάβεις και το αντικείμενο που σου έκανα δώρο.";
                }
                else
                {
                    addItemToInventory(itemID);
                    itemID = -1;
                    prize += " Επίσης κέρδισες και ένα αντικείμενο στο inventory σου.";
                }
            }
            greetingsAndQuestion.text = (prize);
            SavePlayer.correctAnswers += 1;
            SavePlayer.answersLevel += 0.02f;
            InventoryItems.totalCoins += rewardInCoins;
            Debug.Log("Questions level: " + SavePlayer.answersLevel);
            if (QuestionsInstructions.displayQuestionInstructions == false)
            {
                QuestionsInstructions.displayQuestionInstructions = true;
            }
            Debug.Log("Correct: " + SavePlayer.correctAnswers);
            foreach (var button in allButtons)//μολις απαντησει σωστα κλεινω ολα τα μηνυματα και κουμπια.
            {
                button.gameObject.SetActive(false);
            }
            Time.timeScale = 1;
            
        }else if (buttonId != correctAnswerId)
        {
            greetingsAndQuestion.text = ("Η σωστή απάντηση είναι: " + correctAnswer);
            SavePlayer.wrongAnswers++;
            SavePlayer.answersLevel -= 0.02f;
            gameObject.SetActive(false);
            if (QuestionsInstructions.displayQuestionInstructions == false)
            {
                QuestionsInstructions.displayQuestionInstructions = true;
            }
            foreach (var button in allButtons)
            {
                button.gameObject.SetActive(false);
            }
            Time.timeScale = 1;
        }
    }

    public void doTheAction()
    {
        //Ειναι ενας ελεγχος που γινεται σε καθε περιπτωση action και ουσιαστικα εαν ο παικτης επιλεξει για παραδειγμα αντι στην αρχη να πατησει το open....
        //για να ανοιξει το καταστημα, πατησει το να μιλησει με τον npc τοτε σε αυτην την περιπτωση θα εμφανιστει το μηνυμα που εχει προκαθωριστει. Εδω ο ελεγχος ελεγχει εαν
        //πατηθει το κουμπι με το id 6 που αντιστοιχει στο κουμπι αυτο της επικοινωνιας.
        if (!dialogFirstThenQuestions) //elegxw ean einai question kai proupothetei oti tha uparksei dialogos pio prin.
        {
            if (buttonId == 6)
            {
                greetingsAndQuestion.text = alternativeMessage;
                return;
            }
            shopToOpen.SetActive(true);
        }
        else
        {
            if (buttonId == 6)
            {
                Time.timeScale = 0; //γινεται pause του χρονου μεχρι να απαντησει ο παικτης
                foreach (var question in passedQuestions)
                {
                    question.gameObject.SetActive(true);
                }
                answerOneDisplay.gameObject.SetActive(false);
                passedGreetingText.text = passedQuestion;
                dialogFirstThenQuestions = false;
            }
        }
        
    }
    
    public void addItemToInventory(int item)
    {
        if (InventoryItems.ItemsQuantities[item] == 0)//Ιδια διαδικασια και με το itemPickUp
        {
            InventoryItems.newIconID = item; 
            InventoryItems.iconUpdate = true;
        }
        InventoryItems.ItemsQuantities[item] += 1;
    }
    
    
    void Update()
    {
        
    }
}
