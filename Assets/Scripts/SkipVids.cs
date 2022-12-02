using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SkipVids : MonoBehaviour
{
    int currentScene;
    public VideoPlayer video;
    bool lastScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        video.loopPointReached += CheckOver;
        if (currentScene == 11) lastScene = true;
    }

    // Update is called once per frame
    void Update()
    {


        //Skip to next scene
        if (Input.GetKey(KeyCode.X))
        {
            if (!lastScene) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else SceneManager.LoadScene(1);

        }
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//the scene that you want to load after the video has ended.

        if (lastScene)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
