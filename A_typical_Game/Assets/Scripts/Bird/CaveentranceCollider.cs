using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveentranceCollider : MonoBehaviour {

    [SerializeField] Transform Player; //Is Camera(head)

    public bool HasReachedCaveentrance;

    void Start()
    {
        HasReachedCaveentrance = false;
        StartCoroutine(IsInCaveArea()); //To delete, just for testing
    }

    public IEnumerator IsInCaveArea()
    {
        //This coroutine check if the player isnear the pillar from when they leave the narrative area (called in NarrativeCollider script)
        do
        {
            //Check if the player is in the narrative area
            if (Vector3.Distance(Player.position, this.transform.position) < 2f)
            {
                HasReachedCaveentrance = true;
                break;
            }
            yield return null;
        } while (!HasReachedCaveentrance);
    }

    //The part bellow can't work because the colliders block from teleporting
    /*void OnTriggerEnter(Collider c)
    {
        //If the player is in the cave entrance
        if (c.GetComponent<Camera>())
        {
            HasReachedCaveentrance = true;
        }
    }*/

}
