using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SkipVids : MonoBehaviour
{
    int currentScene;
    public VideoPlayer video;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        video.loopPointReached += CheckOver;
    }

    // Update is called once per frame
    void Update()
    {


        //Skip to next scene
        if (Input.GetKey(KeyCode.X))
        {
            //Skip to next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//the scene that you want to load after the video has ended.
    }
}
