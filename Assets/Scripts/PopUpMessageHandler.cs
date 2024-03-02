using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopUpMessageHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    // Start is called before the first frame update

    [SerializeField] private GameObject textBox; //Το object (panel)
    [SerializeField] private Text message; //Πεδιο για το μηνυμα
    [SerializeField] private Text itemTitle; //Πεδιο για το ονομα του αντικειμενου
    [NonSerialized] public int objectID = 0; //Το id του αντικειμενου μου ερχεται μεσω του inventoryItems
    private bool overIcon = false;
    private bool displaying = true;
    private Vector3 screenPoint;
    
    //pπειδα που ειναι χρησιμα για την διαδικασια κατασκευης των magic  
    [SerializeField] private Sprite basicCursor;
    [SerializeField] private Sprite handCursor;
    [SerializeField] private Image cursorImage;
    [SerializeField] private GameObject theCanvas;
    [SerializeField] private bool isMagicType;
    [SerializeField] private bool isSpellType;
    [SerializeField] private GameObject magicBook;

    [SerializeField] private GameObject inventory;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        /*Καταλαβα πως εδω εαν βαλω μια if για να ελεγχει εαν το κουμπι του
        ποντικιου πατετιεται ετσι ωστε να κλεινει το pop up message, δεν θα λειτουργει
        διοτι το OnPointerEnter method δεν ειναι σαν το update δηλαδη δεν τρεχει σε καθε
        frame αλλα μονο οταν μπει μεσα στο object ο κερσορας, οποτε τον ελεγχο καθε frame
        για το εαν πατιεται το left mouse button πρεπει να γινεται στο update.*/
        overIcon = true;
        if (displaying)
        {
            cursorImage.sprite = handCursor;
            textBox.SetActive(true);
            screenPoint.x = Input.mousePosition.x + 400;
            screenPoint.y = Input.mousePosition.y;
            screenPoint.z = 1f;
            textBox.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
            MessageDisplay();
        }
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        textBox.SetActive(false);
        overIcon = false;
        cursorImage.sprite = basicCursor;
    }
    void Start()
    {
        textBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (overIcon)/*Εδω ελεγχει εαν το εικονιδιο εμφανιζει μηνυμα, απο την στιγμη που εμφανιζει
        τοτε εαν πατηθει το αριστερο κουμπι το displaying γινεται false ετσι να σταματησει να εμφανιζει 
        το pop up μηνυμα. Η διαδικασια ελεγχου του displaying και το ποτε θα εμφανιζεται το pop up message
        γινεται στην μεθοδο OnPointerEnter.*/
        {
            if (Input.GetMouseButtonDown(0))
            {
                displaying = false;
                textBox.SetActive(false);
                if (isMagicType)
                {
                    Debug.Log("Object id from pop up = " + objectID);
                    inventory.GetComponent<InventoryItems>().selected = objectID;
                }
            }
        }
        //ο ελεγχος εδω γινεται για να ειναι ανοιχτο το message καθως μπαινει στο object ο κερσορας
        if(Input.GetMouseButtonUp(0))
        {
            displaying = true;
        }
    }

    public void MessageDisplay()
    {
        /*Απο το inventoryItems και απο το itempickup μας ερχεται η πληροφορια του τι αντικειμενου εχει λαβει ο παικτης
         απο τον κοσμο. Για αρχη γινεται ενας ελεγχος εαν το αντικειμενο που ελαβε ειναι καποιο απο τα αντικειμενα
         που μπορουν να μπουν μαζι και εαν ειναι τοτε τα καταχωρει σε στυβες, εαν οχι τοτε προχωραει στην ευρεση του
         ονοματος του αντικειμενο αυτου μεσα απο τον πινακα που ειναι static στο inventory items και εχουν καταχωρηθει
         τα ονοματα τους με σειρα οπως και στην λιστα αντικειμενων. Αναλογα με το αντικειμενο εμφανιζεται ποσα εχει, το 
         ονομα του αντικειμενου και το παραθυρο οπου χρειαζεται.*/
            /*if (objectID == 2)
            {
                itemTitle.text = InventoryItems.itemNames[objectID];
                message.text = "Έχεις " + InventoryItems.desertMushrooms + "x " + InventoryItems.itemNames[objectID];
            }else if (objectID == 6)
            {
                itemTitle.text = InventoryItems.itemNames[objectID];
                message.text = "Έχεις " + InventoryItems.roots + "x " + InventoryItems.itemNames[objectID];
            }else if (objectID == 0)
            {
                textBox.SetActive(false);
            }
            else
            {
                itemTitle.text = InventoryItems.itemNames[objectID];
                message.text = "Έχεις 1 " + "x " + InventoryItems.itemNames[objectID];
            }*/

            // for (int i = 0; i < InventoryItems.ItemsQuantities.Count; i++)
            // {
                // if (i == objectID)
                // {
            if (isMagicType)
            {
                itemTitle.text = magicBook.GetComponent<MagicBook>().names[objectID];
                message.text = magicBook.GetComponent<MagicBook>().descriptions[objectID];
            }else
            {
                itemTitle.text = InventoryItems.itemNames[objectID];
                message.text = "Έχεις " + InventoryItems.ItemsQuantities[objectID] + "x " + InventoryItems.itemNames[objectID];
            }
                // }
            // }
            if (objectID == 0 && !isMagicType && !isSpellType)
            {
                textBox.SetActive(false);
            }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        theCanvas.GetComponent<CreateMagic>().thisValue = objectID;
        theCanvas.GetComponent<CreateMagic>().updateValues();
        // if (objectID == theCanvas.GetComponent<CreateMagic>().thisValue)
        // {
        //     Debug.Log("removed");
        //     if (InventoryItems.ItemsQuantities[objectID] == 1)
        //     {
        //         Debug.Log("Icon removed");
        //         InventoryItems.removeItem = true;
        //         InventoryItems.removeItemWithID = objectID;
        //     }
        //     InventoryItems.ItemsQuantities[objectID] -= 1;
        //     Debug.Log("-1 removed");
        // }
    }
}
