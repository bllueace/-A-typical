using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(MeshCollider))]
public class MeshCombinerEditor : Editor {

    void OnScreenGUI()
    {
        MeshCombiner mc = target as MeshCombiner;
        if (Handles.Button(mc.transform.position+Vector3.up * 5, Quaternion.LookRotation(Vector3.up),1,1,Handles.CylinderHandleCap))
        {
            mc.CombineMeshes();
        }
    }
}

