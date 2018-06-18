using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapModels : MonoBehaviour {

    public SteamVR_TrackedObject controller;
    public bool itemInHand = false;
    //public GameObject controllerModel;
    public GameObject itemModel;
    public GameObject spawnable;
    public float fallFix = 0.4f;
    // private SteamVR_RenderModel contrMesh;
    private MeshRenderer itemMesh;
    
    void Start()
    {
       //contrMesh = controllerModel.GetComponent<SteamVR_RenderModel>();
       itemMesh = itemModel.GetComponent<MeshRenderer>();
       itemModel.SetActive(true);
        
    }

    void Update ()
    {
        var device = SteamVR_Controller.Input((int)controller.index); 

        if (itemInHand && device.GetPress(SteamVR_Controller.ButtonMask.Grip))
        {
            

            spawnable.SetActive(true);
            Vector3 newPos = new Vector3(controller.transform.position.x, controller.transform.position.y - fallFix, controller.transform.position.z);
            spawnable.transform.position = newPos;

            itemInHand = false;
        }



        if (itemInHand)
        {
            itemMesh.enabled = true;

            foreach (SteamVR_RenderModel model in controller.GetComponentsInChildren<SteamVR_RenderModel>())
            {
                foreach (var child in model.GetComponentsInChildren<MeshRenderer>())
                    child.enabled = false;
            }
        }
        else
        {
            itemMesh.enabled = false;

            foreach (SteamVR_RenderModel model in controller.GetComponentsInChildren<SteamVR_RenderModel>())
            {
                foreach (var child in model.GetComponentsInChildren<MeshRenderer>())
                    child.enabled = true;
            }
        }

	}

    public void setItemInHand(bool myItem)
    {
        itemInHand = myItem;
    }
}
