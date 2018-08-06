﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePuzle : MonoBehaviour
{

    float speed = 90.0f;
    Quaternion quatern;

    public bool blockCorrect = false;

    void Start()
    {
        quatern = transform.localRotation;        
    }

    void Update()
    {
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, quatern, speed * Time.deltaTime);

        checkIfCorrect();
    }

    void checkIfCorrect()
    {
        if ((transform.localRotation.y == 0))
        {
            blockCorrect = true;
        }
        else
        {
            blockCorrect = false;
        }
    }

    void OnMouseDown()
    {

        if (transform.localRotation == quatern)
        {
            quatern = Quaternion.AngleAxis(90.0f, Vector3.up) * quatern;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.layer == LayerMask.NameToLayer("RightHand"))
        {
            
            if (transform.localRotation == quatern)
            {
                quatern = Quaternion.AngleAxis(90.0f, Vector3.up) * quatern;
            }
        }
        if (collider.gameObject.layer == LayerMask.NameToLayer("LeftHand"))
        {

            if (transform.localRotation == quatern)
            {
                quatern = Quaternion.AngleAxis(-90.0f, Vector3.up) * quatern;
            }
        }
    }
}
