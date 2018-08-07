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
        GameObject puzA = GameObject.Find("puzzleA_01_grp");
        puzleA = puzA.GetComponent<CheckPuzleASolved>();

        GameObject puzB = GameObject.Find("puzzleA_02_grp");
        puzleB = puzB.GetComponent<CheckPuzleBSolved>();

        GameObject puzC = GameObject.Find("puzzleA_03_grp");
        puzleC = puzC.GetComponent<CheckPuzleCSolved>();

        GameObject puzD = GameObject.Find("puzzleA_04_grp");
        puzleD = puzD.GetComponent<CheckPuzleDSolved>();
    }

    // Update is called once per frame
    void Update()
    {
        if(puzleA.puzleSolved == true && puzleB.puzleSolved == true && puzleC.puzleSolved == true && puzleD.puzleSolved == true)
        {
            //{
            GameObject door1 = GameObject.Find("level2Wall_01");
            GameObject door2 = GameObject.Find("level2Wall_02");
            GameObject door3 = GameObject.Find("level2Wall_03");
            GameObject door4 = GameObject.Find("level2Wall_04");
            GameObject door5 = GameObject.Find("level2Wall_05");
            GameObject door6 = GameObject.Find("level2Wall_06");
            GameObject door7 = GameObject.Find("level2Wall_07");
            GameObject door8 = GameObject.Find("level2Wall_08");
            GameObject door9 = GameObject.Find("level2Wall_09");
            GameObject door10 = GameObject.Find("level2Wall_10");
            GameObject door11 = GameObject.Find("level2Wall_11");
            GameObject door12 = GameObject.Find("level2Wall_12");

            door1.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);
            door2.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);
            door3.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);
            door4.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);
            door5.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);
            door6.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);
            door7.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);
            door8.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);
            door9.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);
            door10.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);
            door11.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);
            door12.GetComponent<Renderer>().material.SetInt("_EmissionIntensity", 2);



            //}
            this.GetComponent<Renderer>().material.SetTexture("_Emi_circles", T_emi_Circles);
           this.GetComponent<Renderer>().material.SetTexture("_Emi_Line_door", T_emi_lineDoor);

            Debug.Log("All solved!");
        }

        else
        {
            this.GetComponent<Renderer>().material.SetTexture("_Emi_circles", null);
            this.GetComponent<Renderer>().material.SetTexture("_Emi_Line_door", null);
        }
    }
}
