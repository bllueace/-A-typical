using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{

    public Rigidbody rigidBody;

    private bool currentlyInteracting;

    private WandController attachedWand;

    private Transform interactivePoint;

    private float velocityFactor = 20000f;
    private float rotationFactor = 400f;
    private Vector3 posDelta;
    private Quaternion rotationDelta;
    private float angle;
    private Vector3 axis;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        interactivePoint = new GameObject().transform;
        velocityFactor /= rigidBody.mass;
    }

    // Update is called once per frame
    void Update()
    {
        if (attachedWand && currentlyInteracting)
        {
            posDelta = attachedWand.transform.position - interactivePoint.position;
            this.rigidBody.velocity = posDelta * velocityFactor * Time.fixedDeltaTime;


            rotationDelta = attachedWand.transform.rotation * Quaternion.Inverse(interactivePoint.rotation);
            rotationDelta.ToAngleAxis(out angle, out axis);

            if (angle > 180)
            {
                angle -= 360;
            }

            this.rigidBody.angularVelocity = (Time.fixedDeltaTime * angle * axis) * rotationFactor;
        }
    }

    public void BeginInteraction(WandController wand)
    {
        attachedWand = wand;
        interactivePoint.position = wand.transform.position;
        interactivePoint.rotation = wand.transform.rotation;
        interactivePoint.SetParent(transform, true);

        currentlyInteracting = true;
    }

    public void EndInteraction(WandController wand)
    {
        if (wand == attachedWand)
        {
            attachedWand = null;
            currentlyInteracting = false;
        }
    }

    public bool IsInteracting()
    {
        return currentlyInteracting;
    }
}
