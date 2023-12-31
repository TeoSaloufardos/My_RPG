using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItems : MonoBehaviour
{
    [SerializeField] private GameObject inventoryMenu;
    [SerializeField] private GameObject closedBook;
    [SerializeField] private GameObject openBook;
    
    void Start()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openMenu()
    {
        inventoryMenu.SetActive(true);
        openBook.SetActive(true);
        closedBook.SetActive(false);
        Time.timeScale = 0; //κανω pause τον χρονο για να μπει ο παικτης με την ησυχια του μεσα στο menu
    }
    
    public void closeMenu()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        Time.timeScale = 1; //συνεχιζω το παιχνιδι
    }
}
