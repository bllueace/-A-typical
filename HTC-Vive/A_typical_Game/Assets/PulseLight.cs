using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseLight : MonoBehaviour {

    [HideInInspector]
    public Light myLight;
    public Light gameLight;

    private float brightness = 12;
    private bool flip = false;
	void Start ()
    {
		myLight = gameLight.GetComponent<Light>();
    }
	
	void Update ()
    {
        if (flip) 
            brightness += 0.1f;
        else
            brightness -= 0.1f;

        if (brightness > 20 || brightness < 5)

        myLight.range = brightness;
    }
}
