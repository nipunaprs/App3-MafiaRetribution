using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{

    //Boxes picked up
    int boxesPicked = 0;
    public Text boxesCollectedText;
    public Text helpMsgText;
    public GameObject PauseCanvas;
    public GameObject RegCanvas;
    bool paused;

    public TextAsset lvlSave;

    public GameObject box1;
    public GameObject box2;
    public GameObject box3;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            
            //Pause screen activate
            if (!paused)
            {
                RegCanvas.SetActive(false);
                PauseCanvas.SetActive(true);
                Time.timeScale = 0;
                paused = true;
                Cursor.lockState = CursorLockMode.None; //Unlocks cursor to window
                Cursor.visible = true;
            }
            else
            {
                RegCanvas.SetActive(true);
                PauseCanvas.SetActive(false);
                Time.timeScale = 1;
                paused = false;
                Cursor.lockState = CursorLockMode.Locked; //Locks cursor to window
                Cursor.visible = false;
            }
        }
    }

    public void ResumeGame()
    {
        RegCanvas.SetActive(true);
        PauseCanvas.SetActive(false);
        Time.timeScale = 1;
        paused = false;
        Cursor.lockState = CursorLockMode.Locked; //Locks cursor to window
        Cursor.visible = false;
    }

    public void loadMainMenu()
    {
        Time.timeScale = 1; //Set time back to start
        SceneManager.LoadScene(1); //load the main menu scene
    }

    public void exitGame()
    {
        Application.Quit();
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
            //Debug.Log("End mission or roll scene");

            //SAVE LVL CODE
            //File.AppendAllText(Application.dataPath + "/Resources/save.txt", "1");
            File.WriteAllText(Application.dataPath + "/Resources/save.txt", "1");
            SceneManager.LoadScene(5);




        }
    }

    

    public void UpdateHelpMsgText(string input)
    {
        helpMsgText.text = input;
    }

}
