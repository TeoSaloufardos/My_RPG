using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopUpMessageHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update

    [SerializeField] private GameObject textBox;
    [SerializeField] private Text message;

    private Vector3 screenPoint;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        textBox.SetActive(true);
        screenPoint.x = Input.mousePosition.x + 400;
        screenPoint.y = Input.mousePosition.y;
        screenPoint.z = 1f;

        textBox.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
        MessageDisplay();
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
        
    }

    public void MessageDisplay()
    {
        message.text = "Empty Message";
    }
}
