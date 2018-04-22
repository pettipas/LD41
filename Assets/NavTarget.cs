using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavTarget : MonoBehaviour {

    public Icon associatedIcon;

    public void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
}
