using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	


    [SerializeField] private float fadePerSecond = 2.5f;

    void Update()
    {
        var material = gameObject.GetComponent<Renderer>().material;
        var color = material.color;

        gameObject.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, color.a - (fadePerSecond * Time.deltaTime));
    }
}
