//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Testing_changing_shaderEmission : MonoBehaviour {

//    //public Texture T_emi_Circles;
//    //public Texture T_emi_lineDoor;
//    //public Texture T_emi_lineTopLeft;
//    //public Texture T_emi_lineTopRight;
//    //public Texture T_emi_lineBottomLeft;
//    //public Texture T_emi_lineBottomRight;

//    bool Or;
//	// Use this for initialization
//	void Start () {
//        Or = true;
    
//    }
	
//	// Update is called once per frame
//	void Update () {
//        Or = !Or;
//        if (Or)
//        {
//            print(this.GetComponent<Renderer>().material.GetTexture("_Emi_circles"));
//           this.GetComponent<Renderer>().material.SetTexture("_Emi_circles", T_emi_Circles);
//        }
//        else
//        {
//            this.GetComponent<Renderer>().material.SetTexture("_Emi_circles", null);
//        }
//	}
//}
