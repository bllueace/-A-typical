using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    Animator anim;

    GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Model");
        anim = GetComponent<Animator>();

        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Path1"), "time", 20, "easetype", iTween.EaseType.easeOutSine,"orientToPath", true, "lookTime", 0.5,"lookAhead",0.001,"oncomplete", "onPath1Complete"));
    }
	

    void onPath1Complete()
    {
        //anim.SetBool("IDLE", true);

        anim.Play(stateName: "FlyEnd");

        //Debug.Log("I have arived! *chirp* *chirp*");
    }

	// Update is called once per frame
	void Update () {


        float dist = Vector3.Distance(player.transform.position, transform.position);

        Vector3 dist2 = player.transform.position;

        //Debug.Log("Distance to bird:" + dist2);

        if (Input.GetKeyDown("space"))
        {
            anim.Play(stateName: "FlyStart");

            iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Path2"), "time", 10, "easetype", iTween.EaseType.easeOutSine, "orientToPath", true,"lookTime", 0.5,"lookAhead",0.001, "oncomplete", "onPath1Complete"));

        }

    }
}
