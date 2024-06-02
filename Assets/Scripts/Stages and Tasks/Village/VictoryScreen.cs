using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private GameObject victoryScreenObject;
    [SerializeField] private Text totalKills;
    [SerializeField] private Text totalCorrectAnswers;
    [SerializeField] private Text totalWrongAnswers;
    [SerializeField] private Text questionsLevel;
    [SerializeField] private Text totalCoins;

    public static bool hasOpened = false;
    private int playerLevel;
    private bool hasShown = false;
    
    public void closeVictoryScreen()
    {
        victoryScreenObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (hasOpened && !hasShown)
        {
            totalCoins.text = InventoryItems.totalCoins.ToString();
            totalWrongAnswers.text = SavePlayer.wrongAnswers.ToString();
            totalKills.text = SavePlayer.killsAmount.ToString();
            questionsLevel.text = (SavePlayer.answersLevel * 100 + "/100").ToString();
            hasShown = true;
        }
    }
}
