using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePuzle : MonoBehaviour
{
    // variables
    public AudioClip turning;
    private AudioSource source;
    float speed = 90.0f;
    Quaternion quatern;
    public bool blockCorrect = false;

    void Start()
    {
        //get fire source audio component
        source = GetComponent<AudioSource>();

        quatern = transform.localRotation;        
    }

    void Update()
    {
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, quatern, speed * Time.deltaTime);

        checkIfCorrect();
    }

    //checks if puzzle piece is in correct position
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

    //for testing purposes allows to rotate puzzle with mouse click
    void OnMouseDown()
    {
        if (transform.localRotation == quatern)
        {
            quatern = Quaternion.AngleAxis(90.0f, Vector3.up) * quatern;
            source.PlayOneShot(turning);
        }
    }

    //check for controller collision with the puzzle piece
    void OnTriggerEnter(Collider collider)
    {
        //if collision with right controller, rotate left
        if (collider.gameObject.layer == LayerMask.NameToLayer("RightHand"))
        {
            
            if (transform.localRotation == quatern)
            {
                quatern = Quaternion.AngleAxis(90.0f, Vector3.up) * quatern;
                source.PlayOneShot(turning);
            }
        }
        //if collision with left controller, rotate right
        if (collider.gameObject.layer == LayerMask.NameToLayer("LeftHand"))
        {

            if (transform.localRotation == quatern)
            {
                quatern = Quaternion.AngleAxis(-90.0f, Vector3.up) * quatern;
                source.PlayOneShot(turning);
            }
        }
    }
}
