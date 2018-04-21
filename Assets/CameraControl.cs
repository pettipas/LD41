using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Camera theCamera;
    public Color gizmoColor;
    public  void OnDrawGizmos() {
        Gizmos.color = gizmoColor;
        Matrix4x4 temp = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        if (this.theCamera.orthographic) {
            float spread = theCamera.farClipPlane - theCamera.nearClipPlane;
            float center = (theCamera.farClipPlane + theCamera.nearClipPlane) * 0.5f;
            Gizmos.DrawWireCube(new Vector3(0, 0, center), new Vector3(theCamera.orthographicSize * 2 * theCamera.aspect, theCamera.orthographicSize * 2, spread));
        }
        Gizmos.matrix = temp;
    }
}
