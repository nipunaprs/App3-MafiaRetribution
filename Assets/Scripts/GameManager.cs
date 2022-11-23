using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //Boxes picked up
    int boxesPicked = 0;
    public Text boxesCollectedText;
    public Text helpMsgText;

    public GameObject box1;
    public GameObject box2;
    public GameObject box3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void incrementBoxes()
    {
        boxesPicked++;
        //Debug.Log("incremented boxes, current value" + boxesPicked);
        boxesCollectedText.text = "Crates Dropped Off: " + boxesPicked;

        if (boxesPicked == 1)
        {
            box1.SetActive(true);
        }
        else if (boxesPicked == 2)
        {
            box2.SetActive(true);
        }
        else if (boxesPicked == 3)
        {
            box3.SetActive(true);
            Debug.Log("End mission or roll scene");
        }
    }

    public void UpdateHelpMsgText(string input)
    {
        helpMsgText.text = input;
    }

}
