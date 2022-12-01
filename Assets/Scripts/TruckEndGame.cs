using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckEndGame : MonoBehaviour
{
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //MISSION 1 STUFF
        if (collision.gameObject.tag == "Player")
        {
            
            gameManager.GetComponent<GameManagerMission4>().finishLevel();
        }
    }
}
