using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipTimer : MonoBehaviour {

    public float timeLeft = 20;
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

        if (Device.GetPress(SteamVR_Controller.ButtonMask.ApplicationMenu))
            timeLeft = 0;

        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            Myself.SetActive(false);
        }

        if (previous != null)
        {
            if(previous.activeSelf)
            {
                previous.SetActive(false);
            }
        }

    }
}
