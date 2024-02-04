using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMessageHandler : MonoBehaviour
{
    [SerializeField] private GameObject aboveUiPanel;
    [SerializeField] private Text uiMessage;
    public static string passedMessage = null; //ειναι static για να μπορει να δεχεται τιμες απο τα scripts.
    public static float desiredDelay = 1.5f; //default ειναι 3s αλλα μπορει να αλλαχτει στον κωδικα μεσα.
    
    void Start()
    {
        aboveUiPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        displayUImessage();
    }

    public void displayUImessage()
    {
        if (passedMessage != null)
        {
            aboveUiPanel.SetActive(true);
            uiMessage.text = passedMessage;

            //Ξεκιναει την μετρηση και την εμφανιση του μηνυματος, θα το διαγραψει μετα απο λιγη ωρα.
            StartCoroutine(ClearMessageAfterDelay(desiredDelay));
        }
    }
    
    private IEnumerator ClearMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        //Καθαριζει το μηνυμα, τον χρονο και εξαφανιζει το panel τελειως.
        uiMessage.text = "";
        passedMessage = null;
        desiredDelay = 1.5f;
        aboveUiPanel.SetActive(false);
        
    }
}
