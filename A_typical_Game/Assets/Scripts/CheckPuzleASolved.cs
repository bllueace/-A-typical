﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPuzleASolved : MonoBehaviour
{
    public RotatePuzle piece1;
    public RotatePuzle piece2;
    public RotatePuzle piece3;
    public RotatePuzle piece4;

    public Texture T_emi_lineBottomRight;

    public bool puzleSolved;

    // Use this for initialization
    void Start()
    {
        GameObject p1 = GameObject.Find("Cube_A_0");
        piece1 = p1.GetComponent<RotatePuzle>();

        GameObject p2 = GameObject.Find("Cube_A_1");
        piece2 = p2.GetComponent<RotatePuzle>();

        GameObject p3 = GameObject.Find("Cube_A_2");
        piece3 = p3.GetComponent<RotatePuzle>();

        GameObject p4 = GameObject.Find("Cube_A_3");
        piece4 = p4.GetComponent<RotatePuzle>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!puzleSolved)
        {
            if (piece1.blockCorrect == true && piece2.blockCorrect == true && piece3.blockCorrect == true && piece4.blockCorrect == true)
            {
                Debug.Log("Puzle A Solved!");

                piece1.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                piece2.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                piece3.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                piece4.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                puzleSolved = true;


                transform.parent.parent.GetComponent<Renderer>().material.SetTexture("_Emi_Line_Bottom_Right", T_emi_lineBottomRight);

            }
            else
            {
                transform.parent.parent.GetComponent<Renderer>().material.SetTexture("_Emi_Line_Bottom_Right", null);
            }
           

        }
    }
}
