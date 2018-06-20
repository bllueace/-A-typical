using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedJointScript : MonoBehaviour
{


    bool temp = false;
    Vector3 snapPoint;


    void OnTriggerEnter(Collider col)

    {
        if (col.gameObject.tag == "JointTag")
        {

            gameObject.transform.parent.rotation = col.gameObject.transform.parent.rotation;

            if (gameObject.name == "Left")
            {
                //calculate the snap coardinates
                snapPoint = gameObject.transform.parent.position + (new Vector3(col.GetComponent<Collider>().bounds.size.x * -3, 0, 0));
                col.transform.parent.position = snapPoint;
                //create a fixed joint between two colliding objects
                FixedJoint joint = transform.parent.gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = col.transform.parent.GetComponent<Rigidbody>();
            }

            if (gameObject.name == "Right")
            {
                //calculate the snap coardinates
                snapPoint = gameObject.transform.parent.position + (new Vector3(col.GetComponent<Collider>().bounds.size.x * 3, 0, 0));
                col.transform.parent.position = snapPoint;
                //create a fixed joint between two colliding objects
                FixedJoint joint = transform.parent.gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = col.transform.parent.GetComponent<Rigidbody>();
            }

            if (gameObject.name == "Front")
            {
                //calculate the snap coardinates
                snapPoint = gameObject.transform.parent.position + (new Vector3(0, 0, col.GetComponent<Collider>().bounds.size.z * 3));
                col.transform.parent.position = snapPoint;
                //create a fixed joint between two colliding objects
                FixedJoint joint = transform.parent.gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = col.transform.parent.GetComponent<Rigidbody>();
            }

            if (gameObject.name == "Back")
            {
                //calculate the snap coardinates
                snapPoint = gameObject.transform.parent.position + (new Vector3(0, 0, col.GetComponent<Collider>().bounds.size.z * -3));
                col.transform.parent.position = snapPoint;
                //create a fixed joint between two colliding objects
                FixedJoint joint = transform.parent.gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = col.transform.parent.GetComponent<Rigidbody>();
            }

            if (gameObject.name == "Bottom")
            {
                //calculate the snap coardinates
                snapPoint = gameObject.transform.parent.position + (new Vector3(0, col.GetComponent<Collider>().bounds.size.y * -3, 0));
                col.transform.parent.position = snapPoint;
                //create a fixed joint between two colliding objects
                FixedJoint joint = transform.parent.gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = col.transform.parent.GetComponent<Rigidbody>();
            }

            if (gameObject.name == "Top")
            {
                //calculate the snap coardinates
                snapPoint = gameObject.transform.parent.position + (new Vector3(0, col.GetComponent<Collider>().bounds.size.z * 3, 0));
                col.transform.parent.position = snapPoint;
                //create a fixed joint between two colliding objects
                FixedJoint joint = transform.parent.gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = col.transform.parent.GetComponent<Rigidbody>();
            }

        }
    }
}
