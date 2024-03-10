using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUpdate : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text currencyText;
    [SerializeField] private Text killsAmountText;
    [SerializeField] private Image strenghtBar;
    [SerializeField] private Image manaBar;
    [SerializeField] private Image staminaBar;
    void Start()
    {
        nameText.text = SavePlayer.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.text = InventoryItems.totalCoins.ToString();
        killsAmountText.text = SavePlayer.killsAmount.ToString();
        strenghtBar.fillAmount = SavePlayer.strenghtAmountDisplay;
        staminaBar.fillAmount = SavePlayer.staminaAmountDisplay;
        manaBar.fillAmount = SavePlayer.manaAmountDisplay;
    }
}
