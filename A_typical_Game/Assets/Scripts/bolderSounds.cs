using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolderSounds : MonoBehaviour {

    public AudioClip[] crumble; //array of audio files for crumbling noise
    private AudioSource source;

    void Start () {

        source = GetComponent<AudioSource>(); 
        source.PlayOneShot(crumble[Random.Range(0, 3)]); //choose a random sound effect from the array

    }
}
