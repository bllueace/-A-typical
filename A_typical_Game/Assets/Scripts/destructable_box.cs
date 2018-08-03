using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructable_box : MonoBehaviour
{
    public GameObject destroyedVersion;
    //public bool test = false;



    void OnCollisionEnter(Collision target)
    {
        Debug.Log("pickaxe hit");

        if (target.collider.tag == "Pickaxe")
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }


    }
    //void OnCollisionStay(Collision target)
    //{
    //    Debug.Log("GOnCollisionStay");
    //    //if (target.gameObject.tag.Equals("Pickaxe") == true)
    //    //{
    //    //    Instantiate(destroyedVersion, transform.position, transform.rotation);
    //    //    Destroy(gameObject);
    //    //    test = true;
    //    //}
    //}
    //if (Vector3.Distance(Player.position, gameObject.transform.position) < 2)
    //{
    //    Instantiate(destroyedVersion, transform.position, transform.rotation);
    //    Destroy(gameObject);
    //}
}