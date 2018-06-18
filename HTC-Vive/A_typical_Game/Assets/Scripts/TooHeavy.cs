using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooHeavy : MonoBehaviour
{

    public SteamVR_TrackedObject Controller;
    public bool canPickUp;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "TooHeavy")
        {
            Debug.Log("TOO HEAVY?");
            canPickUp = true;
        }
    }

    void OnTriggerExit()
    {
        canPickUp = false;
    }

}
