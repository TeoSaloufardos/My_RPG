using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsDatabase : MonoBehaviour
{
    public static List<string[]> questionsLevel1 = new List<string[]>();
    void Start()
    {
        questionsLevel1.Clear(); 
        questionsLevel1.Add(new string[]{"Ποιος είναι ο νόμος της ζήτησης?",
           "Όσο η τιμή αυξάνεται τόσο η ζητούμενη ποσότητα μειώνεται",
           "Όσο το εισόδημα αυξάνεται τόσο η ζητούμενη ποσότητα αυξάνεται",
           "Όσο η τιμή αυξάνεται τόσο η ζητούμενη ποσότητα αυξάνεται",
           "Όσο η τιμή αυξάνεται τόσο η ζήτησ μειώνεται",
           "1"
       }); 
        questionsLevel1.Add(new string[]{"Ποιος είναι ο νόμος της ζήτησης?",
           "Όσο η τιμή αυξάνεται τόσο η ζητούμενη ποσότητα μειώνεται",
           "Όσο το εισόδημα αυξάνεται τόσο η ζητούμενη ποσότητα αυξάνεται",
           "Όσο η τιμή αυξάνεται τόσο η ζητούμενη ποσότητα αυξάνεται",
           "Όσο η τιμή αυξάνεται τόσο η ζήτησ μειώνεται",
           "2"
       });
    }

    public void printQuestions()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            for (int i = 0; i < questionsLevel1.Count; i++)
            {
                foreach (var answer in questionsLevel1[i])
                {
                    Debug.Log(answer);
                }  
            }
        }
        
    }

    void Update()
    {
        printQuestions();
    }
}
