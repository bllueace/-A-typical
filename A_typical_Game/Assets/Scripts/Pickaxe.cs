using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe : MonoBehaviour
{

    public GameObject Myself;
    public bool counter = false;

    void FixedUpdate()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (!counter)
        {
            //enable physics on touch 
            Myself.GetComponent<Rigidbody>().isKinematic = false;
            Myself.GetComponent<Rigidbody>().useGravity = true;
            counter = true;

        }


}
}
