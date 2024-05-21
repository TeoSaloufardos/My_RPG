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
        questionsLevel1.Add(new string[]{"Επίλεξε τη σωστή απάντηση:",
            "Όλα τα αγαθά είναι εμπορεύματα.",
            "Όλα τα εμπορεύματα είναι αγαθά.",
            "Όλα τα αγαθά είναι οικονομικά αγαθά.",
            "Όλα είναι λάθος.",
            "2",
            "E"
        });
        questionsLevel1.Add(new string[]{"Το laptop που χρησιμοποιεί  στην εργασία του ένας προγραμματιστής είναι:",
            "υλικό, καταναλωτό και κεφαλαιουχικό",
            "υλικό, καταναλωτό και καταναλωτικό",
            "υλικό, διαρκές και καταναλωτικό",
            "υλικό, διαρκές και κεφαλαιουχικό",
            "4",
            "E"
        });
        questionsLevel1.Add(new string[]{"Το κύριο οικονομικό πρόβλημα:",
            "Eίναι προσωρινό, οπότε δεν χρειάζεται λύση.",
            "Aφορά μόνο τις πολύ ανεπτυγμένες χώρες .",
            "Aποσχολεί μόνο τους εργάτες.",
            "Eίναι μόνιμο και απασχολεί κάθε κοινωνία.",
            "4",
            "E"
        });
        questionsLevel1.Add(new string[]{"Το βασικό οικονομικό πρόβλημα της κάθε χώρας είναι:",
            "H έλλειψη γνώσης των εργαζομένων.",
            "H σχετική έλλειψη των παραγωγικών συντελεστών.",
            "H σχετική έλλειψη οργάνωσης των παραγωγών.",
            "H ανεπαρκής ενημέρωση των επιχειρήσεων για τις ανάγκες των καταναλωτών ",
            "2",
            "E"
        });
        questionsLevel1.Add(new string[]{"Χρήμα είναι οτιδήποτε οι άνθρωποι θεωρούν ότι έχει αξία ?",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "2",
            "E"
        });
        questionsLevel1.Add(new string[]{"Οι ροές που γίνονται μεταξύ των βασικών μονάδως του οικονομικού συστήματος είναι...",
            "ροές αγαθών, παραγωγικών συντελεστών και χρήματος.",
            "ροές  χρήματος και παραγωγικών συντελεστών.",
            "ροές αγαθών και χρήματος.",
            "μόνο χρήματος.",
            "1",
            "E"
        });
        questionsLevel1.Add(new string[]{"Οι ροές προϊόντων, παραγωγικών συντελεστών και χρήματος στο οικονομικό κύκλωμα, είναι συνεχείς και δεν έχουν πάντα το ίδιο μέγεθος.",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "1",
            "E"
        });
        questionsLevel1.Add(new string[]{"Ο όρος οικονομικό κύκλωμα χαρακτηρίζει το σύνολο των σχέσεων που δημιουργούνται μεταξύ των βασικών μονάδων του οικονομικού κυκλώματος.",
            "Σωστό",
            "Λάθος",
            "3",
            "4",
            "1",
            "E"
        });
        questionsLevel1.Add(new string[]{"Ορθολογικός είναι ένας καταναλωτής που:",
            "έχει υψηλό εισόδημα.",
            "η ισορροπία του δεν επηρεάζεται από τις τιμές των αγαθών.",
            "επιλέγει αυτά τα αγαθά και σε εκείνες τις ποσότητες που με βάση το εισόδημά του μεγιστοποιεί τη χρησιμότητά του από τη κατανάλωσή τους.",
            "ζητάει την επανάληψη μιας απόλαυσης που αποκτά από τη κατανάλωση ενός αγαθού.",
            "3",
            "E"
        });
        questionsLevel1.Add(new string[]{"Η καμπύλη αγοραίας ζήτησης για ένα αγαθό, προκύπτει όταν:",
            "αφαιρέσουμε τις τιμές από τις ποσότητες του ζητούμενου αγαθού.",
            "αθροίσουμε οριζόντια τις καμπύλες ατομικής ζήτησης.",
            "αθροίσουμε κατακόρυφα τις καμπύλες ατομικής ζήτησης",
            "όλα τα παραπάνω.",
            "2",
            "E"
        }); 
        questionsLevel1.Add(new string[]{"Ο όρος ceteris paribus σημαίνει:",
            "όλα ίσα μεταξύ τους.",
            "όλα άνισα μεταξύ τους",
            "τα άλλα μεταβλητά.",
            "τα άλλα σταθερά",
            "4",
            "E"
        });
        questionsLevel1.Add(new string[]{"Η ζήτηση ενός κανονικού αγαθού αυξάνεται, όταν:",
            "αυξάνεται η τιμή ενός συμπληρωματικού αγαθού.",
            "μειώνεται η τιμή ενός συμπληρωματικού αγαθού.",
            "αυξάνεται ο αριθμός των καταναλωτών.",
            "σε κάθε περίπτωση.",
            "2",
            "E"
        });
        questionsLevel1.Add(new string[]{"Όταν αυξάνεται η ζήτηση, τότε:",
            "η καμπύλη ζήτησης μετατοπίζεται δεξιά.",
            "η καμπύλη ζήτησης μετατοπίζεται αριστερά.",
            "επηρεάζεται μόνο η καμπύλη προσφοράς.",
            "δεν επηρεάζεται η καμπύλη ζήτησης.",
            "1",
            "Ε"
        });
        questionsLevel1.Add(new string[]{"Ποιο από τα παρακάτω είναι ΛΑΘΟΣ?",
            "Β <- 2 * 7 ",
            "Β <-  2 * “Β” - 4",
            "Β <- 2 * Β",
            "Β <- 2 * Β - 4",
            "2",
            "T"
        });
        questionsLevel1.Add(new string[]{"Ποιο από τα παρακάτω είναι σωστό?",
            "Η έννοια του αλγορίθμου συνδέεται αποκλειστικά με την πληροφορική.",
            "Ο πιο δομημένος τρόπος παρουσίασης αλγορίθμων είναι με ελεύθερο κείμενο.",
            "Ένας αλγόριθμος στοχεύει στην επίλυση ενός προβλήματος.",
            "Το πηγαίο πρόγραμμα εκτελείται από τον υπολογιστή χωρίς μεταγλώττιση.",
            "3",
            "T"
        });
        questionsLevel1.Add(new string[]{"Ποιο από τα παρακάτω είναι σωστό?",
            "Σε μια δομή επανάληψης μπορεί να εμφανιστούν λογικά λάθη που σχετίζονται με τη συνθήκη επανάληψης ή τερματισμού.",
            "Υπερχείλιση έχουμε όταν ωθήσουμε ένα στοιχείο σε μια ήδη γεμάτη στοίβα.",
            "Γενικά, σε περιπτώσεις που η επανάληψη θα συμβεί τουλάχιστον μία φορά, είναι προτιμότερη η χρήση της ΜΕΧΡΙΣ_ΟΤΟΥ.",
            "Ο βρόχος ΓΙΑ i AΠΟ 0 ΜΕΧΡΙ 0 δεν εκτελείται καμία φορά.",
            "4",
            "T"
        });
        questionsLevel1.Add(new string[]{"Ποιο από τα παρακάτω είναι ΛΑΘΟΣ?",
            "Η συνθήκη στην εντολή «Όσο...επανάλαβε» ελέγχεται τουλάχιστον μια φορά.",
            "Η πιο απλή μορφή αναζήτησης στοιχείου σε πίνακα είναι η σειριακή μέθοδος.",
            "Μετά από την εκτέλεση της εντολής Σ <- Σ + Α, η τιμή της μεταβλητής Σ είναι πάντοτε μεγαλύτερη από την τιμή που είχε πριν από την εκτέλεση της εντολής.",
            "Οι πίνακες περιορίζουν τις δυνατότητες του προγράμματος.",
            "3",
            "T"
        });
        questionsLevel1.Add(new string[]{"Σύμφωνα με τα παρακάτω ποιο είναι το σωστό?",
            "Στην περίπτωση που το A=2 τότε το ΑΝ Α > 2 εκτελείται.",
            "Στην περίπτωση εκτέλεσης του ΓΙΑ i ΑΠΟ 1 ΕΩΣ 10 το κομμάτι κώδικα μεσα στην δομή επανάληψης εκτελείται 9 ακριβώς φορές.",
            "Στην περίπτωση του Α <> 2 τότε το ΑΝ Α > 2 εκτελείται.",
            "Στην περίπτωση που το Α = 2 και Β = “2” τότε Α και Β είναι ΧΑΡΑΚΤΗΡΕΣ.",
            "3",
            "T"
        });
        questionsLevel1.Add(new string[]{"Α <- 15\nΓΡΑΨΕ Α, Ά'\nΠοια είναι το σωστό αποτέλεσμα?",
            "Α15",
            "1515",
            "ΑΑ",
            "15Α",
            "4",
            "T"
        }); 
        questionsLevel1.Add(new string[]{"Ποια είναι η εντολή εκχώρησης για την εκχώρηση της τιμής 5?",
            "Α = 5",
            "Α <= 5",
            "Α -> 5",
            "Α <- 5 ",
            "4",
            "T"
        });
        questionsLevel1.Add(new string[]{"Από το Χ <- ΑΛΗΘΗΣ καταλαβαίνεις ότι το Χ είναι μια μεταβλητή:",
            "Ακέραια",
            "Πραγματική",
            "Λογική",
            "Χαρακτήρας",
            "3",
            "T"
        });
        questionsLevel1.Add(new string[]{"Από το Χ <- “Αληθής” καταβαίνεις ότι το Χ είναι μια μεταβλητή:",
            "Ακέραια",
            "Πραγματική",
            "Λογική",
            "Χαρακτήρας",
            "4",
            "T"
        });
        questionsLevel1.Add(new string[]{"Ποια από τις παρακάτω εντολές ζητάει από το χρήστη να εισάγει τιμές στις μεταβλητές α,β,γ ?",
            "ΔΙΑΒΑΣΕ α + β + γ",
            "ΔΙΑΒΑΣΕ α, β, γ",
            "ΔΙΑΒΑΣΕ ‘α ‘+ ‘β ‘+ ‘γ’",
            "ΔΙΑΒΑΣΕ 'α’, ‘β’, ‘γ’",
            "2",
            "T"
        });
        questionsLevel1.Add(new string[]{"Ποιο από τα παρακάτω κομμάτια κώδικα εκτελούν σωστά το άθροιμα του Κ και του Λ ?",
            "αθρ <- ‘κ’ + λ ",
            "αθρ <- ‘κ’ + ‘λ’ ",
            "αθρ <- κ + λ",
            "Κανένα",
            "3",
            "T"
        });
        questionsLevel1.Add(new string[]{"Δίνοντας αυτόν τον κώδικα Χ <- 4 * 2 / 2 - 4 ποιο θα είναι το αποτέλεσμά του",
            "0",
            "-2",
            "Δεν είναι δυνατή η εκτέλεση του (έχει 0 ως παρανομαστή)",
            "4",
            "1",
            "T"
        });
        questionsLevel1.Add(new string[]{"Εκτελείται ο κώδικας  ΓΡΑΨΕ ‘Η τιμή είναι’ Χ?",
            "Ναι",
            "Όχι, γιατί θα έπρεπε να είναι ΓΡΑΨΕ ‘Η τιμή είναι’, Χ",
            "Όχι, γιατί δεν μπορεί να εμφανίσει και χαρακτήρες και την τιμή Χ",
            "Κανένα δεν είναι σωστό",
            "2",
            "T"
        });
        // ----- Δευτερη κατηγορια -------
        questionsLevel2.Add(new string[]{"Ένας καταναλωτής καταναλώνει δύο αγαθά, το ένα είναι κανονικό και το δεύτερο κατώτερο. Αν υπάρξει αύξηση στο εισόδημά του, ceteris paribus, τότε:",
            "θα μειωθεί η ζήτηση και των δύο αγαθών.",
            "θα μειωθεί η προσφορά και των δύο αγαθών.",
            "θα αυξηθεί  η ζήτηση του κατώτερου και θα μειωθεί η ζήτηση του κανονικού.",
            "θα αυξηθεί η ζήτηση του κανονικού και θα μειωθεί η ζήτηση του κατώτερου.",
            "4",
            "E"
        });
        questionsLevel2.Add(new string[]{"Ποιος από τους παρακάτω προσδιοριστικούς παράγοντες της ζήτησης επηρεάζει μόνο την αγοραία ζήτηση:",
            "ο αριθμός των καταναλωτών.",
            "οι προτιμήσεις.",
            "το εισόδημα.",
            "οι τιμές των άλλων αγαθών.",
            "1",
            "E"
        });
        questionsLevel2.Add(new string[]{"Με τη προσδοκία ότι θα επέλθει αύξηση στο εισόδημά τους, οι καταναλωτές:",
            "αυξάνουν τη ζήτηση “σήμερα”.",
            "μειώνουν τη ζήτηση “σήμερα“",
            "έχουν την ίδια συμπεριφορά.",
            "όλα είναι σωστά.",
            "1",
            "E"
        });
        questionsLevel2.Add(new string[]{"Ένας καταναλωτής καταναλώνει ένα κατώτερο αγαθό. Με μια αύξηση στο εισόδημά του και μια ταυτόχρονη αύξηση της τιμής του αγαθού, ceteris paribus, η τελική ζητούμενη ποσότητα:",
            "παραμένει ίση με την αρχική.",
            "θα είναι μικρότερη από την αρχική.",
            "θα είναι μεγαλύτερη από την αρχική.",
            "όλα είναι λάθος.",
            "2",
            "E"
        });
        questionsLevel2.Add(new string[]{"Το Κράτος δεν λαμβάνει υπόψη του την ελαστικότητα ζήτησης ως προς την τιμή, όταν σκοπεύει να φορολογήσει επιπλέον ένα αγαθό.",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "2",
            "E"
        });
        questionsLevel2.Add(new string[]{"Η καμπύλη του συνολικού προϊόντος ενός μεταβλητού συντελεστή εκφράζει, για κάθε δεδομένη χρονική περίοδο, τη σχέση ανάμεσα στο συνολικό προϊόν και:",
            "στην ποσότητα του σταθερού συντελεστή.",
            "στην ποσότητα του μεταβλητού συντελεστή.",
            "στην ποσότητα του σταθερού και του μεταβλητού συντελεστή.",
            "στην χρονική διάρκεια της παραγωγής.",
            "2",
            "E"
        }); 
        questionsLevel2.Add(new string[]{"Όταν το συνολικό προιόν γίνεται μέγιστο, το μέσο προιόν είναι μηδέν:",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "2",
            "E"
        });
        questionsLevel2.Add(new string[]{"Η επιχείρηση μεγιστοποιεί το κέρδος της σε εκείνο το επίπεδο παραγωγής στο οποίο υπάρχει ισότητα:",
            "τιμής και αυξανόμενου οριακού κόστους.",
            "ποσότητας και συνολικού κόστους.",
            "τιμής και ποσότητας.",
            "τιμής και συνολικού κόστους.",
            "1",
            "E"
        });
        questionsLevel2.Add(new string[]{"Ο πληθωρισμός μειώνει την αξία των αποταμιεύσεων:",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "1",
            "E"
        });
        questionsLevel2.Add(new string[]{" Όταν αυξάνεται το επίπεδο των τιμών, αυξάνεται πάντα και το πραγματικό εισόδημα ενός ατόμου ή μιας οικονομίας.",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "2",
            "E"
        });
        questionsLevel2.Add(new string[]{"Ποιος από τους παρακάτω αλγορίθμους είναι σωστός έτσι ώστε κατά την εκτέλεση του να εκτυπώνει “Πολύ καλά” εάν ο βαθμός είναι μεγαλύτερος του μέσου όρου, “Καλά” εάν είναι ίση ή μικρότερη του μέσου όρου έως και δύο μονάδες ενώ σε κάθε άλλη περίπτωση να επιστρέφει “Μέτρια”.",
            "ΑΝ ΒΑΘΜΟΣ > ΜΟ ΤΟΤΕ\nΓΡΑΨΕ “Πολύ Καλά”\nΑΛΛΙΩΣ_ΑΝ ΜΟ - ΒΑΘΜΟΣ <= 2 ΤΟΤΕ\nΓΡΑΨΕ “Καλά”\nΑΛΛΙΩΣ\nΓΡΑΨΕ “Μέτρια”\nΤΕΛΟΣ_ΑΝ ",
            "ΑΝ ΒΑΘΜΟΣ >= ΜΟ ΤΟΤΕ \nΓΡΑΨΕ “Πολύ Καλά” \nΑΛΛΙΩΣ_ΑΝ ΜΟ - ΒΑΘΜΟΣ <= 2 ΤΟΤΕ \n ΓΡΑΨΕ “Καλά” \nΑΛΛΙΩΣ  \nΓΡΑΨΕ “Μέτρια” \nΤΕΛΟΣ_ΑΝ ",
            "ΑΝ ΒΑΘΜΟΣ >= ΜΟ ΤΟΤΕ \nΓΡΑΨΕ “Πολύ Καλά” \nΑΛΛΙΩΣ_ΑΝ ΒΑΘΜΟΣ <= 2 ΤΟΤΕ \nΓΡΑΨΕ “Καλά” \nΑΛΛΙΩΣ  \nΓΡΑΨΕ “Μέτρια” \nΤΕΛΟΣ_ΑΝ ",
            "ΑΝ ΒΑΘΜΟΣ >= ΜΟ ΤΟΤΕ \nΓΡΑΨΕ “Πολύ Καλά” \nΑΛΛΙΩΣ_ΑΝ ΒΑΘΜΟΣ <= 2 ΤΟΤΕ \nΓΡΑΨΕ “Καλά” \nΤΕΛΟΣ_ΑΝ ",
            "1",
            "T"
        });
        questionsLevel2.Add(new string[]{"Ποιος κώδικας από τους παρακάτω είναι σωστός έτσι ώστε κατά την εκτέλεση του να εκτυπώνει το επώνυμο (ΕΠΩΝΥΜΟ) όταν το τμήμα είναι Γ1 και η βαθμολογία (ΒΑΘΜΟΣ) είναι μεγαλύτερη από 15.",
            "ΑΝ ΤΜΗΜΑ = ‘Γ1’ ΚΑΙ ΒΑΘΜΟΣ > 15 ΤΟΤΕ \nΓΡΑΨΕ ΕΠΩΝΥΜΟ \nΤΕΛΟΣ",
            "ΑΝ ΤΜΗΜΑ = ‘Γ1’ ΚΑΙ ΒΑΘΜΟΣ >= 15 ΤΟΤΕ \nΓΡΑΨΕ ΕΠΩΝΥΜΟ \nΤΕΛΟΣ_ΑΝ",
            "Ν ΤΜΗΜΑ = ‘Γ1’ ΚΑΙ ΒΑΘΜΟΣ > 15 ΤΟΤΕ \nΓΡΑΨΕ ΕΠΩΝΥΜΟ \nΤΕΛΟΣ_ΑΝ",
            "ΑΝ ΤΜΗΜΑ = Γ1 ΚΑΙ ΒΑΘΜΟΣ > 15 ΤΟΤΕ \nΓΡΑΨΕ ΕΠΩΝΥΜΟ \nΤΕΛΟΣ_ΑΝ ",
            "3",
            "T"
        });
        questionsLevel2.Add(new string[]{"Δίνοντας την οδηγία να κατασκευαστεί ένας κώδικας που να εκτυπώνει “Λάθος απάντηση” όταν η απάντηση δεν είναι Ν ή ν ή Ο ή ο, ποιος από τους παρακάτω έτοιμους κώδικες εκπληρώνει αυτήν την συνθήκη.",
            "ΑΝ ΟΧΙ( ΑΠΑΝΤΗΣΗ = “ν” Ή ΑΠΑΝΤΗΣΗ = “Ο” Ή ΑΠΑΝΤΗΣΗ = “ο”) ΤΟΤΕ ΓΡΑΨΕ “ΛΑΘΟΣ ΑΠΑΝΤΗΣΗ”",
            "ΑΝ (ΑΠΑΝΤΗΣΗ = “Ν” Ή ΑΠΑΝΤΗΣΗ = “ν” Ή ΑΠΑΝΤΗΣΗ = “Ο” Ή ΑΠΑΝΤΗΣΗ = “ο”) ΤΟΤΕ ΓΡΑΨΕ “ΛΑΘΟΣ ΑΠΑΝΤΗΣΗ”",
            "ΑΝ ΟΧΙ(ΑΠΑΝΤΗΣΗ = “Ο” Ή ΑΠΑΝΤΗΣΗ = “ο”) ΤΟΤΕ ΓΡΑΨΕ “ΛΑΘΟΣ ΑΠΑΝΤΗΣΗ” ",
            "ΑΝ ΟΧΙ(ΑΠΑΝΤΗΣΗ = “Ν” Ή ΑΠΑΝΤΗΣΗ = “ν” Ή ΑΠΑΝΤΗΣΗ = “Ο” Ή ΑΠΑΝΤΗΣΗ = “ο”) ΤΟΤΕ ΓΡΑΨΕ “ΛΑΘΟΣ ΑΠΑΝΤΗΣΗ”",
            "4",
            "T"
        });
        questionsLevel2.Add(new string[]{"Σε μια στατική δομή το ακριβές μέγεθος της απαιτούμενης κύριας μνήμης καθορίζεται κατά την εκτέλεση του προγράμματος.",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "2",
            "T"
        });
        questionsLevel2.Add(new string[]{"Ο βρόχος για Κ από -4 μέχρι -3 εκτελείται ακριβώς δύο φορές.",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "1",
            "T"
        });
        questionsLevel2.Add(new string[]{"Όταν γίνεται σειριακή αναζήτηση σε έναν πίνακα και το στοιχείο δεν υπάρχει στον πίνακα, τότε υποχρεωτικά προσπελαύνονται όλα τα στοιχεία του πίνακα.",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "1",
            "T"
        });
        questionsLevel2.Add(new string[]{"Έστω πρόβλημα που αναφέρει: “..Να κατασκευάσετε αλγόριθμο που θα ζητάει τις ηλικίες 100 ανθρώπων και να εμφανίζει το μέσο όρο ηλικίας τους...” Ποιο από τα παρακάτω θεωρείς ότι μπορεί να χρησιμοποιηθεί για την λύση του προβλήματος αυτού.",
            "Πρέπει να γίνει χρήση πίνακα, είναι δυνατόν να χρησιμοποιηθεί η εντολή ΓΙΑ.",
            "Η εντολή ΓΙΑ δεν πρέπει να χρησιμοποιηθεί και δεν πρέπει να γίνει χρήση πίνακα.",
            "Είναι δυνατόν να χρησιμοποιηθεί πίνακας, η εντολή για είναι κατάλληλη και είναι δυνατόν να χρησιμοποιηθεί η εντολή ΟΣΟ.",
            "Καμία απάντηση δεν ταιριάζει.",
            "3",
            "T"
        });
        questionsLevel2.Add(new string[]{"Ποιο από τα παρακάτω είναι σωστό?",
            "Το σύμβολο > είναι αριθμητικός τελεστής ενώ το MOD είναι λογικός τελεστής.",
            "Το σύμβολο > και το MOD είναι συγκριτικοί τελεστές.",
            "Το σύμβολο > είναι συγκριτικός τελεστής ενώ το MOD είναι αριθμητικός τελεστής. ",
            "Το σύμβολο >  και το MOD είναι αριθμητικοί τελεστές.",
            "3",
            "T"
        });
        questionsLevel2.Add(new string[]{"Ποιο από τα παρακάτω είναι σωστό?",
            "Το ΟΧΙ είναι συγκριτικός τελεστής, ενώ το * είναι λογικός τελεστής.",
            "Το ΟΧΙ είναι λογικός τελεστής, ενώ το * είναι αριθμιτικός τελεστής.",
            "Το ΟΧΙ και το * είναι συγκριτικοί τελεστές.",
            "Τίποτα από τα παραπάνω.",
            "2",
            "T"
        });
        questionsLevel2.Add(new string[]{"Για τον παρακάτω κώδικα πόσες φορές εμφανίζεται το “Χ” \nΓΙΑ i ΑΠΟ 0 ΜΕΧΡΙ 9 \nΓΙΑ j ΑΠΟ i ΜΕΧΡΙ 9 \nΓΡΑΨΕ  “χ”",
            "54",
            "58",
            "56",
            "55",
            "4",
            "T"
        });
        questionsLevel2.Add(new string[]{"Η πράξη σύζευξης δύο λογικών εκφράσεων δίνει ως αποτέλεσμα την τιμή ΨΕΥΔΗΣ, μόνον όταν και οι δύο εκφράσεις έχουν την τιμή ΨΕΥΔΗΣ.",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "2",
            "T"
        });
        questionsLevel2.Add(new string[]{"Δομημένο χαρακτηρίζονται εκείνα τα προβλήματα των οποίων η επίλυση προέρχεται από μια αυτοματοποιημένη διαδικασία, Για παράδειγμα, η επίλυση της δευτεροβάθμιας εξίσωσης αποτελεί ένα δομημένο πρόβλημα, αφού ο τρόπος επίλυσης της εξίσωσης αποτελεί ένα δομημένο πρόβλημα, αφού ο τρόπος επίλυσης της εξίσωσης είναι γνωστός και αυτοματοποιημένος.",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "1",
            "T"
        });
        questionsLevel2.Add(new string[]{"Σε μια λογική έκφραση, οι συγκριτικοί τελεστές έχουν χαμηλότερη ιεραρχία από τους λογικούς τελεστές.",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "2",
            "T"
        });
        questionsLevel2.Add(new string[]{"Μια υπολογιστική διαδικασία που δεν τελειώνει μετά από συγκεκριμένο αριθμό βημάτων αποτελεί αλγόριθμο.",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "2",
            "T"
        });
        questionsLevel2.Add(new string[]{"Ο αλγόριθμος φυσαλίδας είναι ο πιο απλός και ταυτόχρονα ο πιο γρήγορος αλγόριθμος ταξινόμησης.",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "2",
            "T"
        });
        // ----- κατηγορια 3 -------
        
        questionsLevel3.Add(new string[]{"Αν η τιμή της βενζίνης είναι 1,9 ευρώ ανά λίτρο και το Κράτος θέλει να επιβάλει πρόσθετο φόρο, ο οποίος αυξάνει τη τιμή της κατά 10%. Τότε το πρόσθετος φόρος είναι:",
            "0,18 ευρώ",
            "0,19 ευρώ",
            "0,019 ευρώ",
            "1,1 ευρώ",
            "2",
            "E"
        });
        questionsLevel3.Add(new string[]{"Αν η αγοραία συνάρτηση ζήτησης ενός αγαθού είναι QD=100-5P και γίνει QD=120-6P, τότε η ζήτηση των καταναλωτών.",
            "μειώθηκε κατά 20%",
            "μειώθηκε κατά 10%",
            "αυξήθηκε κατά 10%",
            "μειώθηκε κατά 20 μονάδες σε κάθε τιμή",
            "1",
            "E"
        });
        questionsLevel3.Add(new string[]{"Μια επιχείρηση έχει μεταβλητό κόστος 5040\u20ac, μέσο προϊόν 14 μονάδες και μέσο μεταβλητό κόστος 90\u20ac. Πόσους εργάτες απασχολεί;",
            "2",
            "4",
            "7",
            "8",
            "2",
            "E"
        });
        questionsLevel3.Add(new string[]{"Στη γραμμική συνάρτηση της προσφοράς ο συντελεστής γ είναι αριθμός:",
            "θετικός",
            "αρνητικός",
            "μηδέν",
            "θετικός ή αρνητικός ή μηδέν",
            "4",
            "E"
        });
        questionsLevel3.Add(new string[]{"Όταν η τιμή ενός προϊόντος αυξάνεται από 100 σε 120 χρηματικές μονάδες, ceteris paribus, η προσφορερόμενη ποσότητα αυξάνεται από 10 σε 11 μονάδες. Αυτό σημαίνει ότι η ελαστικότητα προσφοράς κατά την αύξηση της τιμής είναι: ",
            "0,3",
            "0,5",
            "1",
            "1,3",
            "2",
            "E"
        });
        questionsLevel3.Add(new string[]{"Στην αγορά ενός προϊόντος η συνάρτηση προσφοράςείναι Qs=20+2P. Αν επιβληθεί από το Κράτος ανώτατη τιμή PA, τα έσοδα των παραγωγών σε αυτή τη τιμή είναι 400\u20ac, οπότε η PA είναι:",
            "18\u20ac",
            "14\u20ac",
            "8\u20ac",
            "10\u20ac",
            "4",
            "E"
        });
        questionsLevel3.Add(new string[]{"Ποια από τις παρακάτω εντολές εκχώρησης έχει ισοδύναμο αποτέλεσμα με το αποτέλεσμα την εκτέλεση των εντολών λ <- λ+1, λ <- λ-2,  λ <- λ+3.",
            "λ <- λ + 2",
            "λ <- λ - 2",
            "λ <- λ + 1",
            "λ <- λ - 1",
            "1",
            "T"
        });
        questionsLevel3.Add(new string[]{"Ποιο ζευγάρι εντολών εκπληρώνουν τα εξής (Εκχώρησε στο Y τον μέσο όρο των Κ, Λ, Μ. 3) και (Το τελευταίο ψηφίο του Α είναι 5).",
            "Υ <- (Κ+Λ+Μ)/3 και Α div 10 = 5 αντίστοιχα",
            "Υ <- (Κ+Λ+Μ)/3 και Α mod 10 = 5 αντίστοιχα",
            "Υ <- Κ+Λ+Μ/3 και Α mod 10 = 5 αντίστοιχα",
            "Υ <- (Κ+Μ)/3 + Λ και Α mod 10 = 5 αντίστοιχα",
            "3",
            "T"
        });
        questionsLevel3.Add(new string[]{"Ποια εντολή από τις παρακάτω ελέγχουν το β είναι διψήφιος αριθμός.",
            "B > 10 KAI B < 100",
            "B > 10 KAI B <= 100",
            "B >= 10 KAI B <= 100",
            "B >= 10 KAI B < 100",
            "4",
            "T"
        });
        questionsLevel3.Add(new string[]{"Τι είναι η δομή επιλογής ΑΝ... ΑΛΛΙΩΣ_ΑΝ",
            "Μια δομή που επιτρέπει την επανάληψη ενός τμήματος κώδικα εάν μια συνθήκη είναι αληθής.",
            "Μια δομή που επιτρέπει την εκτέλεση ενός τμήματος κώδικα μόνο εάν μια συνθήκη είναι αληθής, αλλιώς εκτελείται ένα διαφορετικό τμήμα κώδικα.",
            "Μια δομή που επιτρέπει την εκτέλεση ενός τμήματος κώδικα πολλές φορές μέχρι η συνθήκη να γίνει αληθής.",
            "Μια δομή που επιτρέπει την εκτέλεση ενός τμήματος κώδικα πολλές φορές, ανεξάρτητα από την τιμή μιας συνθήκης.",
            "2",
            "T"
        });
        questionsLevel3.Add(new string[]{"Τι είναι ένας μεταγλωττιστής (compiler);",
            "Ένα εργαλείο που μετατρέπει τον πηγαίο κώδικα ενός προγράμματος σε μηχανικό κώδικα που μπορεί να εκτελεστεί απευθείας από τον υπολογιστή.",
            "Ένα πρόγραμμα που επιτρέπει στον προγραμματιστή να επικοινωνεί με τον υπολογιστή μέσω γραφικού περιβάλλοντος.",
            "Ένα εργαλείο που δημιουργεί γραφικά περιβάλλοντα ανάπτυξης (IDEs) για τη δημιουργία εφαρμογών.",
            "Ένα πρόγραμμα που ελέγχει την απόδοση της εφαρμογής κατά τη διάρκεια της εκτέλεσής της.",
            "1",
            "T"
        });
        questionsLevel3.Add(new string[]{"Τι είναι η αντικειμενοστραφής προγραμματισμός (OOP);",
            "Μια μέθοδος προγραμματισμού που επικεντρώνεται στη χρήση μόνο αριθμητικών τιμών και μαθηματικών λειτουργιών.",
            "Ένα παραδοσιακό μοντέλο ανάπτυξης λογισμικού που βασίζεται σε στάδια και τεκμηριωμένες προδιαγραφές.",
            "Μια προσέγγιση προγραμματισμού που επιτρέπει τη δημιουργία πολλαπλών ανεξάρτητων μονάδων κώδικα, γνωστών ως αντικείμενα.",
            "Ένας τύπος μεθόδου προγραμματισμού που χρησιμοποιείται για την επεξεργασία κειμένων και αρχείων.",
            "2",
            "T"
        }); 
        questionsLevel3.Add(new string[]{"Ποια είναι η διαφορά μεταξύ μεθόδου και συνάρτησης στον προγραμματισμό;",
            "Δεν υπάρχει διαφορά, οι όροι χρησιμοποιούνται ανταλλάξιμα.",
            "Μια μέθοδος είναι μια συνάρτηση που ορίζεται εντός ενός αντικειμένου, ενώ μια συνάρτηση είναι αυτόνομη.",
            "Μια μέθοδος εκτελείται μόνο μια φορά, ενώ μια συνάρτηση μπορεί να καλείται πολλές φορές.",
            "Μια μέθοδος δεν μπορεί να επιστρέψει τιμή, ενώ μια συνάρτηση μπορεί.",
            "1",
            "T"
        });
        questionsLevel3.Add(new string[]{"Ποια είναι η διαφορά μεταξύ αριθμητικού και λογικού τύπου δεδομένων;",
            "Και οι δύο τύποι δεδομένων αναφέρονται σε αριθμητικές τιμές.",
            "Ο αριθμητικός τύπος δεδομένων αναπαριστά αριθμητικές τιμές όπως ακέραιοι και δεκαδικοί αριθμοί, ενώ ο λογικός τύπος δεδομένων αναπαριστά αληθή ή ψευδή τιμές.",
            "Ο αριθμητικός τύπος δεδομένων χρησιμοποιείται για τον υπολογισμό μαθηματικών λειτουργιών, ενώ ο λογικός τύπος δεδομένων χρησιμοποιείται για τον έλεγχο συνθηκών και τη λογική των προγραμμάτων.",
            "Ο αριθμητικός τύπος δεδομένων περιλαμβάνει μόνο ακέραιες τιμές, ενώ ο λογικός τύπος δεδομένων περιλαμβάνει μόνο δεκαδικές τιμές.",
            "2",
            "T"
        });
        questionsLevel3.Add(new string[]{"Ποιο είναι το πλεονέκτημα της χρήσης της αντικειμενοστραφούς προσέγγισης στον προγραμματισμό;",
            "Η ευκολία στην ανάπτυξη μικρών και απλών εφαρμογών.",
            "Η δυνατότητα αναδιάρθρωσης του κώδικα για να προσαρμοστεί σε αλλαγές.",
            "Η ευκολία στη διαχείριση και τη συντήρηση μεγάλων εφαρμογών.",
            "Η δυνατότητα να αναπτύσσονται εφαρμογές που να εκτελούνται μόνο σε συγκεκριμένες πλατφόρμες.",
            "3",
            "T"
        }); 
        questionsLevel3.Add(new string[]{"Τι συμβολίζει ο ρόμβος στην γραφική αναπαράσταση του κώδικα (διαγραμμάτων ροής)?",
            "Εντολές εκχώρησης",
            "Εντολές εξόδου",
            "Δομές ελέγχου, επανάληψης",
            "Τίποτα από τα παραπάνω",
            "3",
            "T"
        });
        
        // ---- kathgoria 4h
        
        questionsLevel4Panel.Add(new string[]{"Tο οριακό κόστος δείχνει τον ρυθμό με τον οποίο μεταβάλλεται το συνολικό κόστος, όταν μεταβάλλεται η παραγόμενη ποσότητα κατά μία μονάδα.",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "1",
            "E"
        });
        questionsLevel4Panel.Add(new string[]{"Στη φάση της ύφεσης παρατηρείται:",
            "έλλειψη των επενδύσεων",
            "μείωση της ανεργίας",
            "αύξηση των επενδύσεων",
            "αύξηση της παραγωγής",
            "1",
            "E"
        });
        questionsLevel4Panel.Add(new string[]{"Το ΑΕΠ είναι ποσοτικός και ποιοτικός δείκτης ευημερίας .",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "2",
            "E"
        });
        questionsLevel4Panel.Add(new string[]{"Στη μικροοικονομική ανάλυση σημείο αναφοράς είναι:",
            "η συνολική κατανάλωση μιας οικονομίας.",
            "το συνολικό εισόδημα μιας οικονομίας.",
            "ο προσδιορισμός της τιμής ενός αγαθού.",
            "ο συνολικός όγκος της παραγωγής μιας οικονομίας.",
            "3",
            "E"
        });
        questionsLevel4Panel.Add(new string[]{"Η φάση της κρίσης στον οικονομικό κύκλο χαρακτηρίζεται από εκτεταμένη ανεργία.",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "2",
            "E"
        });
        questionsLevel4Panel.Add(new string[]{"Ο βρόχος Για κ από 5 μέχρι 5 εκτελείται μία φορά.",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "1",
            "T"
        });
        questionsLevel4Panel.Add(new string[]{"Η πράξη σύζευξης δύο λογικών εκφράσεων δίνει ως αποτέλεσμα την τιμή ΨΕΥΔΗΣ, μόνον όταν και οι δύο εκφράσεις έχουν την τιμή ΨΕΥΔΗΣ.",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "2",
            "T"
        });
        questionsLevel4Panel.Add(new string[]{"Ένα υποπρόγραμμα μπορεί να καλείται μόνο από το κύριο πρόγραμμα.",
            "Σωστό",
            "Λάθος",
            "",
            "",
            "2",
            "T"
        });
        questionsLevel4Panel.Add(new string[]{"Δίδεται ένας ακέραιος αριθμός Ν και ζητείται ποια είναι η παραγοντοποίηση του Ν με το μεγαλύτερο πλήθος παραγόντων, ποια η κατηγορία στην οποία ανήκει με κριτήριο το είδος της επίλυσης που επιζητεί.",
            "Βελτιστοποίησης",
            "Απόφασης",
            "Υπολογιστικό",
            "Τίποτα από τα παραπάνω",
            "3",
            "T"
        });
        questionsLevel4Panel.Add(new string[]{"Δίδεται ένας ακέραιος αριθμός Ν και ζητείται να ποια είναι η παραγοντοποίηση του Ν με το μεγαλύτερο πλήθος παραγόντων, ποια η κατηγορία στην οποία ανήκει με κριτήριο το είδος της επίλυσης που επιζητεί.",
            "Βελτιστοποίησης",
            "Απόφασης",
            "Υπολογιστικό",
            "Τίποτα από τα παραπάνω",
            "3",
            "T"
        });
    }
}
