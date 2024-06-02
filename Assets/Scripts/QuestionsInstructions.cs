using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsInstructions : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject instructions;
    public static bool displayQuestionInstructions = false;
    void Start()
    {
        instructions.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (displayQuestionInstructions)
        {
            Debug.Log("has been displayed");
            instructions.SetActive(true);
            displayQuestionInstructions = false;
        }
        
    }

    public void closeQuestionInstructions()
    {
        instructions.SetActive(false);
        Destroy(this);
    }
}
