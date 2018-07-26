using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourManager : MonoBehaviour
{

    public Transform player;
    private bool shouldRun = true;

    void Update()
    {
        if (shouldRun)
        {
            if (Vector3.Distance(player.position, this.transform.position) < 1)
            {
                ChangeColour();
                shouldRun = false;
            }
        }
    }

    void ChangeColour()
    {
        GameObject[] myObjects = GameObject.FindGameObjectsWithTag("Coloured"); //temp, will change so you can send in tag for multiple colour changes
        foreach (GameObject Coloured in myObjects)
        {
            ColourChange[] myColours = Coloured.GetComponents<ColourChange>();

            foreach (ColourChange Script in myColours)
            {
                Script.enabled = true;
            }
        }

        rain.Play();

    }

    public ParticleSystem rain;

    void Start()
    {
        rain.Stop();
    }

}

