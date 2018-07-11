using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPuzleASolved : MonoBehaviour {


    public RotatePuzleA piece1;
    public RotatePuzleA piece2;
    public RotatePuzleA piece3;





    // Use this for initialization
    void Start () {




		
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject p1 = GameObject.Find("Cube_A_1");
        piece1 = p1.GetComponent<RotatePuzleA>();

        GameObject p2 = GameObject.Find("Cube_A_2");
        piece2 = p2.GetComponent<RotatePuzleA>();

        GameObject p3 = GameObject.Find("Cube_A_3");
        piece3 = p3.GetComponent<RotatePuzleA>();


        if (piece1.piece == true && piece2.piece == true && piece3.piece == true)
        {
            Debug.Log("Solved!");
        }
        //if(gameObject.name == "Cube_A_1" && (transform.rotation.y >= 1 && transform.rotation.y >= 350))
        //{
        //    Debug.Log("solved");
        //}

        //if (gameObject.name == "Cube_A_2" && (transform.rotation.y >= 1 && transform.rotation.y >= 350))
        //{
        //    Debug.Log("solved");
        //}

        //if (gameObject.name == "Cube_A_3" && (transform.rotation.y < 1 || transform.rotation.y > 359))
        //{
        //    Debug.Log("part 1 solved ");
        //}


    }
}
