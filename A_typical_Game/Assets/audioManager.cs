using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{

    public AudioClip cliffClip;
    public AudioClip caveClip;
    public AudioClip puzzleClip;


    [SerializeField]
    Transform PickaxeInHand; // Script of the pickaxe in the hand
    [SerializeField]
    Transform leftHand; //Is Camera(head)
    [SerializeField]
    Transform rightHand; //Is Camera(head)
    [SerializeField]
    Transform caveTrigger;


    public GameObject puzzleSolved;

    bool climbed;
    bool incave;
    bool puzzleDone;

    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
        //yield return new WaitForSeconds(audio.clip.length);
        //audio.clip = otherClip;
        //audio.Play();
    }




    // Update is called once per frame
    void Update()
    {

        if (!climbed)
        {
            if ((Vector3.Distance(leftHand.position, PickaxeInHand.transform.position) < 0.2f) || (Vector3.Distance(rightHand.position, PickaxeInHand.transform.position) < 0.2f))
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.Stop();

                audio.clip = cliffClip;
                audio.Play();
                climbed = true;
            }
        }

        if(!incave)
        {
            if ((Vector3.Distance(leftHand.position, caveTrigger.transform.position) < 3f) || (Vector3.Distance(rightHand.position, caveTrigger.transform.position) < 3f))
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.Stop();

                audio.clip = caveClip;
                audio.Play();
                incave = true;
            }
        }

        if(!puzzleDone)
        {
            if (puzzleSolved.GetComponent<Room2Cleared>().solved)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.Stop();
                audio.clip = puzzleClip;
                audio.Play();
                puzzleDone = true;
            }
        }

    }

}