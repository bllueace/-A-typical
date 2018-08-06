﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveCollapse : MonoBehaviour {

    [SerializeField] Transform Player;
    public GameObject statue, beak, statueFallen;
    // Use this for initialization
    void Start () {
		
	}
	
    //TO DO::Sound needs to added for the collapsing statue

	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(Player.position, this.transform.position) < 2)
        {
            statue.SetActive(false);
            beak.SetActive(true);
            statueFallen.SetActive(true);
        }
    }


}
