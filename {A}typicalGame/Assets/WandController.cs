using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour
{


    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    // private GameObject pickup;

    HashSet<InteractableItem> objectsHoveringOver = new HashSet<InteractableItem>();

    private InteractableItem closestitem;
    private InteractableItem InteractingItem;

    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller not connected");
            return;
        }

        if (controller.GetPressDown(gripButton))
        {
            float minDistance = float.MaxValue;

            float distance;
            foreach (InteractableItem item in objectsHoveringOver)
            {
                distance = (item.transform.position - transform.position).sqrMagnitude;
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestitem = item;
                }
            }

            InteractingItem = closestitem;
            closestitem = null;

            if (InteractingItem)
            {
                if (InteractingItem.IsInteracting())
                {
                    InteractingItem.EndInteraction(this);
                }

                InteractingItem.BeginInteraction(this);
            }

        }
        if (controller.GetPressUp(gripButton) && InteractingItem != null)
        {
            InteractingItem.EndInteraction(this);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        InteractableItem colliderItem = collider.GetComponent<InteractableItem>();
        if (colliderItem)
        {
            objectsHoveringOver.Add(colliderItem);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        InteractableItem colliderItem = collider.GetComponent<InteractableItem>();
        if (colliderItem)
        {
            objectsHoveringOver.Remove(colliderItem);
        }
    }
}
