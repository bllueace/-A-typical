using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeCollider : MonoBehaviour {

    [SerializeField] Transform Player; //Is Camera(head)

    [SerializeField] Transform OutOfNarrativeArea; // Point that indicates the player has move forward the next part of the game
    public bool NextPath;

    [SerializeField] PillarCollider pillarArea; //to start the next coroutine

    float HasStayedIn;
    [SerializeField] float MinTimeIn;
    public bool EnoughTimeIn;
    //bool IsIn;

    void Start()
    {
        //Initiate the time the player has stayed in the narrative area
        //IsIn = false;
        HasStayedIn = 0;
        //EnoughTimeIn = false;
        NextPath = false;
        StartCoroutine(IsInNarrativeArea());
    }

    IEnumerator IsInNarrativeArea()
    {
        //This coroutine check if the player is inside the narrative area from the beginning and stops checking
        //once the player has spend enough time or went toward the next area
        do
        {
            //Check if the player is in the narrative area
            if (Vector3.Distance(Player.position, this.transform.position) < 1.6f)
            {
                //Calculate how much time the player spent in the narrative area and if it it enough
                HasStayedIn += 1 * Time.deltaTime;
                if (HasStayedIn >= MinTimeIn)
                {
                    NextPath = true;
                    break;
                }
            }
            //check if the player is going forward the next area
            
            else if (Vector3.Distance(Player.position, OutOfNarrativeArea.position) < 5.5f) {
                NextPath = true;
                break;
            }
            yield return null;
        } while (!EnoughTimeIn);


        StartCoroutine(pillarArea.IsInPillarArea());//Wait for the next path
    }

    //The part bellow can't work because the colliders block from teleporting
    /*void OnTriggerEnter(Collider c)
    {
        //If the player is in the narrative area
        if (c.GetComponent<Camera>())
        {
            //Starts to count the time the player has stayed in the area
            IsIn = true;
            StartCoroutine(UpdateCount());
        }
    }

    void OnTriggerExit(Collider c)
    {
        //If the player that goes out of the narrative area
        if (c.GetComponent<Camera>())
        {
            //Stop to count the time the player has stayed in the area
            IsIn = false;
            StopCoroutine(UpdateCount());
        }
    }

    IEnumerator UpdateCount()
    {
        do
        {
            print(HasStayedIn);
            HasStayedIn += 1 * Time.deltaTime;
            if (HasStayedIn >= MinTimeIn)
            {
                EnoughTimeIn = true;
            }
            yield return null;
        } while (IsIn);

    }*/

}
