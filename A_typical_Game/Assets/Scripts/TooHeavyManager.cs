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


        bool canPickUp = left.canPickUp && right.canPickUp;


        if (canPickUp)
        {
            if ((left.canPickUp && lDevice.GetPress(SteamVR_Controller.ButtonMask.Trigger)) && (right.canPickUp && rDevice.GetPress(SteamVR_Controller.ButtonMask.Trigger)))
            {
                //grab.GrabObject();
            }
        }

        if ((left.canPickUp && lDevice.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)) && (right.canPickUp && rDevice.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)))
        {
            //grab.ReleaseObject();
        }


    }
}
