using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeTooltip : MonoBehaviour {

    public GameObject pickaxe;
    public GameObject tooltip;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (pickaxe.gameObject.layer == LayerMask.NameToLayer("Pickaxe"))
            tooltip.SetActive(false);
    }
}
