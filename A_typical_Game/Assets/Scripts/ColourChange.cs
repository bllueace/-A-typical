using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    MeshRenderer myMesh;

    public Material newMat; //material colour will change to

    public int materialToChange;

    public float changeRate = 0.001f; //rate for colour change 

    [HideInInspector]
    public bool shouldRun = true;

    void Start()
    {
        myMesh = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (shouldRun)
        {

            Color myColour = myMesh.materials[materialToChange].color; //get the material

            //if color is not what it needs to be, grow or reduce until true
            if (myColour.r < newMat.color.r)
                myColour.r += changeRate;
            if (myColour.r > newMat.color.r)
                myColour.r -= changeRate;

            if (myColour.g < newMat.color.g)
                myColour.g += changeRate;
            if (myColour.g > newMat.color.g)
                myColour.g -= changeRate;

            if (myColour.b < newMat.color.b)
                myColour.b += changeRate;
            if (myColour.b > newMat.color.b)
                myColour.b -= changeRate;

            myMesh.materials[materialToChange].color = myColour;

            //a way to tell when color is close to desired (for some reason float acts funny)
            if ((myColour.r > newMat.color.r - changeRate) && (myColour.r < newMat.color.r + changeRate) &&
                (myColour.g > newMat.color.g - changeRate) && (myColour.g < newMat.color.g + changeRate) &&
                (myColour.b > newMat.color.b - changeRate) && (myColour.b < newMat.color.b + changeRate))
                shouldRun = false;
             
            //Debug.Log("<color=red>Color r:</color>" + myColour.r.ToString());
        }

    }
}
