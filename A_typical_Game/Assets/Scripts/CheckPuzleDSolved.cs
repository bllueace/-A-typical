using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPuzleDSolved : MonoBehaviour
{
    public RotatePuzle piece1;
    public RotatePuzle piece2;
    public RotatePuzle piece3;
    public RotatePuzle piece4;

    public Texture T_emi_lineBottomLeft;

    public bool puzleSolved;
    public GameObject floor;

    // Use this for initialization
    void Start()
    {
        GameObject p1 = GameObject.Find("Cube_D_0");
        piece1 = p1.GetComponent<RotatePuzle>();

        GameObject p2 = GameObject.Find("Cube_D_1");
        piece2 = p2.GetComponent<RotatePuzle>();

        GameObject p3 = GameObject.Find("Cube_D_2");
        piece3 = p3.GetComponent<RotatePuzle>();

        GameObject p4 = GameObject.Find("Cube_D_3");
        piece4 = p4.GetComponent<RotatePuzle>();
    }

    // Update is called once per frame
    void Update()
    {


        if (!puzleSolved)
        {
            if (piece1.blockCorrect == true && piece2.blockCorrect == true && piece3.blockCorrect == true && piece4.blockCorrect == true)
            {
                Debug.Log("Puzle D Solved!");

                piece1.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);
                piece2.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);
                piece3.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);
                piece4.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);

                piece1.GetComponent<RotatePuzle>().enabled = false;
                piece2.GetComponent<RotatePuzle>().enabled = false;
                piece3.GetComponent<RotatePuzle>().enabled = false;
                piece4.GetComponent<RotatePuzle>().enabled = false;

                puzleSolved = true;
                floor.GetComponent<Renderer>().material.SetTexture("_Emi_Line_Bottom_Left", T_emi_lineBottomLeft);

            }

            else
            {
                floor.GetComponent<Renderer>().material.SetTexture("_Emi_Line_Bottom_Left", null);
            }
        }
    }
}
