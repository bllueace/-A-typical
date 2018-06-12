using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour {

    //public BoxCollider Player;
    public BoxCollider Body;
    public Transform Player;
    
    void Start ()
    {
        Player = Player.GetComponent<Transform>();
        Body = Body.GetComponent<BoxCollider>();
        
    }
    
	void Update ()
    {

        //Body.transform.Translate(1,1,1);
        //Body.center = new Vector3(10, 10, 10);
        //Body.
    }
}
