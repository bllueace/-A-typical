using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
    //-------------------------------------------------------------------------
    public class FireSource : MonoBehaviour
    {
        public GameObject fireParticlePrefab;
        private GameObject fireObject;

        public ParticleSystem customParticles;

        public bool isBurning;

        public float burnTime;
        public float ignitionDelay = 0;
        private float ignitionTime;
        public AudioSource ignitionSound;
        GameObject bird;

        ////-------------------------------------------------
        void Start()
        {

            bird = GameObject.Find("Bird_character");//needs to be changed to "BIRD" object later on
        }

        //-------------------------------------------------
        void Update()
        {
            if ((burnTime != 0) && (Time.time > (ignitionTime + burnTime)) && isBurning)
            {
                isBurning = false;
                if (customParticles != null)
                {
                    customParticles.Stop();
                }
                else
                {
                    Destroy(fireObject);
                }
            }

            if (Vector3.Distance(transform.position, bird.transform.position) < 2.0f)
            {
                StartBurning();
            }

        }
        //-------------------------------------------------
        void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.tag == "NPC" && !isBurning)
            {
                StartBurning();
            }
        }

        //-------------------------------------------------
        private void StartBurning()
        {
            isBurning = true;
            ignitionTime = Time.time;

            // Play the fire ignition sound if there is one
            if (ignitionSound != null)
            {
                ignitionSound.Play();
            }

            if (customParticles != null)
            {
                customParticles.Play();
            }
            else
            {
                if (fireParticlePrefab != null)
                {
                    fireObject = Instantiate(fireParticlePrefab, transform.position, transform.rotation) as GameObject;
                    fireObject.transform.parent = transform;
                }
            }
        }
    }
}
