using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeet : MonoBehaviour {

    //public BoxCollider Player;
    //public BoxCollider Body;
    public Transform PlayerEye;
    public Transform PlayerHead;
    public Transform PlayerRig;
    public GameObject Rig;
    //float speed = 1;
    bool touching = false;

    void Start()
    {
        PlayerEye = PlayerEye.GetComponent<Transform>();
        PlayerHead = PlayerHead.GetComponent<Transform>();


    }

    void Update()
    {

        //Body.transform.Translate(1,1,1);
        //Body.center = new Vector3(10, 10, 10);
        //Player.transform.position

        Vector3 newPos = new Vector3(PlayerEye.transform.position.x, PlayerRig.transform.position.y, PlayerEye.transform.position.z);
        transform.position = newPos;


        //Body.transform.position(newPos);

    }
    //void FixedUpdate()
    //{
    //    float x = Input.GetAxisRaw("Horizontal");
    //    float z = Input.GetAxisRaw("Vertical");
    //    Player.position += z * transform.forward * Time.deltaTime * speed;
    //    Player.position += x * transform.right * Time.deltaTime * speed;
    //}
    private void FixedUpdate()
    {
        if (!touching)
        {
            Rig.GetComponent<Rigidbody>().isKinematic = false;
            Rig.GetComponent<Rigidbody>().useGravity = true;

        }
        else
        {
            Rig.GetComponent<Rigidbody>().isKinematic = true;
            Rig.GetComponent<Rigidbody>().useGravity = false;
        }


    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            //PlayerRig.transform.Translate(0f, 0.0001f, 0f);
            Rig.GetComponent<Rigidbody>().velocity = Vector2.zero;
            Rig.GetComponent<Rigidbody>().velocity = Vector3.zero;

            //Rig.GetComponent<Rigidbody>().isKinematic = true;
            //Rig.GetComponent<Rigidbody>().useGravity = false;
            touching = true;
            Debug.Log("Contact With Ground!");
        }
        else
        {
            //touching = false;
            //Rig.GetComponent<Rigidbody>().isKinematic = false;
            //Rig.GetComponent<Rigidbody>().useGravity = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {

            //Rig.GetComponent<Rigidbody>().isKinematic = false;
            //Rig.GetComponent<Rigidbody>().useGravity = true;
            //Debug.Log("exit test");

            //if (!touching)
            //{
            //    Rig.GetComponent<Rigidbody>().isKinematic = false;
            //    Rig.GetComponent<Rigidbody>().useGravity = true;
            //}
            touching = false;
            Debug.Log("Contact Lost!");
        }
    }
    public void SetTouching(bool newTouching)
    {
        touching = newTouching;
    }

}
