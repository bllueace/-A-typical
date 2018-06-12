using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructable_box : MonoBehaviour
{
    public GameObject destroyedVersion;
    public Transform Player;

    private void Update()
    {
        if(Vector3.Distance(Player.position, gameObject.transform.position) < 2)
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
    ////ensures only one object can be grabed at a time
    //private void SetCollidingObject(Collider col)
    //{
    //    //doesn't become a pickup if already holding an object
    //    if (collidingObject || !col.GetComponent<Rigidbody>())
    //    {
    //        return;
    //    }
    //    //assigns object as a potential pickup
    //    collidingObject = col.gameObject;
    //}

    //// 1
    //public void OnTriggerEnter(Collider other)
    //{
    //    SetCollidingObject(other);
    //}

    //// 2
    //public void OnTriggerStay(Collider other)
    //{
    //    SetCollidingObject(other);
    //}

    //// 3
    //public void OnTriggerExit(Collider other)
    //{
    //    if (!collidingObject)
    //    {
    //        return;
    //    }

    //    collidingObject = null;
    //}

    //checks for trigger press


    //private void GrabObject()
    //{



    //}

    //// new fixed joint
    //private FixedJoint AddFixedJoint()
    //{
    //    FixedJoint fx = gameObject.AddComponent<FixedJoint>();
    //    fx.breakForce = 20000;
    //    fx.breakTorque = 20000;
    //    return fx;
    //}

    //private void ReleaseObject()
    //{
    //    // checks for fixed joint
    //    if (GetComponent<FixedJoint>())
    //    {
    //        // remove connectien and destrot the joint
    //        GetComponent<FixedJoint>().connectedBody = null;
    //        Destroy(GetComponent<FixedJoint>());
    //        // controlls speed and rotation after release
    //        objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
    //        objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
    //    }
    //    // remove reference from object
    //    objectInHand = null;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    // when trigger used pickup object if theres a potential target
    //    if (Controller.GetHairTriggerDown())
    //    {
    //        if (collidingObject)
    //        {
    //            GrabObject();
    //        }
    //    }

    //    // release the picked up object
    //    if (Controller.GetHairTriggerUp())
    //    {
    //        if (objectInHand)
    //        {
    //            ReleaseObject();
    //        }
    //    }
    //}
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Valve.VR;
////using UnityEngine.Events;

//public class destructable_box : MonoBehaviour
//{

//    public GameObject destroyedVersion;
//    SteamVR_Controller.Device device;
//    //SteamVR_Controller.Input((int)GetComponent<SteamVR_TrackedObject>().index);
//    SteamVR_TrackedObject controller;
//    //Vector2 touchpad;

//    private void Start()
//    {
//       //controller = gameObject.GetComponent<SteamVR_TrackedObject>();
//       controller = GetComponent<SteamVR_TrackedObject>();
//       //device = SteamVR_Controller.Input((int)controller.index);
//    }
//    void Update()
//    {
//        device = SteamVR_Controller.Input((int)controller.index);

//        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
//        {
//               Instantiate(destroyedVersion, transform.position, transform.rotation);
//               Destroy(gameObject);
//        }

//        //device = SteamVR_Controller.Input((int)controller.index);
//        //If finger is on touchpad
//        //if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
//        //{
//        //    Read the touchpad values
//        //    touchpad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
//        //}
//    }

//    //void OnMouseDown()
//    //{
//    //    Instantiate(destroyedVersion, transform.position, transform.rotation);
//    //    Destroy(gameObject);


//    //}

//    //Instantiate(destroyedVersion, transform.position, transform.rotation);
//    //Destroy(gameObject);
//}