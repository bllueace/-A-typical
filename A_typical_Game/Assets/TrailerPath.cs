using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerPath : MonoBehaviour {

    [Range(1, 50)]
    public int speedInSeconds = 10;

	// Use this for initialization
	void Start () {
        //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("TrailerPath1"), "time", speedInSeconds, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathComplete"));

    }

    void onPathComplete()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("ZoomOutTrailer"), "time", speedInSeconds, "easetype", iTween.EaseType.linear, "orientToPath", false, "lookTime", 0.5, "lookAhead", 0.001));

    }


    void onPathComplete2()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("ZoomOutTrailer2"), "time", 4, "easetype", iTween.EaseType.linear, "orientToPath", false, "lookTime", 0.5, "lookAhead", 0.001));

    }
    // Update is called once per frame
    void Update ()
    {


        if (Input.GetKeyDown("1"))
        {
            iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("TrailerPath1"), "time", speedInSeconds, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathComplete"));
        }

        if (Input.GetKeyDown("2"))
        {
            iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("TrailerPath2"), "time", speedInSeconds, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathComplete2"));
        }

    }
}
