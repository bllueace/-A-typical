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
            collider.gameObject.layer = LayerMask.NameToLayer("Pickaxe");
            Debug.Log("Enter");


        }

    }
    private void OnTriggerExit(Collider collider)
    {

        if (collider.gameObject.tag == "Pickaxe")
        {
            
            //collider.gameObject.layer.NameToLayer  = "RightHand"
            collider.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            Debug.Log("EXIT");
            //pickaxe.SetActive(true);
        }

    }
}
