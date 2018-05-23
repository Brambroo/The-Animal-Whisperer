using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (VisionCone))]
public class FieldOfViewEditor : Editor {

	//void OnSceneGUI()
 //   {
 //       VisionCone fov = (VisionCone)target;
 //       Handles.color = Color.yellow;
 //       Handles.DrawWireArc(fov.transform.position, Vector3.forward, Vector3.up, 360, fov.viewRadius);
 //       Vector3 viewAngleA = fov.DirFromAngle(-fov.viewAngle / 2 +180, false);
 //       Vector3 viewAngleB = fov.DirFromAngle(fov.viewAngle / 2 -180, false);

 //       Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius); //multiplying by view radius sets the length of line
 //       Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewRadius); //multiplying by view radius sets the length of line

 //       foreach(Transform visibleTarget in fov.visibleTargets)
 //       {
 //           Handles.DrawLine(fov.transform.position, visibleTarget.position);
 //       }
 //   }
}
