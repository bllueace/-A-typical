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
        Debug.Log("missing block");

        if (target.collider.tag == "missingBlock")
        {
            firstBlock.SetActive(false);
            replacedBlock.SetActive(true);
            myLight.SetActive(false);
            myself.SetActive(false);
        }


    }
}
