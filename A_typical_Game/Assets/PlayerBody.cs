using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour {

    //public BoxCollider Player;
    //public BoxCollider Body;
    public Transform PlayerEye;
    public Transform PlayerHead;
    public Transform PlayerRig;
    public GameObject Rig;
    float speed = 1;

    void Start ()
    {
        PlayerEye = PlayerEye.GetComponent<Transform>();
        PlayerHead = PlayerHead.GetComponent<Transform>();


    }

    void Update ()
    {

        //Body.transform.Translate(1,1,1);
        //Body.center = new Vector3(10, 10, 10);
        //Player.transform.position

        Vector3 newPos = new Vector3(PlayerEye.transform.position.x, PlayerEye.transform.position.y, PlayerEye.transform.position.z);
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

    //void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))  
    //    {
    //        //PlayerRig.transform.Translate(0f, 1f, 0f);
    //        //Rig.GetComponent<Rigidbody>().velocity = Vector2.zero;
    //        Rig.GetComponent<Rigidbody>().isKinematic = true;
    //        Debug.Log("Hello contact ground");
    //    }
    //}
    //void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
    //    {

    //        Rig.GetComponent<Rigidbody>().isKinematic = false;
    //        Debug.Log("exit test");
    //    }
    //}

}
