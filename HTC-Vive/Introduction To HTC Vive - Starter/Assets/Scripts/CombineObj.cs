using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineObj : MonoBehaviour
{

    public GameObject keyFragment1;
    public GameObject keyFragment2;


    public void SetParent(GameObject newParent)
    {
        keyFragment1.transform.parent = newParent.transform;
        Debug.Log("Key's Parent: " + keyFragment1.transform.parent.name);
        keyFragment2.transform.parent = newParent.transform;

        if (newParent.transform.parent != null)
        {
            Debug.Log("Key's Grand Parent: " + keyFragment1.transform.parent.name);
        }
    }

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "keyTag")
        {
            SetParent(gameObject);
        }
        //if (col.gameObject.name == "KeyFrag2")
        //{
        //    SetParent(gameObject);
        //}
        //if (col.gameObject.name == "KeyFrag1")
        //{
        //    SetParent(gameObject);
        //}
    }

    public void DetachFromParent()
    {
        transform.parent = null;
    }

}
