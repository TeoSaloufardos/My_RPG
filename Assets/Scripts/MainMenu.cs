using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject contienueButton;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject saveObject;
    void Start()
    {
        if (Application.persistentDataPath + "/saveDataFile.dat" != null)
        {
            contienueButton.SetActive(true);
        }
        else
        {
            contienueButton.SetActive(false);
        }
        Cursor.visible = true;
    }

    public void continueGame()
    {
        loadingScreen.SetActive(true);
        saveObject.SetActive(true);
        SavePlayer.continueData = true;
        StartCoroutine(WaitToLoad());
    }
    public void newGame()
    {
        SceneManager.LoadScene(2);
    }

    public void quitGame()
    {
        Application.Quit();
    }
    
    IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
