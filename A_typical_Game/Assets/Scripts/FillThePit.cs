﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillThePit : MonoBehaviour {

    public int rockCount;
    public Rigidbody Rock;
    public bool filled = false;

	// Use this for initialization
	void Start () {
	}
    // Update is called once per frame
    void Update() {
        // here for testing purposes
        //if (Input.GetKeyDown("space"))
        //{
        //    Rigidbody RockInstance;
        //    RockInstance = Instantiate(Rock, transform.parent.parent.position, transform.parent.parent.rotation) as Rigidbody;
        //}
	}

    //keep checking if pit is "full" yet
    private void OnTriggerEnter(Collider other)
    {
        rockCount++;
        if (rockCount == 5)
        {
            //rockCount++;
            GameObject go = GameObject.Find("BlockPitTeleport");

            Destroy(go.GetComponent<BoxCollider>());
        }
    }
}
