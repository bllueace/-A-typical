using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSwitch : MonoBehaviour {

    public bool test = false;
    public GameObject myself;
    public GameObject firstBlock;
    public GameObject replacedBlock;
    public GameObject myLight;

    void OnTriggerEnter()
    {
        test = true;

        firstBlock.SetActive(false);
        replacedBlock.SetActive(true);
        myLight.SetActive(false);
        myself.SetActive(false);
    }
}
