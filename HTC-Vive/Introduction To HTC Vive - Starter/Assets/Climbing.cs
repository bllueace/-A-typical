using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour {

    public Rigidbody Body;
    public SteamVR_TrackedObject controller;

    [HideInInspector] //no need to see it in inspector
    public Vector3 prevPos;

    [HideInInspector]
    public bool canGrip;
    //public bool test;

	void Start ()
    {
        prevPos = controller.transform.localPosition;
	}
	
	void FixedUpdate ()
    {
        var device = SteamVR_Controller.Input((int)controller.index); //get controller
        if (canGrip && device.GetPress(SteamVR_Controller.ButtonMask.Grip)) // #TODO GetPRessDown?
        {
            Body.useGravity = false;
            Body.isKinematic = true;
            Body.transform.position += (prevPos - controller.transform.localPosition);

        }else if(canGrip && device.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) //some physics 
        {
            Body.useGravity = true;
            Body.isKinematic = false;
            Body.velocity = (prevPos - controller.transform.localPosition) / Time.deltaTime;
        }
        else
        {
            Body.useGravity = true;
            Body.isKinematic = false;
        }
        //if (device.GetPress(SteamVR_Controller.ButtonMask.Grip))
        //{
        //    test = true;
        //}
        prevPos = controller.transform.localPosition;
    }

    void OnTriggerEnter()
    {
        canGrip = true;
    }
    void OnTriggerExit()
    {
        canGrip = false;
    }
}
