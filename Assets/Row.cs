using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour {

    public Walker prefab;
    public float distance = 2.2f;
    public int numofdoods;
    public List<Walker> walkers = new List<Walker>();

    [ContextMenu("SetUp")]
    public void SetUp() {

        for (int i = 0; i < walkers.Count; i++) {
            DestroyImmediate(walkers[i].gameObject);
        }

        walkers.Clear();

        for (int i = 0; i < numofdoods; i++) {
            Walker walker = prefab.Duplicate(transform.position + new Vector3(distance * i, 0, 0));
            walker.transform.SetParent(transform);
            walkers.Add(walker);
        }
    }

    public void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(9 * distance, 0, 0));
    }
}
