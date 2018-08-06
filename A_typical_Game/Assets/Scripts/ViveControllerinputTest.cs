using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveControllerinputTest : MonoBehaviour {

    //test 
    //public GameObject destroyedVersion;

    //reference to object being tracked
    private SteamVR_TrackedObject trackedObj;
    //easy access to controller
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update () {
        // gets trackpad position
        if (Controller.GetAxis() != Vector2.zero)
        {
            //Debug.Log(gameObject.name + Controller.GetAxis());
        }

        //checks for trigger press
        if (Controller.GetHairTriggerDown())
        {
            //Debug.Log(gameObject.name + " Trigger Press");
        }

        // checks for trigger release
        if (Controller.GetHairTriggerUp())
        {
            //Debug.Log(gameObject.name + " Trigger Release");
        }

        // gets grip press
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            //Debug.Log(gameObject.name + " Grip Press");
            //Instantiate(destroyedVersion, transform.position, transform.rotation);
            //Destroy(gameObject);
        }

        // gets grip release
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            //Debug.Log(gameObject.name + " Grip Release");
        }
    }
}
