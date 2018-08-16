using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdNPC : MonoBehaviour {

    Animator anim;
    [SerializeField] Transform leftHand; //Is lefthand
    [SerializeField] Transform rightHand; //Is right hand
    [SerializeField] Transform Bird; // bird location
    [SerializeField] Transform PickaxeInHand; // picakxe location

    public GameObject holeFull;

    public int currentPath = 0;
    public GameObject leavingNarative;
    bool flying = false;
    float dist;

    // Use this for initialization
    void Start()
    {
        //gets NPC animator component
        anim = GetComponent<Animator>();
        //path from pit to narative point 1
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromPitToNarrative"), "time", 20, "easetype", iTween.EaseType.linear,"orientToPath", true, "lookTime", 0.5,"lookAhead",0.001,"oncomplete", "onPathComplete"));
    }
	//on certain path complete
    void onPathComplete()
    {
        //start fly end animation
        anim.Play(stateName: "FlyEnd");
        currentPath++;
        flying = false;
        //Debug.Log("I have arived! *chirp* *chirp*");
    }

    //on other path complete
    void onPathCompleteTwo()
    {
        //plays flight animation
        anim.Play(stateName: "Fly");
        currentPath = 99;
        flying = false;
        //fly's around the hole in level 2
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FlyAroundHole"), "time", 4, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathCompleteTwo"));
        //Debug.Log("I have arived! *chirp* *chirp*");
    }
    //on other path complete
    void onPathCompleteThree()
    {
        flying = true;
        anim.Play(stateName: "FlyEnd");
    }

    // Update is called once per frame
    void Update() {

        //checks if path 1 has been complete
        if (currentPath == 1 && flying == false)
        {
            //actiavre path 2 if player gets too close
            if ((Vector3.Distance(leftHand.position, Bird.transform.position) < 0.2f) || (Vector3.Distance(rightHand.position, Bird.transform.position) < 0.2f))
            {
                flying = true;
                anim.Play(stateName: "Fly");
                iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromNarrativeToPillar"), "time", 10, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathComplete"));
            }
            //actiavre path 2 if player gets too close
            else if (Vector3.Distance(rightHand.position, Bird.transform.position) > 5f)
            {
                flying = true;
                anim.Play(stateName: "Fly");
                iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromNarrativeToPillar"), "time", 7, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathComplete"));
            }
        }

        //next narative area path
        if (currentPath == 2 && !flying)
        {
            if ((Vector3.Distance(leftHand.position, Bird.transform.position) < 5.5f) || (Vector3.Distance(rightHand.position, Bird.transform.position) < 5.5f))
            {
                flying = true;
                anim.Play(stateName: "Fly");
                iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromPillarToPickaxe"), "time", 10, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathComplete"));
            }
        }
        //next narative area path
        if (currentPath == 3 && !flying)
        {
            if ((Vector3.Distance(leftHand.position, PickaxeInHand.transform.position) < 0.2f) || (Vector3.Distance(rightHand.position, PickaxeInHand.transform.position) < 0.2f))
            {
                flying = true;
                anim.Play(stateName: "Fly");
                iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromPickaxeToCaventrance"), "time", 8, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathComplete"));
            }

        }
        //next narative area path
        if (currentPath == 4 && !flying)
        {
            if ((Vector3.Distance(leftHand.position, Bird.transform.position) < 2f) || (Vector3.Distance(rightHand.position, Bird.transform.position) < 2f))
            {
                flying = true;
                anim.Play(stateName: "Fly");
                iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromCaveEnterenceToLoop"), "time",2, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathCompleteTwo"));
            }

        }
        //next narative area path
        if (currentPath == 5)
        {
            flying = true;
            anim.Play(stateName: "Fly");
            iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FlyAroundHole"), "time", 4, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathComplete"));
        }


        if (currentPath == 99)
        {
            if (holeFull.GetComponent<FillThePit>().rockCount == 5 && !flying)
            {
                flying = true;
                anim.Play(stateName: "Fly");
                iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromLoopToPuzzleA"), "time", 10, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onPathCompleteThree"));
            }
        }
    }
}
