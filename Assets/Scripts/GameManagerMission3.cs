using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManagerMission3 : MonoBehaviour
{
    public GameObject PauseCanvas;
    public GameObject RegCanvas;
    bool paused;
    public Text helpMsgText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHelpMsgText("Follow the road to the end to meet the boss!");
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

    public void UpdateHelpMsgText(string input)
    {
        helpMsgText.text = input;
    }

    public void finishLevel()
    {
        //Debug.Log("Load the scene");
        File.WriteAllText(Application.dataPath + "/Resources/save.txt", "3");
        SceneManager.LoadScene(9);
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
}
