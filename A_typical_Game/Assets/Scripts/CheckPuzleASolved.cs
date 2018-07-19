using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPuzleASolved : MonoBehaviour
{


    public RotatePuzleA piece1;
    public RotatePuzleA piece2;
    public RotatePuzleA piece3;
    public RotatePuzleA piece4;


    public Texture texture1;
    public Texture texture2;
    public Texture texture3;
    public Texture texture4;


    // Use this for initialization
    void Start()
    {





    }

    // Update is called once per frame
    void Update()
    {
        GameObject p1 = GameObject.Find("Cube_A_0");
        piece1 = p1.GetComponent<RotatePuzleA>();

        GameObject p2 = GameObject.Find("Cube_A_1");
        piece2 = p2.GetComponent<RotatePuzleA>();

        GameObject p3 = GameObject.Find("Cube_A_2");
        piece3 = p3.GetComponent<RotatePuzleA>();

        GameObject p4 = GameObject.Find("Cube_A_3");
        piece4 = p4.GetComponent<RotatePuzleA>();


        if (piece1.piece == true && piece2.piece == true && piece3.piece == true && piece4.piece == true)
        {
            Debug.Log("Solved!");


            p1.GetComponent<Renderer>().material.mainTexture = texture1;
            p2.GetComponent<Renderer>().material.mainTexture = texture2;
            p3.GetComponent<Renderer>().material.mainTexture = texture3;
            p4.GetComponent<Renderer>().material.mainTexture = texture4;


        }
    }
}
