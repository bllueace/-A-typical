using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSwitch : MonoBehaviour {

    public GameObject myself;
    public GameObject firstBlock;
    public GameObject replacedBlock;
    public GameObject myLight;


    void OnCollisionEnter(Collision target)
    {
        //Debug.Log("missing block");

        //if collider is the missing block
        if (target.collider.tag == "missingBlock")
        {
            firstBlock.SetActive(false); //disable old block
            replacedBlock.SetActive(true); //enable replaced block
            myLight.SetActive(false); //disable spot light
            myself.SetActive(false);
        }


    }
}
