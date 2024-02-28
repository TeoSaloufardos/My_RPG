using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicBook : MonoBehaviour
{
    [SerializeField] private Image magicIcon;
    [SerializeField] private Text magicName;
    [SerializeField] private Text description;
    [SerializeField] private List<Sprite> magicSprites;
    [SerializeField] public List<String> names;
    [SerializeField] public List<String> descriptions;
    [SerializeField] private List<GameObject> iconSets;
    private int currentSet = 0;
    [SerializeField] public GameObject theCanvas;
    void Start()
    {
        magicIcon.sprite = magicSprites[0];
        magicName.text = names[0];
        description.text = descriptions[0];
        iconSets[0].SetActive(true);
    }

    public void next()
    {
        if (currentSet < magicSprites.Count - 1)
        {
            currentSet++;
            magicIcon.sprite = magicSprites[currentSet];
            magicName.text = names[currentSet];
            description.text = descriptions[currentSet];
            switchOff();
            iconSets[currentSet].SetActive(true);
            theCanvas.GetComponent<CreateMagic>().itemID++;
            theCanvas.GetComponent<CreateMagic>().value = 0;
            theCanvas.GetComponent<CreateMagic>().thisValue = 0;
            // theCanvas.GetComponent<CreateMagic>().itemsIDForRemove.Clear();
        }
    }
    
    public void back()
    {
        if (currentSet > 0)
        {
            currentSet--;
            magicIcon.sprite = magicSprites[currentSet];
            magicName.text = names[currentSet];
            description.text = descriptions[currentSet];
            switchOff();
            iconSets[currentSet].SetActive(true);
            theCanvas.GetComponent<CreateMagic>().itemID--;
            theCanvas.GetComponent<CreateMagic>().value = 0;
            theCanvas.GetComponent<CreateMagic>().thisValue = 0;
            // theCanvas.GetComponent<CreateMagic>().itemsIDForRemove.Clear();
        }
    }

    public void switchOff()
    {
        for (int i = 0; i < iconSets.Count; i++)
        {
            iconSets[i].SetActive(false);
        }
    }
    
    
    
    
    
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
