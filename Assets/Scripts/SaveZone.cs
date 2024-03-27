using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveZone : MonoBehaviour
{
    [SerializeField] private GameObject saveScreen;
    [SerializeField] private GameObject saveText;
    private bool savePause = false;
    
    void Start()
    {
        saveScreen.SetActive(false);
        saveText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && savePause == false)
        {
            saveScreen.SetActive(true);
            Time.timeScale = 0;
            savePause = true;
        }
    }

    // Update is called once per frame
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && savePause == true)
        {
            savePause = false;
        }
    }

    public void SelectYes()
    {
        SavePlayer.saving = true;
        saveText.SetActive(true);
        Time.timeScale = 1;
        StartCoroutine(Continue());
    }

    public void SelectNo()
    {
        Time.timeScale = 1;
        saveScreen.SetActive(false);
    }

    IEnumerator Continue()
    {
        yield return new WaitForSeconds(1);
        saveScreen.SetActive(false);
        saveText.SetActive(false);
    }
}
