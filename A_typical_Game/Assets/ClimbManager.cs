﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbManager : MonoBehaviour {

    public Rigidbody Body;
    public Climbing left;
    public Climbing right;
    public GameObject feet;
    bool counter = false;

    //void Start()
    //{
    //    var rDevice = SteamVR_Controller.Input((int)right.controller.index); //error out of range TODO
    //    var lDevice = SteamVR_Controller.Input((int)left.controller.index);

    //}

    void FixedUpdate()
    {
        var rDevice = SteamVR_Controller.Input((int)right.controller.index); //error out of range TODO
        var lDevice = SteamVR_Controller.Input((int)left.controller.index);
        //var lDevice = SteamVR_Controller.Input((int)left.index);
        //var rDevice = SteamVR_Controller.Input((int)right.controller.index);

        bool isGripped = left.canGrip || right.canGrip;

        //counter = false;

        if (isGripped)
        {
            if (left.canGrip && lDevice.GetPress(SteamVR_Controller.ButtonMask.Grip)) // #TODO GetPRessDown?
            {
                //Body.useGravity = false;
                //Body.isKinematic = true;
                Body.transform.position += (left.prevPos - left.transform.localPosition);
                feet.GetComponent<PlayerFeet>().SetTouching(true);
                counter = true;
                Debug.Log("Gripped Enter");

            }
            if (right.canGrip && rDevice.GetPress(SteamVR_Controller.ButtonMask.Grip)) // #TODO GetPRessDown?
            {
                //Body.useGravity = false;
                //Body.isKinematic = true;
                Body.transform.position += (right.prevPos - right.transform.localPosition);
                feet.GetComponent<PlayerFeet>().SetTouching(true);
                counter = true;
                Debug.Log("Gripped Enter");
            }
        }

        else
        {
            //Body.useGravity = true;
            //Body.isKinematic = false;
            if (counter)
            {
                feet.GetComponent<PlayerFeet>().SetTouching(false);
                counter = false;
                Debug.Log("NO GRIP");
            }
            
        }

        if (left.canGrip && lDevice.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) //some physics 
        {
           // Body.useGravity = true;
            //Body.isKinematic = false;
            Body.velocity = (left.prevPos - left.transform.localPosition) / Time.deltaTime;
            feet.GetComponent<PlayerFeet>().SetTouching(false);
            //counter = false;
            Debug.Log("Grip Exit");
        }

        if (right.canGrip && rDevice.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) //some physics 
        {
            //Body.useGravity = true;
            //Body.isKinematic = false;
            Body.velocity = (right.prevPos - right.transform.localPosition) / Time.deltaTime;
            feet.GetComponent<PlayerFeet>().SetTouching(false);
            Debug.Log("Grip Exit");
            //counter = false;
        }

        left.prevPos = left.controller.transform.localPosition;
        right.prevPos = right.controller.transform.localPosition;

        //restart level for testing (to remove)
        if (lDevice.GetPress(SteamVR_Controller.ButtonMask.ApplicationMenu) || rDevice.GetPress(SteamVR_Controller.ButtonMask.ApplicationMenu))
            Application.LoadLevel(0);
        //SceneManager.LoadScene(0);


    }
}
