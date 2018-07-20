using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Cleared : MonoBehaviour
{
    public CheckPuzleASolved puzleA;
    public CheckPuzleBSolved puzleB;
    public CheckPuzleCSolved puzleC;
    public CheckPuzleDSolved puzleD;

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
                GameObject room2 = GameObject.Find("Room1_puzzleA");

                room2.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

            }
        }
    }
}
