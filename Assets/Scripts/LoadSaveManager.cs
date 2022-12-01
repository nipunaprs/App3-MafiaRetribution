using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadSaveManager : MonoBehaviour
{

    public GameObject lvl1;
    public GameObject lvl2;
    public GameObject lvl3;
    public GameObject lvl4;

    public string currentSavedLvl;

    // Start is called before the first frame update
    void Start()
    {
        RefreshSaves();
    }

    public void RefreshSaves()
    {
        currentSavedLvl = File.ReadAllText(Application.dataPath + "/Resources/save.txt");
        //File.WriteAllText(Application.dataPath + "/Resources/save.txt", "1");
        //SceneManager.LoadScene(4);

        if (currentSavedLvl == "1")
        {
            lvl1.SetActive(true);
        }
        else if (currentSavedLvl == "2")
        {
            lvl1.SetActive(true);
            lvl2.SetActive(true);
        }
        else if (currentSavedLvl == "3")
        {
            lvl1.SetActive(true);
            lvl2.SetActive(true);
            lvl3.SetActive(true);
        }
        else if (currentSavedLvl == "4")
        {
            lvl1.SetActive(true);
            lvl2.SetActive(true);
            lvl3.SetActive(true);
            lvl4.SetActive(true);
        }
        else
        {
            Debug.Log(currentSavedLvl);
        }
    }

    public void LoadMission1()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadMission2()
    {
        SceneManager.LoadScene(5);
    }

    public void LoadMission3()
    {
        SceneManager.LoadScene(7);
    }

    public void LoadMission4()
    {
        SceneManager.LoadScene(9);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }







}


