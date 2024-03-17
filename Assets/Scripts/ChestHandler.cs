using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestHandler : MonoBehaviour
{

    private Animator objectAnimator;
    private bool notOpened = true; //Αυτο το βαζω για να μην επαναλαμβανει το animation, οταν ο παικτης εχει ηδη ανοιξει το κουτι.
    private bool hasClosed = false;
    [SerializeField] private int giveCoins = 25; //Το default θα ειναι να δινει 25 coins καθε chest, μπορει ομως να αλλαχτει αναλογα με την περιπτωση.
    [SerializeField] private GameObject particleEffect;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject canvasText;
    [SerializeField] private Text goldAmount;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private GameObject mainCam;
    private int goldDisplay;
    [SerializeField] private GameObject inventory;
    [SerializeField] private AudioClip openChest;
    
    //pedia gia to crate
    [SerializeField] private bool crate = false;
    [SerializeField] private GameObject destroyedCrate;
    [SerializeField] private GameObject theCrate;
    
    void Start()
    {
        if (crate == false)
        {
            objectAnimator = GetComponent<Animator>();
        }
        canvasText.SetActive(false);
        goldDisplay = giveCoins;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (crate == false)
        {
            if (other.CompareTag("Player"))
            {
                if (notOpened)
                {
                    if (InventoryItems.ItemsQuantities[16] > 0) /*Γνωριζω πως το 16 είναι το id του κλειδιου οποτε
                    εδω ελεγχω εαν ο παικτης εχει κλειδι διαθεσιμο ελεγχοντας τον πινακα που κραταει τις ποσοτητες
                    των αντικειμενων.*/
                    {
                        InventoryItems.totalCoins += giveCoins;

                        objectAnimator.SetTrigger("open");
                        UiMessageHandler.passedMessage = ("+" + giveCoins + " νομίσματα, νέο υπόλοιπο " +
                                                          InventoryItems.totalCoins + " νομίσματα.");
                        giveCoins = 0;
                        notOpened = false;
                        if (InventoryItems.ItemsQuantities[16] == 1)
                        {
                            InventoryItems.removeItem = true;
                            InventoryItems.removeItemWithID = 16;
                        }

                        InventoryItems.ItemsQuantities[16] -= 1;
                        inventory.GetComponent<AudioSource>().clip = openChest;
                        inventory.GetComponent<AudioSource>().Play();
                    }
                    else
                    {
                        UiMessageHandler.passedMessage =
                            "Δεν έχεις κλειδί διαθέσιμο στο inventory σου !!!"; /*Εαν δεν εχει τοτε
                            εδω γινεται χρηση του script που διαχειριζεται τα μηνυματα και του στελνω ενα μηνυμα να εμφανισει.*/
                    }
                }
                else
                {
                    UiMessageHandler.passedMessage = "Αυτό το κουτί το έχεις ανοίξει.";
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (crate == false)
        {
            if (other.CompareTag("Player") && notOpened == false && hasClosed == false)
            {
                objectAnimator.SetTrigger("close");
                hasClosed = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canvasText.activeSelf)
        {
            canvasText.transform.Translate(Vector3.up * speed * Time.deltaTime);
            goldAmount.text = goldDisplay.ToString();
            canvasText.transform.LookAt(mainCam.transform.position);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            InventoryItems.ItemsQuantities[16] = InventoryItems.ItemsQuantities[16] + 1; //Cheat code.
        }
    }

    public void particles()
    {
        Instantiate(particleEffect, spawnPoint.transform.position, spawnPoint.transform.rotation);
        canvasText.SetActive(true);
        if (crate)
        {
            InventoryItems.totalCoins += giveCoins;
            UiMessageHandler.passedMessage = ("+" + giveCoins + " νομίσματα, νέο υπόλοιπο " +
                                              InventoryItems.totalCoins + " νομίσματα.");
            giveCoins = 0;
            inventory.GetComponent<AudioSource>().clip = openChest;
            inventory.GetComponent<AudioSource>().Play();
            destroyedCrate.SetActive(true);
            theCrate.SetActive(false);
        }
        StartCoroutine(destroyCanvas());
    }
    
    public void removeItemFromInventory(int itemID)//idio me tou tavernShop
    {
        if (InventoryItems.ItemsQuantities[itemID] == 1)
        {
            InventoryItems.removeItem = true;
            InventoryItems.removeItemWithID = itemID;
        }
        InventoryItems.ItemsQuantities[itemID] -= 1;
    }

    IEnumerator destroyCanvas()
    {
        yield return new WaitForSeconds(2f);
        canvasText.SetActive(false);
        Destroy(this);
    }
}
