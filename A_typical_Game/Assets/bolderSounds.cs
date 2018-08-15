using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolderSounds : MonoBehaviour {

    public AudioClip[] crumble;
    private AudioSource source;
    //public GameObject Myself;

    //public GameObject[] obj;
    
    // Use this for initialization
    void Start () {

        source = GetComponent<AudioSource>();
        source.PlayOneShot(crumble[Random.Range(0, 3)]);
        //source.PlayOneShot(crumble);


    }

    // Update is called once per frame
    void Update () {

        
        //Myself.SetActive(false);
    }
}
