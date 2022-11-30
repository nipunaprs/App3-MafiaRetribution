using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerMission2 : MonoBehaviour
{
    public Text helpMsgText;
    public Text moneyCollectText;

    public int moneyCollected;
    public int enemiesKilled;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(moneyCollected == 100)
        {
            Debug.Log("mission finished -- change scene");
        }
    }


    public void KilledEnemy()
    {
        enemiesKilled++;
        moneyCollected += 20;
        moneyCollectText.text = "Money Recovered: $" + moneyCollected + "k/$100k";
    }

    public void UpdateHelpMsgText(string input)
    {
        helpMsgText.text = input;
    }
}
