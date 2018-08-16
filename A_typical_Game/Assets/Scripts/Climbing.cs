using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour {

    public SteamVR_TrackedObject controller; //attatched to each hand, each controller

    [HideInInspector] //no need to see it in inspector
    public Vector3 prevPos;

    [HideInInspector]
    public bool canGrip;

	void Start ()
    {
        prevPos = controller.transform.localPosition;
    }
	


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Grip")) //check if touching a grippable object
        {
            //Debug.Log("GRIPERINOO");
            canGrip = true;
        }
    }
    void OnTriggerExit()
    {
        canGrip = false;
    }
}
