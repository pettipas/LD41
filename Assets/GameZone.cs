using UnityEngine;

public class GameZone : MonoBehaviour {

    public Bounds bounds;
    public Transform centre_marker;
    public void OnDrawGizmos() {
        bounds.center = centre_marker.position;
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(centre_marker.position, Vector3.one);
        Gizmos.DrawWireCube(centre_marker.position, bounds.extents);
    }
}
