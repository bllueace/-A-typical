using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillThePit : MonoBehaviour {


    public int rockCount;
    public Rigidbody Rock;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown("space"))
        {
            Rigidbody RockInstance;

            RockInstance = Instantiate(Rock, transform.parent.parent.position, transform.parent.parent.rotation) as Rigidbody;
        }
		
	}


    private void OnTriggerEnter(Collider other)
    {
        rockCount++;

        if(rockCount == 5)
        {
            GameObject go = GameObject.Find("BlockPitTeleport");

            Destroy(go.gameObject);
        }

    }

}
