using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipTimer : MonoBehaviour {

    public float timeLeft = 20; //tooltip display timer
    public GameObject Myself;
    public GameObject previous = null;
    public SteamVR_TrackedObject controller;


    //private bool shownOnce = false;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {

        var Device = SteamVR_Controller.Input((int)controller.index);

        if (Device.GetPress(SteamVR_Controller.ButtonMask.ApplicationMenu)) //if button is pressed disable tooltip
            timeLeft = 0;

        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            Myself.SetActive(false); //disable tooltip if run time is over
        }

        if (previous != null) //if there is another tooltip showing disable it before showing current one
        {
            if(previous.activeSelf)
            {
                previous.SetActive(false);
            }
        }

    }
}
