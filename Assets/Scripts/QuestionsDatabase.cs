using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuestionsDatabase : MonoBehaviour
{
    public static List<string[]> questionsLevel1 = new List<string[]>();
    public static List<string[]> questionsLevel2 = new List<string[]>();
    public static List<string[]> questionsLevel3 = new List<string[]>();
    public static List<string[]> questionsLevel4Panel = new List<string[]>();
    

    // public string[] displayQustion(int preSignedLevel)
    // {
    //     switch (preSignedLevel)
    //     {
    //         case 1:
    //             return questionsLevel1[Random.Range(0, 30)][1];
    //     }
    // }
    
    public void writeNewQuestion()
    {
        
    }
    
    void Start()
    {   // ΙΣΩΣ ΝΑ ΜΠΟΡΟΥΣΑ ΝΑ ΕΦΑΡΜΟΣΩ ΚΑΤΙ ΣΑΝ ΤΟ SAVE ΔΗΛΑΔΗ ΝΑ ΔΟΥΛΕΨΩ ΕΝΑ JSON ΑΡΧΕΙΟ
        // ΑΛΛΑ ΑΥΤΟ ΜΠΟΡΕΙ ΝΑ ΔΗΜΙΟΥΡΓΗΣΕΙ ΑΡΚΕΤΑ ΠΡΟΒΛΗΜΑ ΣΤΗΝ ΔΙΑΔΙΚΑΣΙΑ ΑΝΑΓΝΩΣΗΣ ΚΑΙ
        // ΕΓΓΡΑΦΗΣ ΤΩΝ ΕΡΩΤΗΣΕΩΝ ΟΠΟΤΕ ΣΚΕΦΤΗΚΑ ΛΟΓΩ ΚΑΙ ΤΟΥ ΟΤΙ ΕΙΝΑΙ ΣΕ ΑΡΚΕΤΑ 
        // ΠΡΩΙΜΟ ΣΤΑΔΙΟ ΤΟ PROJECT ΝΑ ΤΟ ΑΦΗΣΩ ΜΕ ΤΟΝ ΑΠΛΟ ΤΡΟΠΟ
        questionsLevel1.Clear(); 
        questionsLevel1.Add(new string[]{"Ποιος είναι ο νόμος της ζήτησης?",
            "Όσο η τιμή αυξάνεται τόσο η ζητούμενη ποσότητα μειώνεται",
            "Όσο το εισόδημα αυξάνεται τόσο η ζητούμενη ποσότητα αυξάνεται",
            "Όσο η τιμή αυξάνεται τόσο η ζητούμενη ποσότητα αυξάνεται",
            "Όσο η τιμή αυξάνεται τόσο η ζήτησ μειώνεται",
            "1",
            "E"
        }); 
        questionsLevel1.Add(new string[]{"",
            "",
            "",
            "",
            "",
            "1",
            "E"
        });
        questionsLevel1.Add(new string[]{"Π1ς της ζήτησης?",
            "1",
            "2",
            "3",
            "4",
            "2",
            "T"
        });
    }
}
