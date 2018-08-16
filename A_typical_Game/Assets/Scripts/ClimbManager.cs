using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbManager : MonoBehaviour {

    public Rigidbody Body;
    public Climbing left;
    public Climbing right;

    void FixedUpdate()
    {
        //set each controller
        var rDevice = SteamVR_Controller.Input((int)right.controller.index);
        var lDevice = SteamVR_Controller.Input((int)left.controller.index);

        bool isGripped = left.canGrip || right.canGrip; //if either controller is gripping

        if (isGripped)
        {
            if (left.canGrip && lDevice.GetPress(SteamVR_Controller.ButtonMask.Grip)) 
            {
                Body.useGravity = false; //stop gravity
                Body.isKinematic = true; //make body stationary
                Body.transform.position += (left.prevPos - left.transform.localPosition); //move body along with the controller

            }
            if (right.canGrip && rDevice.GetPress(SteamVR_Controller.ButtonMask.Grip))
            {
                Body.useGravity = false;
                Body.isKinematic = true;
                Body.transform.position += (right.prevPos - right.transform.localPosition);

            }
        }

        else
        {
            //Body.useGravity = true;
            //Body.isKinematic = false;
        }

        if (left.canGrip && lDevice.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) //body physics for launching yourself 
        {
            Body.useGravity = true;
            Body.isKinematic = false;
            Body.velocity = (left.prevPos - left.transform.localPosition) / Time.deltaTime;
        }

        if (right.canGrip && rDevice.GetPressUp(SteamVR_Controller.ButtonMask.Grip))  //body physics for launching yourself 
        {
            Body.useGravity = true;
            Body.isKinematic = false;
            Body.velocity = (right.prevPos - right.transform.localPosition) / Time.deltaTime;
        }

        left.prevPos = left.controller.transform.localPosition;
        right.prevPos = right.controller.transform.localPosition;

        //restart level for testing (to remove)
        if (lDevice.GetPress(SteamVR_Controller.ButtonMask.ApplicationMenu) || rDevice.GetPress(SteamVR_Controller.ButtonMask.ApplicationMenu))
            Application.LoadLevel(0);
        //SceneManager.LoadScene(0);


    }
}
