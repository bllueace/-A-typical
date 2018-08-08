using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveCollapse : MonoBehaviour {
    public AudioClip colapse;
    private AudioSource source;
    [SerializeField] Transform Player;
    public GameObject statue, beak, statueFallen, tpBlock;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();

    }

    //TO DO::Sound needs to added for the collapsing statue

    // Update is called once per frame
    void Update () {
        if (Vector3.Distance(Player.position, this.transform.position) < 2)
        {
            source.PlayOneShot(colapse);
            statue.SetActive(false);
            beak.SetActive(true);
            statueFallen.SetActive(true);
            tpBlock.SetActive(true);
        }
    }


}
