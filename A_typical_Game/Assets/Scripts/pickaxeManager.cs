using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickaxeManager : MonoBehaviour {

    public GameObject pickaxe;
    //GameObject temp;

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Pickaxe")
        {
            //change pickaxes layer if triggered (this layer is ignored in physics so pickaxe doesnt interact with things while equpped)
            collider.gameObject.layer = LayerMask.NameToLayer("Pickaxe"); 
            //Debug.Log("Enter");
        }

    }
    private void OnTriggerExit(Collider collider)
    {

        if (collider.gameObject.tag == "Pickaxe")
        {
            collider.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast"); //change it back once it leaves the toolbelt
        }

    }
}
