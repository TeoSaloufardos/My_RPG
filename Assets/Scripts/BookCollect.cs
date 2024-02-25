using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookCollect : MonoBehaviour
{
    [SerializeField] private GameObject spells;
    [SerializeField] private GameObject magic;
    private bool magicHasCollected = false;
    private bool spellsHasCollected = false;
    [SerializeField] private bool bookForMagic = false;
    [SerializeField] private bool bookForSpells = false;
    [SerializeField] private GameObject gameObjectToRemove;
    [SerializeField] private Button openMagicBookButton;
    [SerializeField] private Button openSpellsBookButton;
    
    private void Start()
    {
        spells.SetActive(false);
        magic.SetActive(false);
        openSpellsBookButton.gameObject.SetActive(false);
        openMagicBookButton.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (bookForMagic && !magicHasCollected)
            {
                magic.SetActive(true);
                openMagicBookButton.gameObject.SetActive(true);
                magicHasCollected = true;
                gameObjectToRemove.SetActive(false);
                UiMessageHandler.passedMessage = "Συγχαρητήρια, μόλις απέκτησες το magic book";
            }else if (bookForSpells && !spellsHasCollected)
            {
                spells.SetActive(true);
                openSpellsBookButton.gameObject.SetActive(true);
                spellsHasCollected = true;
                UiMessageHandler.passedMessage = "Συγχαρητήρια, μόλις απέκτησες το spells book";
                gameObjectToRemove.SetActive(false);
            }
        }
    }
}
