using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DialogHandler: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Text buttonText;
    [SerializeField] private Color32 messageOff;
    [SerializeField] private Color32 messageOn;

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = messageOn;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = messageOff;
    }

    
    
    
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
