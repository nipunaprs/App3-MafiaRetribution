using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None; //Locks cursor to window
        Cursor.visible = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }

    public void ViewSaves()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
