using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour {

    public GameObject Body;
    public SteamVR_TrackedObject controller;

    [HideInInspector] //no need to see it in inspector
    public Vector3 prevPos;

    //[HideInInspector]
    public bool canGrip;
    public bool test;

	void Start ()
    {
        prevPos = controller.transform.localPosition;
	}
	
	void Update ()
    {
        var device = SteamVR_Controller.Input((int)controller.index);
        if (canGrip && device.GetPress(SteamVR_Controller.ButtonMask.Grip))
        {
            Body.transform.position += (prevPos - controller.transform.localPosition);
            //test = true;
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
