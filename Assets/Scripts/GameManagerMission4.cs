using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerMission4 : MonoBehaviour
{

    public Text helpMsgText;
    public Text enemiesRemainig;
    public int enemiesKilled;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHelpMsgText("All enemies are after you, be careful!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHelpMsgText(string input)
    {
        helpMsgText.text = input;
    }

    public void finishLevel()
    {
        Debug.Log("Load the scene");
    }

    public void KilledEnemy()
    {
        enemiesKilled++;
        int left = 9 - enemiesKilled;
        enemiesRemainig.text = left.ToString();
    }
}
