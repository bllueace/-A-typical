using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    Animator anim;
    [SerializeField] Transform leftHand; //Is Camera(head)
    [SerializeField] Transform rightHand; //Is Camera(head)
    [SerializeField] Transform Bird; //Is Camera(head)
    [SerializeField] Transform PickaxeInHand; // Script of the pickaxe in the hand

    public int currentPath = 0;
    public GameObject leavingNarative;
    bool flying = false;
    float dist;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromPitToNarrative"), "time", 3, "easetype", iTween.EaseType.linear,"orientToPath", true, "lookTime", 0.5,"lookAhead",0.001,"oncomplete", "onPathComplete"));
    }
	

    void onPathComplete()
    {
        //anim.SetBool("IDLE", true);

        anim.Play(stateName: "FlyEnd");
        currentPath++;
        flying = false;
        //Debug.Log("I have arived! *chirp* *chirp*");
    }

    // Update is called once per frame
    void Update() {

        dist = Vector3.Distance(rightHand.position, Bird.transform.position);

        Debug.Log("Distance to bird is: "+ dist);

        if (currentPath == 1 && flying == false)
        {
            if ((Vector3.Distance(leftHand.position, Bird.transform.position) < 0.2f) || (Vector3.Distance(rightHand.position, Bird.transform.position) < 0.2f))
            {
                flying = true;
                anim.Play(stateName: "Fly");
                iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromNarrativeToPillar"), "time", 10, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathComplete"));
            }
            else if (Vector3.Distance(rightHand.position, Bird.transform.position) > 5f)
            {
                flying = true;
                anim.Play(stateName: "Fly");
                iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromNarrativeToPillar"), "time", 10, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathComplete"));
            }
        }

        if (currentPath == 2 && !flying)
        {
            if ((Vector3.Distance(leftHand.position, Bird.transform.position) < 3f) || (Vector3.Distance(rightHand.position, Bird.transform.position) < 3f))
            {
                flying = true;
                anim.Play(stateName: "Fly");
                iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromPillarToPickaxe"), "time", 10, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathComplete"));
            }
        }

        if (currentPath == 3 && !flying)
        {
            if ((Vector3.Distance(leftHand.position, PickaxeInHand.transform.position) < 0.2f) || (Vector3.Distance(rightHand.position, PickaxeInHand.transform.position) < 0.2f))
            {
                flying = true;
                anim.Play(stateName: "Fly");
                iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromPickaxeToCaventrance"), "time", 10, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathComplete"));
            }

        }

        if (currentPath == 4 && !flying)
        {
            if ((Vector3.Distance(leftHand.position, PickaxeInHand.transform.position) < 3f) || (Vector3.Distance(rightHand.position, PickaxeInHand.transform.position) < 3f))
            {
                flying = true;
                anim.Play(stateName: "Fly");
                iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromCaveentranceToPuzzleA"), "time", 10, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathComplete"));
            }

        }















        if (Input.GetKeyDown("space"))
        {
            anim.Play(stateName: "FlyStart");

            iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Path2"), "time", 10, "easetype", iTween.EaseType.linear, "orientToPath", true,"lookTime", 0.5,"lookAhead",0.001, "oncomplete", "onPath1Complete"));

        }

    }
}
