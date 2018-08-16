using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseLight : MonoBehaviour {

    [HideInInspector]
    public Light myLight;

    public Light gameLight;
    public float minBrightness = 5;
    public float maxBrightness = 20;
    public float rate = 0.1f;
    private float brightness = 1;


    private bool flip = false;

	void Start ()
    {
        brightness = minBrightness;
        myLight = gameLight.GetComponent<Light>();
    }
	
	void Update ()
    {
        //increase/decrease brightness by rate specified
        if (flip) 
            brightness += rate;
        else
            brightness -= rate;

        if (brightness > maxBrightness || brightness < minBrightness)
            flip = !flip;
 
        myLight.range = brightness;
    }
}
