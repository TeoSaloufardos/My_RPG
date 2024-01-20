using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopUpMessageHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update

    [SerializeField] private GameObject textBox; //Το object (panel)
    [SerializeField] private Text message; //Πεδιο για το μηνυμα
    [SerializeField] private Text itemTitle; //Πεδιο για το ονομα του αντικειμενου
    
    [NonSerialized] public int objectID = 0; //Το id του αντικειμενου μου ερχεται μεσω του inventoryItems
    

    private bool overIcon = false;
    private bool displaying = true;
    private Vector3 screenPoint;
    
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
    }
    void Start()
    {
        
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
        
            if (objectID == 2)
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
            }
        
    }
}
