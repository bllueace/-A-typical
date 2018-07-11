using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePuzleA : MonoBehaviour
{
    /*other methods of rotation*/
    //bool rotating = false;
    //IEnumerator RotateMe(Vector3 byAngles, float inTime)
    //{
    //   // float difference;
    //    var fromAngle = transform.rotation;
    //    var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
    //    for (var t = 0f; t < 1f; t += Time.deltaTime / inTime)
    //    {
    //        transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
    //        yield return null;
    //    }
    //    rotating = false;
    //}

    //void OnMouseDown()
    //{

    //    if(!rotating)
    //    {
    //        rotating = true;
    //        StartCoroutine(RotateMe(Vector3.up * 90, 1));
    //    }
    //}
    ////////////////////////////////////////////////////////
    //float speed = 90.0f;
    //Vector3 vCurr = Vector3.zero;

    //private Vector3 vNew = Vector3.zero;

    //void Start()
    //{
    //    transform.eulerAngles = vCurr;
    //    vNew = vCurr;
    //}

    //void Update()
    //{
    //    vCurr = Vector3.MoveTowards(vCurr, vNew, speed * Time.deltaTime);
    //    transform.eulerAngles = vCurr;
    //}

    //void OnMouseDown()
    //{
    //    if (vCurr == vNew)
    //        vNew.y += 90.0f;
    //}  

    float speed = 90.0f;
    Quaternion quatern;

    public bool piece = false;
    //bool piece2 = false;
    //bool piece3 = false;
    //bool puzzleSolved = false;

    void Start()
    {
        quatern = transform.rotation;        
    }

    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, quatern, speed * Time.deltaTime);

        checkIfCorrect();
    }

    void checkIfCorrect()
    {
        if ((transform.rotation.y == 0))
        {
            piece = true;
            //Debug.Log("part 1 " + piece1);
        }
        else
        {
            piece = false;
        }
        //if ((gameObject.name == "Cube_A_2") && (transform.rotation.y == 0))
        //{
        //    piece2 = true;
        //    Debug.Log("part 2 " + piece2);
        //}
        //if ((gameObject.name == "Cube_A_1") && (transform.rotation.y == 0))
        //{
        //    piece3 = true;
        //    Debug.Log("part 3 " + piece3);
        //}
        //if ((piece1 == true) && (piece2 == true) && (piece3 == true))
        //{
        //    puzzleSolved = true;
        //    Debug.Log("All pieces correct!" + puzzleSolved);
        //}
    }

    void OnMouseDown()
    {
        if (transform.rotation == quatern)
        {
            quatern = Quaternion.AngleAxis(90.0f, Vector3.up) * quatern;
        }
    }
}
