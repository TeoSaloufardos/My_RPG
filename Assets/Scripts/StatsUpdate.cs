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
    [SerializeField] private List<GameObject> weaponButtons;
    [SerializeField] private GameObject inventoryObject;
    public bool updateWeapons = true;
    [SerializeField] private GameObject[] items;
    
    void Start()
    {
        nameText.text = SavePlayer.playerName;
        if (SavePlayer.characterPositionData == 0 || SavePlayer.characterPositionData == 1 || SavePlayer.characterPositionData == 2)
        {
            items[0].SetActive(true); //ean einai antras h gunaika o xarakthras anoigei kai kleinei analoga ta items (armours) pou 
            // mporei na agorasei o paikths, dioti einai diaforetika anamesa ston antra kai gunaika character.
            items[1].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.text = InventoryItems.totalCoins.ToString();
        killsAmountText.text = SavePlayer.killsAmount.ToString();
        strenghtBar.fillAmount = SavePlayer.strenghtAmountDisplay;
        staminaBar.fillAmount = SavePlayer.staminaAmountDisplay;
        manaBar.fillAmount = SavePlayer.manaAmountDisplay;

        if (updateWeapons)//enables the weapons into the ui
        {
            for (int i = 0; i < weaponButtons.Count; i++)
            {
                if (inventoryObject.GetComponent<InventoryItems>().weapons[i])
                {
                    weaponButtons[i].SetActive(true);
                }
            }
        }
        if (this.isActiveAndEnabled)//meta to for loop kanei to updateWeapons false etsi wste na mhn ksana trexei sunexws to for loop
        {
            updateWeapons = false;
        }
    }
}
