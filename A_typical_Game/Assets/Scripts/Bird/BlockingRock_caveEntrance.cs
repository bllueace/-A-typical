using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingRock_caveEntrance : MonoBehaviour {

    //WARNING: Make sure this script is on top of destructable_box in the hierarchy

    [SerializeField] Bird_manager Bird;
    void OnCollisionEnter(Collision target)
    {
        Debug.Log("pickaxe hit");

        if (target.collider.tag == "Pickaxe")
        {
            Bird.BlockingRockCaveEntrancedestroyed = true;
        }


    }
}
