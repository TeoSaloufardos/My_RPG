using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SpeechBox : MonoBehaviour
{
    [SerializeField] private GameObject messageBox;
    [SerializeField] private Text greetingsQuestion;

    [SerializeField] private int coinsAsPrize = 10;//Τα νομισματα που θα δινονται στην σωστη απαντηση, default ειναι τα 10
    [SerializeField] private Button questionOne; //το q1 και q2 αποτελουν κουμπια αλληλεπιδρασης με το npc ενω τα παρακατω κουμπια αποτελουν κουμπια απαντησεων του χρηστη σε μια ερωτηση.
    [SerializeField] private Button questionTwo;
    [Range(1,3)] [SerializeField] private int amountOfQuestions = 1; //orizetai poses erwthseis mporoun na ginoun apo auton ton npc
    [FormerlySerializedAs("answerOne")] [SerializeField] private Button displayAnswerOne;
    [FormerlySerializedAs("answerTwo")] [SerializeField] private Button displayAnswerTwo;
    [FormerlySerializedAs("answerThree")] [SerializeField] private Button displayAnswerThree;
    [FormerlySerializedAs("answerFour")] [SerializeField] private Button displayAnswerFour;

    [SerializeField] private Boolean isQuestion; //δηλωνεται στο unity εαν προκειται για ερωτηση που θελει απαντηση απο χρηστη η απλη αλληλεπιδραση οπως πχ ανοιγμα ενος καταστηματος
    [Range(1,4)] [SerializeField] private int questionPoolLevel; //Επιλογή ανάμεσα σε 1 (απλές ερωτήσεις), 2 (Δύσκολες ερωτήσεις θεωρίας), 3 (Γρήγορες ασκήσεις) και 4 (Θέματα θεωριτικά πανελλαδικών).
    
    //πεδια που λαμβανουν τιμες κατα το καλεσμα του πινακα που περιεχει τις ερωτησεις
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
            if (amountOfQuestions == 0) 
            {
                UiMessageHandler.passedMessage = "Έχουν εξαντληθεί οι διαθέσιμες ερωτήσεις από αυτόν τον NPC.";
                return;
            }
            if (isQuestion)//η διαδικασια για την εμφανιση των καταλληλων αντικειμενων για την περιπτωηση της ερωτησης που θελει απαντηση.
            {
                questionOne.gameObject.SetActive(false);
                questionTwo.gameObject.SetActive(false);
                displayAnswerOne.gameObject.SetActive(true);
                displayAnswerTwo.gameObject.SetActive(true);
                displayAnswerThree.gameObject.SetActive(true);
                displayAnswerFour.gameObject.SetActive(true);

                question = QuestionsDatabase.questionsLevel1[0][0];
                answer1 = QuestionsDatabase.questionsLevel1[0][1];
                answer2 = QuestionsDatabase.questionsLevel1[0][2];
                answer3 = QuestionsDatabase.questionsLevel1[0][3];
                answer4 = QuestionsDatabase.questionsLevel1[0][4];
                correctAnswer = int.Parse(QuestionsDatabase.questionsLevel1[0][5]);
                
                //ληψη ερωτησης, απαντησεων και σωστς απαντησης απο τα δεδομενα.
                questionOne.GetComponentInChildren<Text>().text = answer1;
                displayAnswerOne.GetComponentInChildren<Text>().text = answer1;
                displayAnswerTwo.GetComponentInChildren<Text>().text = answer2;
                displayAnswerThree.GetComponentInChildren<Text>().text = answer3;
                displayAnswerFour.GetComponentInChildren<Text>().text = answer4;
                greetingsQuestion.text = (question + " [" + amountOfQuestions + "]");
                
                //εδω περνιουνται τα δεδομενα στο script dialoghandler που διαχειριζεται τα κουμπια.
                DialogHandler.correctAnswer = QuestionsDatabase.questionsLevel1[0][correctAnswer];
                DialogHandler.correctAnswerId = correctAnswer;
                DialogHandler.rewardInCoins = coinsAsPrize;
                amountOfQuestions -= 1; //μειωνεται το ποσο των ερωτησεων γιατι εχει εμφανιστει μια 
                Time.timeScale = 0; //γινεται pause του χρονου μεχρι να απαντησει ο παικτης
            }
            else
            {
                questionOne.gameObject.SetActive(true);
                questionTwo.gameObject.SetActive(true);
                displayAnswerOne.gameObject.SetActive(false);
                displayAnswerTwo.gameObject.SetActive(false);
                displayAnswerThree.gameObject.SetActive(false);
                displayAnswerFour.gameObject.SetActive(false);
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
}
