using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe : MonoBehaviour
{

    public GameObject Myself;
    public SteamVR_TrackedObject controller;
    public bool counter = false;

    void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        var device = SteamVR_Controller.Input((int)controller.index);
        if (!counter)
        {
            //if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            //{
                Myself.GetComponent<Rigidbody>().isKinematic = false;
                Myself.GetComponent<Rigidbody>().useGravity = true;
                counter = true;
           // }
        }

    }
}