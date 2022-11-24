using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{

    public bool gunOut = false;
    public Animator anim;
    public GameObject gunObj;
    public GameObject gameManager;

    private void Start()
    {
        gameManager.GetComponent<GameManagerMission2>().UpdateHelpMsgText("Press G toggle you're gun!");
    }

    // Update is called once per frame
    void Update()
    {
        //jumping
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (gunOut)
            {
                gunOut = false;
                anim.SetBool("gunout", false);
                gunObj.SetActive(false);

                //put back gun, make sure animations change
            }
            else
            {
                gunOut = true;
                anim.SetBool("gunout", true);
                gunObj.SetActive(true);
                //bring out gun, make sure animations change
            }
        }
    }
}
