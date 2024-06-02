using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpeechBox : MonoBehaviour
{
    //ΔΕΝ ΕΙΝΑΙ ΚΑΛΗ ΠΡΑΚΤΙΚΗ ΑΥΤΗΝ ΠΟΥ ΧΡΗΣΙΜΟΠΟΙΗΣΑ, ΔΕΝ ΕΧΩ ΑΥΤΗΝ ΤΗΝ ΣΤΙΓΜΗ ΤΟΝ ΧΡΟΝΟ ΝΑ
    //ΤΟ ΑΛΛΑΞΩ ΟΠΟΤΕ ΑΝΑΓΚΑΣΤΙΚΑ ΘΑ ΔΟΥΛΕΨΩ ΜΕ ΤΟ SCRIPT ΟΠΩΣ ΕΙΝΑΙ ΕΑΝ ΘΑ ΑΛΛΑΖΩ ΚΑΤΙ ΘΑ 
    //ΗΤΑΝ ΝΑ ΚΑΤΑΡΓΗΣΩ ΤΑ STATIC ΠΕΔΙΑ ΚΑΙ ΘΑ ΤΟ ΕΚΑΝΑ ΧΡΗΣΙΜΟΠΟΙΩΝΤΑΣ ΠΙΟ ΠΡΑΚΤΙΚΕΣ ΜΕΘΟΔΟΥΣ
    //ΟΠΩΣ ΓΙΑ ΠΑΡΑΔΕΙΓΜΑ ΝΑ ΘΕΣΩ ΣΕ ΚΑΘΕ ΚΑΤΑΣΤΗΜΑ ΑΠΛΑ ΤΟ TAVERN BACKGROUND ΚΑΙ ΤΑ GAMEOBJECTS
    //ΣΕ [SERIALISE FIELDS] ΚΑΙ ΜΕΣΑ ΑΠΟ ΑΥΤΑ ΝΑ ΕΚΤΕΛΩ ΤΙΣ ΕΝΕΡΓΕΙΕΣ ΠΟΥ ΠΡΕΠΕΙ.
    [SerializeField] private GameObject messageBox;
    [SerializeField] private Text greetingsQuestion;

    //Πεδια χρησιμα για ερωτησεις προς τον παικτη
    [Header("In case of question fill the followings.")]
    [SerializeField] private int coinsAsPrize = 20;//Τα νομισματα που θα δινονται στην σωστη απαντηση, default ειναι τα 20
    [SerializeField] private bool itemAsPrize = false;
    [SerializeField] private int itemID;
    [SerializeField] private bool withDialog = true; //ean tha uparksei enas mikros dialogos apo prin. PANTA THA EINAI TRUE se auto to version tou project. 
    [Range(1,15)] [SerializeField] private int amountOfQuestions = 1; //orizetai poses erwthseis mporoun na ginoun apo auton ton npc
    [Range(0,4)] [SerializeField] private int questionPoolLevel = 0; //Επιλογή ανάμεσα σε 1 (απλές ερωτήσεις), 2 (Δύσκολες ερωτήσεις θεωρίας), 3 (Γρήγορες ασκήσεις) και 4 (Θέματα θεωριτικά πανελλαδικών).
    [SerializeField] private bool techQuestion = false;
    [SerializeField] private bool ecoQuestion = false;
    [Header("Choose the answer buttons for a question.")]
    [FormerlySerializedAs("answerOne")] [SerializeField] private Button displayAnswerOne;
    [FormerlySerializedAs("answerTwo")] [SerializeField] private Button displayAnswerTwo;
    [FormerlySerializedAs("answerThree")] [SerializeField] private Button displayAnswerThree;
    [FormerlySerializedAs("answerFour")] [SerializeField] private Button displayAnswerFour;

    
    //Πεδια χρησιμα για απλη αλληλεπιδραση με τον παικτη.
    [Header("Choose the action buttons.")]
    [SerializeField] private Button questionOne; //το q1 και q2 αποτελουν κουμπια αλληλεπιδρασης με το npc ενω τα παρακατω κουμπια αποτελουν κουμπια απαντησεων του χρηστη σε μια ερωτηση.
    [SerializeField] private Button questionTwo;
    [Header("Type your messages and answers.")]
    [Tooltip("Type a message that you want to be displayed as a greeting message in the top.")] [SerializeField] private string greetingsMessage;
    [Tooltip("Type a message that you want to be displayed as a first choice.")] [SerializeField] private string choiceOneToDisplay;
    [Tooltip("Type a message that you want to be displayed as a second choice.")] [SerializeField] private string choiceTwoToDisplay;

    [Tooltip(
        "Type here a message will be displayed as answer of npc in case of player chooses the first answer which is not an action.")]
    [SerializeField]
    private string messageOfChoiceOne;
    //Header και tooltip μπορω να δωσω μια καλυτερη περιγραφη με το τι αναγκες εχει αυτο το script και τα συγκεκριμενα πεδια.
    [Header("Define what you want the player open.")]
    [SerializeField] private GameObject shopOrMenu;

    [SerializeField] private bool justDialog; //εαν επιλεγει αυτο τοτε μπορει να μην υπαρχει καποιο καταστημα αλλα θα υπαρξει ενας διαλογος

    private List<Button> questionsToBePassed = new List<Button>();
    private int totalAvailableQuestions;
    
    // private enum Actions//επιλογες για ενα drop down menu μεσω του unity ετσι ωστε κατα τον ελεγχο του action να μην γινεται σφαλμα.
    // {
    //     OpenShop,
    //     Question,
    //     OpenBarShop,
    //     OpenWeaponsmith,
    //     OpenWizardShop,
    // }
    // [SerializeField] private Actions selectedAction;
    

    
    //πεδια που λαμβανουν τιμες κατα το καλεσμα του πινακα που περιεχει τις ερωτησεις (χρησιμα για τις ερωτησεις)
    private string answer1;
    private string answer2;
    private string answer3;
    private string answer4;
    private int correctAnswer;
    private string question;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //εαν εξαντληθουν οι ερωτησεις που μπορουν να γινουν στον χρηστη δεν τον επιτρεπει να δει και να απαντησει αλλες. Το ποσες μπορει να λαβει ο χρηστης
            //δηλωνεται στην μεταβλητη αυτη.
            if (shopOrMenu == null && !justDialog && withDialog)//Εαν επιλεγει απο τον editor το question τοτε γινεται η διαδικασια για την εμφανιση των καταλληλων αντικειμενων για την περιπτωηση της ερωτησης που θελει απαντηση.
            {
                if (amountOfQuestions == 0) { UiMessageHandler.passedMessage = "Έχουν εξαντληθεί οι διαθέσιμες ερωτήσεις από αυτόν τον NPC."; return; }
                questionOne.gameObject.SetActive(true);
                questionTwo.gameObject.SetActive(false);
                displayAnswerOne.gameObject.SetActive(false);
                displayAnswerTwo.gameObject.SetActive(false);
                displayAnswerThree.gameObject.SetActive(false);
                displayAnswerFour.gameObject.SetActive(false);
                if (questionPoolLevel != 0) //ΕΠΙΛΕΓΟΝΤΑΣ QUESTIONPOOLLEVEL ΑΠΟ ΤΟΝ editor γινεται override του questiolevel
                {
                    prepareTheQuestion(questionPoolLevel);
                }
                else
                {  
                    if (SavePlayer.answersLevel >= 0 && SavePlayer.answersLevel < 0.25)
                    {
                        prepareTheQuestion(1);
                    }else if (SavePlayer.answersLevel >= 0.25 && SavePlayer.answersLevel < 0.50)
                    {
                        prepareTheQuestion(2);
                    }else if (SavePlayer.answersLevel >= 0.50 && SavePlayer.answersLevel < 0.75)
                    {
                        prepareTheQuestion(3);
                    }
                    else if (SavePlayer.answersLevel >= 0.75 && SavePlayer.answersLevel <= 1)
                    {
                        prepareTheQuestion(4);
                    }
                }
                
                //ληψη ερωτησης, απαντησεων και σωστς απαντησης απο τα δεδομενα.
                questionOne.GetComponentInChildren<Text>().text = choiceOneToDisplay; //Εμφανιζει το μηνυμα 1
                
                //pernaei tis erwthseis sto handler etsi wste na ta emfanisei meta otan ginei o dialogos
                displayAnswerOne.GetComponentInChildren<Text>().text = answer1;
                questionsToBePassed.Add(displayAnswerOne);
                displayAnswerTwo.GetComponentInChildren<Text>().text = answer2;
                questionsToBePassed.Add(displayAnswerTwo);
                displayAnswerThree.GetComponentInChildren<Text>().text = answer3;
                questionsToBePassed.Add(displayAnswerThree);
                displayAnswerFour.GetComponentInChildren<Text>().text = answer4;
                questionsToBePassed.Add(displayAnswerFour);
                greetingsQuestion.text = greetingsMessage;
                
                //εδω περνιουνται τα δεδομενα στο script dialoghandler που διαχειριζεται τα κουμπια.
                // DialogHandler.correctAnswer = QuestionsDatabase.questionsLevel1[0][correctAnswer];
                DialogHandler.dialogFirstThenQuestions = true;
                DialogHandler.correctAnswerId = correctAnswer;
                DialogHandler.rewardInCoins = coinsAsPrize;
                DialogHandler.passedQuestions = questionsToBePassed;
                DialogHandler.passedGreetingText = greetingsQuestion;
                DialogHandler.answerOneDisplay = questionOne;
                DialogHandler.passedQuestion = (question + " [" + amountOfQuestions + "/" + totalAvailableQuestions + "]");
                DialogHandler.isTechQuestion = techQuestion;
                DialogHandler.isEcoQuestion = ecoQuestion;
                if (itemAsPrize)
                {
                    DialogHandler.itemID = itemID;
                }
                amountOfQuestions -= 1; //μειωνεται το ποσο των ερωτησεων γιατι εχει εμφανιστει μια 
            }
            else
            {
                questionOne.gameObject.SetActive(true);
                questionTwo.gameObject.SetActive(true);
                if (justDialog)
                {
                    questionTwo.gameObject.SetActive(false);
                }
                displayAnswerOne.gameObject.SetActive(false);
                displayAnswerTwo.gameObject.SetActive(false);
                displayAnswerThree.gameObject.SetActive(false);
                displayAnswerFour.gameObject.SetActive(false);
                
                questionOne.GetComponentInChildren<Text>().text = choiceOneToDisplay; //Εμφανιζει το μηνυμα 1
                questionTwo.GetComponentInChildren<Text>().text = choiceTwoToDisplay; //Εμφανιζει το μηνυμα 2

                greetingsQuestion.text = greetingsMessage; //Στελνει το greeting message που εχει επιλεχθει
                DialogHandler.shopToOpen = shopOrMenu; //Στελνει το action που εχει επιλεχθει απο το editor για να εκτελεστει στην περιπτωση αυτη που βρισκεται το script αυτο.
                DialogHandler.alternativeMessage = messageOfChoiceOne; //Στελενει το μηνυμα σε περιπτωση που ο παικτη δεν επιλεξει να κανει καποιο action αλλα να μιλησει με τον npc.
            }
            messageBox.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageBox.SetActive(false);
        }
    }

    public void Start()
    {
        if (shopOrMenu == null)
        {
            totalAvailableQuestions = amountOfQuestions;
        }
    }

    public void prepareTheQuestion(int level)
    { 
        switch (level)
        {
            case 1:
                Debug.Log("1q");
                bool techQuestionHasNotFound = true;
                int randomQuestionOne = Random.Range(0, QuestionsDatabase.questionsLevel1.Count);
                if (techQuestion)
                {
                    while (techQuestionHasNotFound)
                    {
                        if (QuestionsDatabase.questionsLevel1[randomQuestionOne][6] == "T")
                        {
                            techQuestionHasNotFound = false;
                        }
                        else
                        {
                            randomQuestionOne = Random.Range(0, QuestionsDatabase.questionsLevel1.Count);
                        }
                    }
                }
                question = QuestionsDatabase.questionsLevel1[randomQuestionOne][0];
                answer1 = QuestionsDatabase.questionsLevel1[randomQuestionOne][1];
                answer2 = QuestionsDatabase.questionsLevel1[randomQuestionOne][2];
                answer3 = QuestionsDatabase.questionsLevel1[randomQuestionOne][3];
                answer4 = QuestionsDatabase.questionsLevel1[randomQuestionOne][4];
                correctAnswer = int.Parse(QuestionsDatabase.questionsLevel1[randomQuestionOne][5]);
                DialogHandler.correctAnswer = QuestionsDatabase.questionsLevel1[randomQuestionOne][correctAnswer];
                break;
            case 2:
                Debug.Log("2q");
                bool techQuestionHasNotFoundTwo = true;
                int randomQuestionTwo = Random.Range(0, QuestionsDatabase.questionsLevel2.Count);
                if (techQuestion)
                {
                    while (techQuestionHasNotFoundTwo)
                    {
                        if (QuestionsDatabase.questionsLevel2[randomQuestionTwo][6] == "T")
                        {
                            techQuestionHasNotFoundTwo = false;
                        }
                        else
                        {
                            randomQuestionTwo = Random.Range(0, QuestionsDatabase.questionsLevel2.Count);
                        }
                    }
                }
                question = QuestionsDatabase.questionsLevel2[randomQuestionTwo][0];
                answer1 = QuestionsDatabase.questionsLevel2[randomQuestionTwo][1];
                answer2 = QuestionsDatabase.questionsLevel2[randomQuestionTwo][2];
                answer3 = QuestionsDatabase.questionsLevel2[randomQuestionTwo][3];
                answer4 = QuestionsDatabase.questionsLevel2[randomQuestionTwo][4];
                correctAnswer = int.Parse(QuestionsDatabase.questionsLevel2[randomQuestionTwo][5]);
                DialogHandler.correctAnswer = QuestionsDatabase.questionsLevel2[randomQuestionTwo][correctAnswer];
                break;
            case 3:
                Debug.Log("3q");
                bool techQuestionHasNotFoundThree = true;
                int randomQuestionThree = Random.Range(0, QuestionsDatabase.questionsLevel3.Count);
                if (techQuestion)
                {
                    while (techQuestionHasNotFoundThree)
                    {
                        if (QuestionsDatabase.questionsLevel3[randomQuestionThree][6] == "T")
                        {
                            techQuestionHasNotFoundThree = false;
                        }
                        else
                        {
                            randomQuestionThree = Random.Range(0, QuestionsDatabase.questionsLevel3.Count);
                        }
                    }
                }
                question = QuestionsDatabase.questionsLevel3[randomQuestionThree][0];
                answer1 = QuestionsDatabase.questionsLevel3[randomQuestionThree][1];
                answer2 = QuestionsDatabase.questionsLevel3[randomQuestionThree][2];
                answer3 = QuestionsDatabase.questionsLevel3[randomQuestionThree][3];
                answer4 = QuestionsDatabase.questionsLevel3[randomQuestionThree][4];
                correctAnswer = int.Parse(QuestionsDatabase.questionsLevel3[randomQuestionThree][5]);
                DialogHandler.correctAnswer = QuestionsDatabase.questionsLevel3[randomQuestionThree][correctAnswer];
                break;
            case 4:
                Debug.Log("4q");
                bool techQuestionHasNotFoundFour = true;
                int randomQuestionFour = Random.Range(0, QuestionsDatabase.questionsLevel4Panel.Count);
                if (techQuestion)
                {
                    while (techQuestionHasNotFoundFour)
                    {
                        if (QuestionsDatabase.questionsLevel4Panel[randomQuestionFour][6] == "T")
                        {
                            techQuestionHasNotFoundFour = false;
                        }
                        else
                        {
                            randomQuestionFour = Random.Range(0, QuestionsDatabase.questionsLevel4Panel.Count);
                        }
                    }
                }
                question = QuestionsDatabase.questionsLevel4Panel[randomQuestionFour][0];
                answer1 = QuestionsDatabase.questionsLevel4Panel[randomQuestionFour][1];
                answer2 = QuestionsDatabase.questionsLevel4Panel[randomQuestionFour][2];
                answer3 = QuestionsDatabase.questionsLevel4Panel[randomQuestionFour][3];
                answer4 = QuestionsDatabase.questionsLevel4Panel[randomQuestionFour][4];
                correctAnswer = int.Parse(QuestionsDatabase.questionsLevel4Panel[randomQuestionFour][5]);
                DialogHandler.correctAnswer = QuestionsDatabase.questionsLevel4Panel[randomQuestionFour][correctAnswer];
                break;
        }
    }
}
