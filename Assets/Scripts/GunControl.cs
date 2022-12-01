using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{

    public bool gunOut = false;
    public Animator anim;
    public GameObject gunObj;
    public GameObject gameManager;

    public GameObject thirdPerson;
    public GameObject shootingCam;

    public MouseMovement mouseMov;

    private void Start()
    {
        
        //gameManager.GetComponent<GameManagerMission2>().UpdateHelpMsgText("Press G toggle you're gun!");
    }

    // Update is called once per frame
    void Update()
    {
        

        //Get gun out
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

        if (gunOut && Input.GetKey(KeyCode.Mouse1))
        {
            if (mouseMov.currentStyle != MouseMovement.CameraStyle.Combat)
            {
                mouseMov.SwitchCamStyle(MouseMovement.CameraStyle.Combat);
            }
            
        }
        else 
        {
            if(mouseMov.currentStyle != MouseMovement.CameraStyle.Basic)
            {
                mouseMov.SwitchCamStyle(MouseMovement.CameraStyle.Basic);
            }
            //mouseMov.SwitchCamStyle(MouseMovement.CameraStyle.Basic);
        }
       


    }

   

}
