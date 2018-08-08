using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPuzleBSolved : MonoBehaviour
{
    public RotatePuzle piece1;
    public RotatePuzle piece2;
    public RotatePuzle piece3;
    public RotatePuzle piece4;

    public Texture T_emi_lineTopRight;

    public bool puzleSolved;

    public GameObject floor;

    // Use this for initialization
    void Start()
    {
        GameObject p1 = GameObject.Find("puzzleBlock_01 1");
        piece1 = p1.GetComponent<RotatePuzle>();

        GameObject p2 = GameObject.Find("puzzleBlock_02 1");
        piece2 = p2.GetComponent<RotatePuzle>();

        GameObject p3 = GameObject.Find("puzzleBlock_03 1");
        piece3 = p3.GetComponent<RotatePuzle>();

        GameObject p4 = GameObject.Find("puzzleBlock_04 1");
        piece4 = p4.GetComponent<RotatePuzle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!puzleSolved)
        {
            if (piece1.blockCorrect == true && piece2.blockCorrect == true && piece3.blockCorrect == true && piece4.blockCorrect == true)
            {
                Debug.Log("Puzle B Solved!");

                piece1.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);
                piece2.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);
                piece3.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);
                piece4.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);

                piece1.GetComponent<RotatePuzle>().enabled = false;
                piece2.GetComponent<RotatePuzle>().enabled = false;
                piece3.GetComponent<RotatePuzle>().enabled = false;
                piece4.GetComponent<RotatePuzle>().enabled = false;

                puzleSolved = true;

                floor.GetComponent<Renderer>().material.SetTexture("_Emi_Line_Top_Right", T_emi_lineTopRight);

            }

            else
            {
                floor.GetComponent<Renderer>().material.SetTexture("_Emi_Line_Top_Right", null);
            }
        }
    }
}
