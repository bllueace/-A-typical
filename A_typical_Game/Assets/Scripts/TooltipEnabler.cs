using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipEnabler : MonoBehaviour {

    public GameObject cone;
    public float distance;
    public GameObject tooltip;
    private bool shownOnce = false;

	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!shownOnce)
        {
            if (Vector3.Distance(cone.transform.position, gameObject.transform.position) < distance) //enable tooltip if player has reached the object's range
            {
                tooltip.SetActive(true);
                shownOnce = true;
            }
            
        }

    }
}
