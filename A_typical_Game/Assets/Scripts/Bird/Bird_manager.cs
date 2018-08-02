using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_manager : MonoBehaviour {

    Animator anim;

    [SerializeField] NarrativeCollider ColliderNarrativeArea; //Collider for the narrative area
    //[SerializeField] OutNarrativeCollider ColliderOutNarrative; // Collider to know when the player leave the narrative area
    [SerializeField] PillarCollider ColliderPillar; // Collider for the pillar area
    [SerializeField] Pickaxe PickaxeInHand; // Script of the pickaxe in the hand
    public bool BlockingRockCaveEntrancedestroyed; //False when the rock blocking the cave entrance has been destroyed
    [SerializeField] CaveentranceCollider ColliderCaveEntrance; // Script of the pickaxe in the hand
    GameObject NarrativeArea;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        //anim.SetBool("Idle", true); IDLE by default
        GoOutOfPit();
    }

//START MOVE OUT OF BIT TO NARRATIVE AREA
    void GoOutOfPit()
    {
        //TO ADD: Make bird noise
        //TO ADD: if the player is looking in the right direction // Coroutine to do
        //The bird flies out of the pit, circle the player and then lands by narrative assets
        //anim.SetBool("Idle", false);
        anim.SetBool("FlyStart", true);
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromPitToNarrative"), "time", 20, "easetype", iTween.EaseType.easeOutSine, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onFromPitToNarrativeComplete"));

    }

    void onFromPitToNarrativeComplete() //Path: from pit to narrative
    {
        //anim.Play(stateName: "FlyEnd");
        anim.SetBool("FlyStart", false);
        anim.SetBool("FlyStop", true);
        Debug.Log("I have arrived (narrative)! *chirp* *chirp*");
        StartCoroutine(WaitToLeaveNarrativeArea());
    }
 //END MOVE OUT OF BIT TO NARRATIVE AREA

//START MOVE FROM NARRATIVE AREA TO PILLAR
    IEnumerator WaitToLeaveNarrativeArea()
    {
        do
        {
            //Do nothing until the player has spent enough time in the narrative area or is leaving toward the climbing area
            yield return new WaitForSeconds(1f);
        }
        while (!ColliderNarrativeArea.NextPath /*!ColliderNarrativeArea.EnoughTimeIn /*&& !ColliderOutNarrative.PassNarrativeArea*/);

        //Bird flies to a pillar, land on it
        anim.SetBool("FlyStart", true);
        anim.SetBool("FlyStop", false);
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromNarrativeToPillar"), "time", 10, "easetype", iTween.EaseType.easeOutSine, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onFromNarrativeToPillarComplete"));
    }

    void onFromNarrativeToPillarComplete() // Path: from narrative to pillar
    {
        //anim.Play(stateName: "FlyEnd");
        anim.SetBool("FlyStart", false);
        anim.SetBool("FlyStop", true);

        Debug.Log("I have arrived (pillar)! *chirp* *chirp*");
        StartCoroutine(WaitToLeavePillar());
    }
//END MOVE FROM NARRATIVE AREA TO PILLAR

//START MOVE FROM PILLAR TO PICKAXE
    IEnumerator WaitToLeavePillar()
    {
        do
        {
            //Do nothing until the playeris near the pillar
            yield return new WaitForSeconds(1f);
        }
        while (!ColliderPillar.HasReachedPillar);

        //Bird flies to the pickaxe, land on it
        anim.SetBool("FlyStart", true);
        anim.SetBool("FlyStop", false);
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromPillarToPickaxe"), "time", 10, "easetype", iTween.EaseType.easeOutSine, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onFromPillarToPickaxeComplete"));
    }

    void onFromPillarToPickaxeComplete() // Path: from pillar to pickaxe
    {
        //anim.Play(stateName: "FlyEnd");
        anim.SetBool("FlyStart", false);
        anim.SetBool("FlyStop", true);

        Debug.Log("I have arrived (pickaxe)! *chirp* *chirp*");
        StartCoroutine(WaitToLeavePickaxe());
    }
 //END MOVE FROM PILLAR TO PICKAXE

//START MOVE FROM PICKAXE TO CAVE ENTRANCE
    IEnumerator WaitToLeavePickaxe()
    {
        do
        {
            //Do nothing until the playeris has taken the pickaxe
            yield return new WaitForSeconds(1f);
        }
        while (!PickaxeInHand.counter);

        //Bird flies to the pickaxe, land on it
        anim.SetBool("FlyStart", true);
        anim.SetBool("FlyStop", false);
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromPickaxeToCaventrance"), "time", 10, "easetype", iTween.EaseType.easeOutSine, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onFromPickaxeToCaveEntranceComplete"));
    }

    void onFromPickaxeToCaveEntranceComplete() // Path: from pillar to pickaxe
    {
        //anim.Play(stateName: "FlyEnd");
        anim.SetBool("FlyStart", false);
        anim.SetBool("FlyStop", true);

        Debug.Log("I have arrived (cave entrance)! *chirp* *chirp*");
        StartCoroutine(WaitToLeaveCaveentrance());
    }
//END MOVE FROM PICKAXE TO CAVE ENTRANCE

//START MOVE FROM CAVE ENTRANCE TO PUZZLE A
    IEnumerator WaitToLeaveCaveentrance()
    {
        do
        {
            //Do nothing until the playeris has entered the cave entrance 
            //the rock blocking the entrance has to be broken and the player enter collider
            yield return new WaitForSeconds(1f);
        }
        while (!ColliderCaveEntrance.HasReachedCaveentrance || 
            !BlockingRockCaveEntrancedestroyed); //BlockingRockCaveEntrancedestroyed is changed from the script "BlockingRock_caveEntrance" on the rock to destroy

        //Bird flies to the pickaxe, land on it
        anim.SetBool("FlyStart", true);
        anim.SetBool("FlyStop", false);
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("FromCaveentranceToPuzzleA"), "time", 10, "easetype", iTween.EaseType.easeOutSine, "orientToPath", true, "lookTime", 0.5, "lookAhead", 0.001, "oncomplete", "onFromPCaveEntranceToPuzzleAComplete"));
    }

    void onFromPCaveEntranceToPuzzleAComplete() // Path: from pillar to pickaxe
    {
        //anim.Play(stateName: "FlyEnd");
        anim.SetBool("FlyStart", false);
        anim.SetBool("FlyStop", true);

        Debug.Log("I have arrived (puzzleA)! *chirp* *chirp*");
        //StartCoroutine(WaitToLeavepuzzleA()); Prototype stops there
    }
//END MOVE FROM CAVE ENTRANCE TO PUZZLE A
}
