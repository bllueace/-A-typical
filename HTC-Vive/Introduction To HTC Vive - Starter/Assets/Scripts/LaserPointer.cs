using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour {


    // Use this for initialization
    void Start()
    {
        // new laser and reference to it in laser
        laser = Instantiate(laserPrefab);
        // store laser transform
        laserTransform = laser.transform;

        // spawn new reticle and save a reference
        reticle = Instantiate(teleportReticlePrefab);
        // store the riticles transform
        teleportReticleTransform = reticle.transform;
    }

    private SteamVR_TrackedObject trackedObj;

    // reference to laser prefab
    public GameObject laserPrefab;
    // reference to laser instace
    private GameObject laser;
    // transfrom component for easy use
    private Transform laserTransform;
    // laser hit position
    private Vector3 hitPoint;

    // camera rig transform
    public Transform cameraRigTransform;
    // teleport reticle reference
    public GameObject teleportReticlePrefab;
    // reticle instance reference
    private GameObject reticle;
    // teleport reference
    private Transform teleportReticleTransform;
    // players head reference
    public Transform headTransform;
    // laser offset
    public Vector3 teleportReticleOffset;
    // filter layers
    public LayerMask teleportMask;
    // check for valid location
    private bool shouldTeleport;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void ShowLaser(RaycastHit hit)
    {
        // show the laser
        laser.SetActive(true);
        // position the laser in the middle of controler
        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f);
        // point the laser to raycast location
        laserTransform.LookAt(hitPoint);
        // scale the laser 
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y,
            hit.distance);
    }

    private void Teleport()
    {
        // set to false while teleporting
        shouldTeleport = false;
        // hide reticle
        reticle.SetActive(false);
        // calculate the difference
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        // reset the y position
        difference.y = 0;
        // move the camera rig
        cameraRigTransform.position = hitPoint + difference;
    }

    // Update is called once per frame
    void Update () {
        // if touchpad is held down
        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            RaycastHit hit;

            // shoot ray from the controller
            if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100, teleportMask))
            {
                hitPoint = hit.point;
                ShowLaser(hit);
                // show teleprot reticle
                reticle.SetActive(true);
                // move reticle to raycast location
                teleportReticleTransform.position = hitPoint + teleportReticleOffset;
                // set valid position for teleport
                shouldTeleport = true;
            }
        }
        else // hide the laser when released
        {
            laser.SetActive(false);
            reticle.SetActive(false);
        }
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad) && shouldTeleport)
        {
            Teleport();
        }
    }
}
