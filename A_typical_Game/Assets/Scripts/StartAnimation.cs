using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour {


    public Animator ani;

	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();
       // ani.enabled = false;
	}
	

    void OnTriggerEnter()
    {
        // ani.enabled = true;
        // Destroy(gameObject);

        ani.Play("TestAnim");
    }

	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown("p"))
        {
            ani.Play("TestAnim");
        }

	}
}
