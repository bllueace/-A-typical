using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnTrigger : MonoBehaviour {

    public GameObject myObject;

    void OnTriggerEnter()
    {
        myObject.SetActive(false);
    }
}
