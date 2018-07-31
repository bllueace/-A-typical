using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Cleared : MonoBehaviour
{
    public CheckPuzleASolved puzleA;
    public CheckPuzleBSolved puzleB;
    public CheckPuzleCSolved puzleC;
    public CheckPuzleDSolved puzleD;


    public Texture T_emi_Circles;
    public Texture T_emi_lineDoor;

    // Use this for initialization
    void Start()
    {
        GameObject puzA = GameObject.Find("Puzzle_A");
        puzleA = puzA.GetComponent<CheckPuzleASolved>();

        GameObject puzB = GameObject.Find("Puzzle_B");
        puzleB = puzB.GetComponent<CheckPuzleBSolved>();

        GameObject puzC = GameObject.Find("Puzzle_C");
        puzleC = puzC.GetComponent<CheckPuzleCSolved>();

        GameObject puzD = GameObject.Find("Puzzle_D");
        puzleD = puzD.GetComponent<CheckPuzleDSolved>();
    }

    // Update is called once per frame
    void Update()
    {
        if(puzleA.puzleSolved == true && puzleB.puzleSolved == true && puzleC.puzleSolved == true && puzleD.puzleSolved == true)
        {
            {
                GameObject door1 = GameObject.Find("Room1_door1_piece_1");
                door1.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

                GameObject door2 = GameObject.Find("Room1_door1_piece_2");
                door2.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

                GameObject door3 = GameObject.Find("Room1_door1_piece_3");
                door3.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

                GameObject door4 = GameObject.Find("Room1_door1_piece_4");
                door4.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

                GameObject door5 = GameObject.Find("Room1_door1_piece_5");
                door5.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

                GameObject door6 = GameObject.Find("Room1_door1_piece_6");
                door6.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

                GameObject door7 = GameObject.Find("Room1_door1_piece_7");
                door7.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

            }
           transform.GetComponent<Renderer>().material.SetTexture("_Emi_circles", T_emi_Circles);
           transform.GetComponent<Renderer>().material.SetTexture("_Emi_Line_door", T_emi_lineDoor);

            Debug.Log("All solved!");
        }

        else
        {
            transform.parent.GetComponent<Renderer>().material.SetTexture("_Emi_circles", null);
            transform.parent.GetComponent<Renderer>().material.SetTexture("_Emi_Line_door", null);
        }
    }
}
