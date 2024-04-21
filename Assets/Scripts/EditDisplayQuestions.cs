using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditDisplayQuestions : MonoBehaviour
{
//     [SerializeField] private Text questionOne;
//     [SerializeField] private Text questionTwo;
//     [SerializeField] private Text questionThree;
//     [SerializeField] private Text questionFour;
//     [SerializeField] private Text questionFive;
//     [SerializeField] private Text questionSix;
//     [SerializeField] private GameObject button;
//     [SerializeField] private GameObject questionsScreen;
//     private List<String> allQuestions = new List<string>();
//     private int displayedQuestions = 5;
//     void Start()
//     {
//         
//     }
//     
// //     for (int i = 0; i < QuestionsDatabase.questionsLevel1.Count; i++)
// //     {
// //         allQuestions.Add(QuestionsDatabase.questionsLevel1[i][0]);
// //     }
// // for (int i = 0; i < QuestionsDatabase.questionsLevel2.Count; i++)
// // {
// //     allQuestions.Add(QuestionsDatabase.questionsLevel2[i][0]);
// // }
// // for (int i = 0; i < QuestionsDatabase.questionsLevel3.Count; i++)
// // {
// //     allQuestions.Add(QuestionsDatabase.questionsLevel3[i][0]);
// // }
// // for (int i = 0; i < QuestionsDatabase.questionsLevel4Panel.Count; i++)
// // {
// //     allQuestions.Add(QuestionsDatabase.questionsLevel4Panel[i][0]);
// // }
// //
// // foreach (var question in allQuestions)
// // {
// //     Debug.Log("all questions: " + question);
// // }
//
//     public void displayFirstQuestions()
//     {
//         foreach (var question in QuestionsDatabase.questionsLevel1)
//         {
//             allQuestions.Add(question[0]);
//         }
//         foreach (var question in QuestionsDatabase.questionsLevel2)
//         {
//             allQuestions.Add(question[0]);
//         }
//         foreach (var question in QuestionsDatabase.questionsLevel3)
//         {
//             allQuestions.Add(question[0]);
//         }
//         foreach (var question in QuestionsDatabase.questionsLevel4Panel)
//         {
//             allQuestions.Add(question[0]);
//         }
//
//         foreach (var question in allQuestions)
//         {
//             Debug.Log("all questions: " + question);
//         }
//         button.SetActive(false);
//         questionsScreen.SetActive(true);
//         questionOne.text = allQuestions[0];
//         questionTwo.text = allQuestions[1];
//         questionThree.text = allQuestions[2];
//         questionFour.text = allQuestions[3];
//         questionFive.text = allQuestions[4];
//         questionSix.text = allQuestions[5];
//     }
//
//     public void nextPage()
//     {
//         int allquestionsAmount = allQuestions.Count;
//         if (displayedQuestions + 1 < allQuestions.Count)
//         {
//             questionOne.text = allQuestions[displayedQuestions + 1];
//         }
//
//         if (displayedQuestions + 2 < allQuestions.Count)
//         {
//             questionTwo.text = allQuestions[displayedQuestions + 2];
//         }
//
//         if (displayedQuestions + 3 < allQuestions.Count)
//         {
//             questionThree.text = allQuestions[displayedQuestions + 3];
//         }
//
//         if (displayedQuestions + 4 < allQuestions.Count)
//         {
//             questionFour.text = allQuestions[displayedQuestions + 4];
//         }
//
//         if (displayedQuestions + 5 < allQuestions.Count)
//         {
//             questionFive.text = allQuestions[displayedQuestions + 5];
//         }
//
//         if (displayedQuestions + 6 < allQuestions.Count)
//         {
//             questionSix.text = allQuestions[displayedQuestions + 6];
//         }
//         
//         displayedQuestions += 6;
//     }
//     
//     public void previousPage()
//     {
//         if (displayedQuestions - 6 >= 5)
//         {
//             questionOne.text = allQuestions[displayedQuestions - 1];
//             questionTwo.text = allQuestions[displayedQuestions - 2];
//             questionThree.text = allQuestions[displayedQuestions - 3];
//             questionFour.text = allQuestions[displayedQuestions - 4];
//             questionFive.text = allQuestions[displayedQuestions - 5];
//             questionSix.text = allQuestions[displayedQuestions - 6];
//             displayedQuestions -= 6;
//         }
//
//         Debug.Log("back: " + displayedQuestions);
//     }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
