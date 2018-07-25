using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour {

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



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Grip")) //check if grippable object
        {
            Debug.Log("Grip Trigger Enter");
            canGrip = true;
        }
    }
    void OnTriggerExit()
    {
        Debug.Log("Grip Trigger Exit");
        canGrip = false;
    }

}
