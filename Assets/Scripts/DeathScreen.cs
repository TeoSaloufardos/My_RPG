using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (SavePlayer.playerHleath <=0)
        {
            anim.SetTrigger("death");
            StartCoroutine(WaitToReload());
        }
    }

    IEnumerator WaitToReload()
    {
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }
}
