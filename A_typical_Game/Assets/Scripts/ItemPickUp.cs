using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {

    public SteamVR_TrackedObject controller;
    public GameObject myself;
    public GameObject mylight;

    [HideInInspector]
    public SwapModels hand;
    //public SteamVR_Controller.Device myDevice;
    //private SteamVR_TrackedObject myTrackedObject = null;
    //private Pickaxe myPickaxe;

    //public GameObject myItem;
    //public GameObject itemOnGround;


    //public void Setup(SteamVR_Controller.Device newDevice)
    //{
    //    myDevice = newDevice;
    //}

    private void Awake()
    {
        //myTrackedObject = GetComponent<SteamVR_TrackedObject>();
    }
    void Start ()
    {
        //myItem.SetActive(false);
        hand = controller.GetComponent<SwapModels>();
    }
	

	void Update ()
    {
        // myDevice = SteamVR_Controller.Input((int)myTrackedObject.index);
        
    }
    //void OnTriggerExit()
    //{
    //   test = false;
    //}
    void OnTriggerEnter()
    {
        myself.SetActive(false);
        mylight.SetActive(false);
        hand.setItemInHand(true);
       
    }
}
