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
        StartCoroutine(WaitToLoad(2));
    }
    public void newGame()
    {
        loadingScreen.SetActive(true);
        SavePlayer.playerHleath = 1.0f;
        SavePlayer.newGame = true;
        StartCoroutine(WaitToLoad(1));
    }

    public void quitGame()
    {
        Application.Quit();
    }
    
    IEnumerator WaitToLoad(int sceneID)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneID);
    }

    // Update is called once per frame
}
