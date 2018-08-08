using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    Animator anim;
    [SerializeField] Transform leftHand; //Is Camera(head)
    [SerializeField] Transform rightHand; //Is Camera(head)
    [SerializeField] Transform Bird; //Is Camera(head)
    [SerializeField] Transform PickaxeInHand; // Script of the pickaxe in the hand

    public GameObject holeFull;

    public int currentPath = 0;
    public GameObject leavingNarative;
    bool flying = false;
    float dist;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromPitToNarrative"), "time", 2, "easetype", iTween.EaseType.linear,"orientToPath", true, "lookTime", 0.5,"lookAhead",0.001,"oncomplete", "onPathComplete"));
    }
	

    void onPathComplete()
    {
        //anim.SetBool("IDLE", true);

        anim.Play(stateName: "FlyEnd");
        currentPath++;
        flying = false;
        //Debug.Log("I have arived! *chirp* *chirp*");
    }

    void onPathCompleteTwo()
    {
        //anim.SetBool("IDLE", true);

        anim.Play(stateName: "Fly");
        // currentPath++;
        currentPath = 99;
        flying = false;
        //anim.Play(stateName: "Fly");
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FlyAroundHole"), "time", 4, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathCompleteTwo"));

        //flying = false;
        //Debug.Log("I have arived! *chirp* *chirp*");
    }

    void onPathCompleteThree()
    {
        flying = true;
        anim.Play(stateName: "FlyEnd");
    }

    // Update is called once per frame
    void Update() {

        dist = Vector3.Distance(rightHand.position, Bird.transform.position);

        //Debug.Log("Distance to bird is: "+ dist);

        if (currentPath == 1 && flying == false)
        {
            if ((Vector3.Distance(leftHand.position, Bird.transform.position) < 0.2f) || (Vector3.Distance(rightHand.position, Bird.transform.position) < 0.2f))
            {
                flying = true;
                anim.Play(stateName: "Fly");
                iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromNarrativeToPillar"), "time", 3, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathComplete"));
            }
            else if (Vector3.Distance(rightHand.position, Bird.transform.position) > 5f)
            {
                flying = true;
                anim.Play(stateName: "Fly");
                iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromNarrativeToPillar"), "time", 3, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathComplete"));
            }
        }

        if (currentPath == 2 && !flying)
        {
            if ((Vector3.Distance(leftHand.position, Bird.transform.position) < 4f) || (Vector3.Distance(rightHand.position, Bird.transform.position) < 4f))
            {
                flying = true;
                anim.Play(stateName: "Fly");
                iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromPillarToPickaxe"), "time", 3, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathComplete"));
            }
        }

        if (currentPath == 3 && !flying)
        {
            if ((Vector3.Distance(leftHand.position, PickaxeInHand.transform.position) < 0.2f) || (Vector3.Distance(rightHand.position, PickaxeInHand.transform.position) < 0.2f))
            {
                flying = true;
                anim.Play(stateName: "Fly");
                iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromPickaxeToCaventrance"), "time", 3, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathComplete"));
            }

        }

        if (currentPath == 4 && !flying)
        {
            if ((Vector3.Distance(leftHand.position, Bird.transform.position) < 2f) || (Vector3.Distance(rightHand.position, Bird.transform.position) < 2f))
            {
                flying = true;
                anim.Play(stateName: "Fly");
                iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromCaveEnterenceToLoop"), "time",2, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathCompleteTwo"));
            }

        }

        if (currentPath == 5)
        {
            flying = true;
            anim.Play(stateName: "Fly");
            iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FlyAroundHole"), "time", 4, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathComplete"));

            //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FlyAroundHole"), "time", 3,"looptype","loop", "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001));
        }

        //int count = holeFull.GetComponent<FillThePit>().rockCount;

        if (currentPath == 99)
        {
            if (holeFull.GetComponent<FillThePit>().rockCount == 5 && !flying)
            {
                flying = true;
                anim.Play(stateName: "Fly");
                iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromLoopToPuzzleA"), "time", 3, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathCompleteThree"));
            }
        }












        //if (Input.GetKeyDown("space"))
        //{
        //    anim.Play(stateName: "FlyStart");

        //    //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FlyAroundHole"), "time", 3, "looptype", "loop", "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001));
        //    iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FlyAroundHole"), "time", 5, "loopType", "loop","easetype", iTween.EaseType.linear, "orientToPath", true, "delay", 0));
        //}

    }
}
