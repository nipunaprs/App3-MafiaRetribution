using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerMission2 : MonoBehaviour
{
    public Text helpMsgText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHelpMsgText(string input)
    {
        helpMsgText.text = input;
    }
}