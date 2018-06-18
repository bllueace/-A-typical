using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooHeavyManager : ControllerGrabObject
{

    // Use this for initialization
    void Start()
    {

    }

    ControllerGrabObject grab = new ControllerGrabObject();
    public TooHeavy left;
    public TooHeavy right;




    // Update is called once per frame
    void Update()
    {

        var rDevice = SteamVR_Controller.Input((int)right.Controller.index);
        var lDevice = SteamVR_Controller.Input((int)left.Controller.index);


        bool PickUpLeft = left.canPickUp;
        bool pickUpRight = right.canPickUp;


        if ((PickUpLeft == true) && (pickUpRight == true))
        {
            if (lDevice.GetPress(SteamVR_Controller.ButtonMask.Trigger) && (rDevice.GetPress(SteamVR_Controller.ButtonMask.Trigger)))
            {
                Debug.Log("Picking up!");
                //grab.GrabObject();
            }
        }

        if ((left.canPickUp && lDevice.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)) && (right.canPickUp && rDevice.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)))
        {
            Debug.Log("Releasing!");
            //grab.ReleaseObject();
        }


    }
}