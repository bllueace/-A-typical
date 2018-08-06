using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarCollider : MonoBehaviour {

    [SerializeField] Transform Player; //Is Camera(head)

    //public Color CloudColor;
    //public Color MainColor;
    //public Color SecondColor;
    public int TintStrength;
    public int TimeChanging;

    [SerializeField] CaveentranceCollider caveEntrance;

    private float AlphaSphere;

    private int TimeChangingDecrement;

    public bool HasReachedPillar;
   // [SerializeField] CloudsToy Clouds;
    [SerializeField] Transform SphereFog;

    void Start()
    {
        //SphereFog.GetComponent<Renderer>().material.SetColor("_Color", Clouds.MainColor);
        //Initiate the time the player has stayed in the narrative area
        HasReachedPillar = false;
    }

    public IEnumerator IsInPillarArea()
    {
        //This coroutine check if the player isnear the pillar from when they leave the narrative area (called in NarrativeCollider script)
        do
        {
            //Check if the player is in the narrative area
            if (Vector3.Distance(Player.position, this.transform.position) < 1.6f)
            {
                TimeChangingDecrement = TimeChanging;
                HasReachedPillar = true;
                //Start the changing environment by having darker clouds
               // StartCoroutine(FromSunnyToCloudly()); //For the cloud and the sphere
                break;
            }
            yield return null;
        } while (!HasReachedPillar);

        StartCoroutine(caveEntrance.IsInCaveArea()); //Wait for the next path
    }

    //IEnumerator FromSunnyToCloudly()
    //{

    //    AlphaSphere = (1 - SphereFog.GetComponent<Renderer>().material.GetColor("_Color").a) / TimeChanging;
    //    Color Difference; //Use to see how much float should be added to reach the next color

    //    Difference = CloudColor - Clouds.CloudColor;
    //    Color IncrementCloud = new Color(Difference.r / TimeChanging, Difference.g / TimeChanging, Difference.b / TimeChanging, Difference.a / TimeChanging);

    //    Difference = MainColor - Clouds.MainColor;
    //    Color IncrementMain = new Color(Difference.r / TimeChanging, Difference.g / TimeChanging, Difference.b / TimeChanging, Difference.a / TimeChanging);


    //    Difference = SecondColor - Clouds.SecondColor;
    //    Color IncrementSecond = new Color(Difference.r / TimeChanging, Difference.g / TimeChanging, Difference.b / TimeChanging, Difference.a / TimeChanging);

    //    Clouds.TintStrength = TintStrength;

    //    do
    //    {


    //        Clouds.CloudColor = new Color(Clouds.CloudColor.r + IncrementCloud.r, Clouds.CloudColor.g + IncrementCloud.g,
    //            Clouds.CloudColor.b + IncrementCloud.b, Clouds.CloudColor.a + IncrementCloud.a);

    //        Clouds.MainColor = new Color(Clouds.MainColor.r + IncrementMain.r, Clouds.MainColor.g + IncrementMain.g,
    //            Clouds.MainColor.b + IncrementMain.b, Clouds.MainColor.a + IncrementMain.a);

    //        SphereFog.GetComponent<Renderer>().material.SetColor("_Color", new Color(Clouds.MainColor.r, Clouds.MainColor.g,
    //                                                                                 Clouds.MainColor.b,
    //                                                                                 SphereFog.GetComponent<Renderer>().material.GetColor("_Color").a + AlphaSphere));

    //        Clouds.SecondColor = new Color(Clouds.SecondColor.r + IncrementSecond.r, Clouds.SecondColor.g + IncrementSecond.g,
    //            Clouds.SecondColor.b + IncrementSecond.b, Clouds.SecondColor.a + IncrementSecond.a);

    //        //Clouds.SecondColor = Color.Lerp(Clouds.SecondColor, IncrementSecond, TimeChanging);

    //        TimeChangingDecrement--;
    //        yield return new WaitForSeconds(0.1f);

    //    } while (TimeChangingDecrement > 0);
    //    //print("finished");
    //}

    //The part bellow can't work because the colliders block from teleporting
    /*void OnTriggerEnter(Collider c)
    {
        Debug.Log("Near the pillar");
        //If the player is near the pillar
        if (c.GetComponent<Camera>())
        {
            TimeChangingDecrement = TimeChanging;
            HasReachedPillar = true;
            //Start the changing environment by having more clouds and darker
            StartCoroutine(FromSunnyToCloudly()); //For the cloud and the sphere
            
          
        }
    }*/


}
