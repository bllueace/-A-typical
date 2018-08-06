﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructable_box : MonoBehaviour
{
    public GameObject destroyedVersion;
    public GameObject parent;
    //public bool test = false;



    void OnCollisionEnter(Collision target)
    {
        //Debug.Log("pickaxe hit collision");

        if (target.collider.tag == "Pickaxe")
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
            parent.SetActive(false);
        }

        
    }

    //void OnTriggerEnter(Collision target)
    //{
    //    Debug.Log("pickaxe hit trigger");

    //    if (target.collider.tag == "Pickaxe")
    //    {
    //        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    //        gameObject.GetComponent<Rigidbody>().useGravity = true;

    //        Instantiate(destroyedVersion, transform.position, transform.rotation);
    //        Destroy(gameObject);
    //    }


    //}
    //void OnCollisionStay(Collision target)
    //{
    //    Debug.Log("GOnCollisionStay");
    //    //if (target.gameObject.tag.Equals("Pickaxe") == true)
    //    //{
    //    //    Instantiate(destroyedVersion, transform.position, transform.rotation);
    //    //    Destroy(gameObject);
    //    //    test = true;
    //    //}
    //}
    //if (Vector3.Distance(Player.position, gameObject.transform.position) < 2)
    //{
    //    Instantiate(destroyedVersion, transform.position, transform.rotation);
    //    Destroy(gameObject);
    //}
}